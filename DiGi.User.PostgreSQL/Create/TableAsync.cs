using Npgsql;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.User.PostgreSQL
{
    /// <summary>
    /// Provides static extension methods on <see cref="NpgsqlConnection"/> for the data-definition operations of the User schema.
    /// </summary>
    public static partial class Create
    {
        /// <summary>
        /// Asynchronously creates the users table in the PostgreSQL database if it does not already exist, and brings an
        /// existing table up to the current column set.
        /// <para>Every statement is idempotent (<c>IF NOT EXISTS</c>), so the method is safe to run on every
        /// write and read path, mirroring the create-then-act pattern used by the converter.</para>
        /// <para>The <c>ALTER TABLE ... ADD COLUMN IF NOT EXISTS</c> statements are the migration for databases whose users
        /// table predates the credential and level columns: <c>CREATE TABLE IF NOT EXISTS</c> alone does nothing to a table
        /// that already exists. A database is migrated only by a path that calls this method, which the converter's write
        /// operations do; a read against an unmigrated database fails with <c>42703 column does not exist</c>.</para>
        /// </summary>
        /// <param name="npgsqlConnection">The <see cref="NpgsqlConnection"/> instance used to execute the command.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the table was created or brought up to the current column set; false only when the connection is null. A statement-level failure - permissions, an object that collides with the DDL - propagates as an <see cref="NpgsqlException"/> rather than returning false, so the caller reports what actually failed instead of a bare false that names nothing.</returns>
        public static async Task<bool> TableAsync_User(this NpgsqlConnection? npgsqlConnection, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null)
            {
                return false;
            }

            // The email column is the natural key: it is NOT NULL and UNIQUE, so an
            // INSERT ... ON CONFLICT (email) upsert is deterministic and needs no NULLS NOT DISTINCT.
            string commandText = $@"
                CREATE TABLE IF NOT EXISTS {Constants.TableName.User} (
                    id SERIAL PRIMARY KEY,
                    email TEXT NOT NULL UNIQUE,
                    first_name TEXT,
                    last_name TEXT,
                    level INTEGER DEFAULT 0,
                    password_hash TEXT,
                    password_salt TEXT,
                    password_iterations INTEGER,
                    object JSONB,
                    created_at timestamptz DEFAULT now(),
                    updated_at timestamptz DEFAULT now()
                );

                -- Migration for tables created before these columns existed. CREATE TABLE IF NOT EXISTS above is a
                -- no-op once the table exists, so a pre-existing users table gains them only here.
                ALTER TABLE {Constants.TableName.User} ADD COLUMN IF NOT EXISTS level INTEGER DEFAULT 0;
                ALTER TABLE {Constants.TableName.User} ADD COLUMN IF NOT EXISTS password_hash TEXT;
                ALTER TABLE {Constants.TableName.User} ADD COLUMN IF NOT EXISTS password_salt TEXT;
                ALTER TABLE {Constants.TableName.User} ADD COLUMN IF NOT EXISTS password_iterations INTEGER;

                -- email already carries a UNIQUE index from the constraint, so it needs no second one.
                CREATE INDEX IF NOT EXISTS idx_{Constants.TableName.User}_last_name
                ON {Constants.TableName.User} (last_name);";

            // No catch around the statement: a failure here is the reason the table is missing, and swallowing
            // it used to turn a permission or DDL error into a bare false that named nothing. It propagates to
            // the task that asked for the table, which carries it as its exception and shows it to the operator.
            // Explicitly using NpgsqlCommand type instead of implicit typing
            await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
            npgsqlCommand.CommandTimeout = commandTimeout;

            await npgsqlCommand.ExecuteNonQueryAsync(cancellationToken);
            return true;
        }
    }
}
