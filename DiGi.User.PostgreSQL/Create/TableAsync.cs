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
        /// Asynchronously creates the users table in the PostgreSQL database if it does not already exist.
        /// <para>Every statement is idempotent (<c>IF NOT EXISTS</c>), so the method is safe to run on every
        /// write and read path, mirroring the create-then-act pattern used by the converter.</para>
        /// </summary>
        /// <param name="npgsqlConnection">The <see cref="NpgsqlConnection"/> instance used to execute the command.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the table was created successfully; otherwise, false.</returns>
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
                    object JSONB,
                    created_at timestamptz DEFAULT now(),
                    updated_at timestamptz DEFAULT now()
                );

                -- email already carries a UNIQUE index from the constraint, so it needs no second one.
                CREATE INDEX IF NOT EXISTS idx_{Constants.TableName.User}_last_name
                ON {Constants.TableName.User} (last_name);";

            try
            {
                // Explicitly using NpgsqlCommand type instead of implicit typing
                await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
                npgsqlCommand.CommandTimeout = commandTimeout;

                await npgsqlCommand.ExecuteNonQueryAsync(cancellationToken);
                return true;
            }
            catch (NpgsqlException)
            {
                return false;
            }
        }
    }
}
