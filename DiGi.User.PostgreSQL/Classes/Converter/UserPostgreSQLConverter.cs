using DiGi.PostgreSQL.Classes;
using DiGi.User.PostgreSQL.Interfaces;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.User.PostgreSQL.Classes
{
    // The simple name `User` otherwise resolves to the `DiGi.User` namespace (innermost-namespace shadowing,
    // Coding - General.md §1.9), so the type is bound through an alias to keep the call sites readable.
    using User = DiGi.User.Classes.User;
    using UserCredential = DiGi.User.Classes.UserCredential;

    /// <summary>
    /// Provides functionality to convert and manage <see cref="User"/> entities within a PostgreSQL database,
    /// implementing the <see cref="IUserPostgreSQLConverter"/> interface.
    /// <para>The natural key of a user is its unique email. Writes are upserts against that key, so storing
    /// a user read back from the database replaces its own row rather than creating a duplicate.</para>
    /// </summary>
    public class UserPostgreSQLConverter : PostgreSQLConverter<User>, IUserPostgreSQLConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPostgreSQLConverter"/> class.
        /// </summary>
        /// <param name="connectionData">The <see cref="ConnectionData"/> containing database connection settings.</param>
        public UserPostgreSQLConverter(ConnectionData? connectionData)
            : base(connectionData)
        {
        }

        /// <summary>
        /// Gets the name of the database table associated with users.
        /// </summary>
        public static string TableName => Constants.TableName.User;

        /// <summary>
        /// Asynchronously creates the users table in the database if it does not already exist.
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the table was created successfully; otherwise, false.</returns>
        public static async Task<bool> CreateTableAsync(NpgsqlConnection? npgsqlConnection, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null)
            {
                return false;
            }

            return await Create.TableAsync_User(npgsqlConnection, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates the users table in the database if it does not already exist, managing the connection.
        /// </summary>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the table was created successfully; otherwise, false.</returns>
        public async Task<bool> CreateTableAsync(int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return false;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await CreateTableAsync(npgsqlConnection, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously clears all records from the users table.
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the table was cleared successfully; otherwise, false.</returns>
        public static async Task<bool> ClearAsync(NpgsqlConnection? npgsqlConnection, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null)
            {
                return false;
            }

            return await DiGi.PostgreSQL.Modify.ClearAsync(npgsqlConnection, TableName, commandTimeout: commandTimeout, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Asynchronously clears all records from the users table, managing the connection.
        /// </summary>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the table was cleared successfully; otherwise, false.</returns>
        public async Task<bool> ClearAsync(int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return false;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await ClearAsync(npgsqlConnection, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously inserts or updates a collection of <see cref="User"/> entities in the database in batches.
        /// <para>Users are upserted against the unique email key, so a user that is already stored has its row
        /// refreshed rather than duplicated. The <c>ON CONFLICT DO UPDATE</c> clause names its columns explicitly and the
        /// credential columns are not among them, so re-inserting a user leaves an existing password credential intact.</para>
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="users">The collection of users to insert or update.</param>
        /// <param name="batchSize">The maximum number of users per batch command.</param>
        /// <param name="commandTimeout">The timeout in seconds for the command execution.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of user identifiers successfully inserted or updated.</returns>
        public static async Task<List<string>> InsertAsync(NpgsqlConnection? npgsqlConnection, IEnumerable<User>? users, int batchSize = 1000, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null || users is null)
            {
                return [];
            }

            // email is the natural key and must be present for a row to be addressable.
            List<User> userList = [.. users.Where(user => user is not null && !string.IsNullOrWhiteSpace(user.Email))];
            if (userList.Count == 0)
            {
                return [];
            }

            bool tableCreated = await CreateTableAsync(npgsqlConnection, commandTimeout, cancellationToken);
            if (!tableCreated)
            {
                return [];
            }

            List<string> insertedIds = [];

            for (int i = 0; i < userList.Count; i += batchSize)
            {
                cancellationToken.ThrowIfCancellationRequested();

                List<User> chunk = userList.Skip(i).Take(batchSize).ToList();

                await using NpgsqlBatch npgsqlBatch = new(npgsqlConnection);
                npgsqlBatch.Timeout = commandTimeout;

                foreach (User user in chunk)
                {
                    string? objectJson = user.ToJsonObject()?.ToJsonString();

                    NpgsqlBatchCommand batchCommand = new($@"
                        INSERT INTO {TableName} (email, first_name, last_name, level, object, updated_at)
                        VALUES (@email, @firstName, @lastName, @level, @object, now())
                        ON CONFLICT (email)
                        DO UPDATE SET
                            first_name = EXCLUDED.first_name,
                            last_name = EXCLUDED.last_name,
                            level = EXCLUDED.level,
                            object = EXCLUDED.object,
                            updated_at = now()
                        RETURNING id;");

                    batchCommand.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Text) { Value = user.Email });
                    batchCommand.Parameters.Add(new NpgsqlParameter("firstName", NpgsqlDbType.Text) { Value = (object?)user.FirstName ?? DBNull.Value });
                    batchCommand.Parameters.Add(new NpgsqlParameter("lastName", NpgsqlDbType.Text) { Value = (object?)user.LastName ?? DBNull.Value });
                    batchCommand.Parameters.Add(new NpgsqlParameter("level", NpgsqlDbType.Integer) { Value = user.Level });
                    batchCommand.Parameters.Add(new NpgsqlParameter("object", NpgsqlDbType.Jsonb) { Value = (object?)objectJson ?? DBNull.Value });

                    npgsqlBatch.BatchCommands.Add(batchCommand);
                }

                await using NpgsqlDataReader reader = await npgsqlBatch.ExecuteReaderAsync(cancellationToken);
                do
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        insertedIds.Add(reader.GetInt32(0).ToString());
                    }
                }
                while (await reader.NextResultAsync(cancellationToken));
            }

            return insertedIds;
        }

        /// <summary>
        /// Asynchronously inserts or updates a collection of <see cref="User"/> entities in the database, managing the connection.
        /// <para>Users are upserted against the unique email key, and an existing password credential is left intact.</para>
        /// </summary>
        /// <param name="users">The collection of users to insert or update.</param>
        /// <param name="batchSize">The maximum number of users per batch command.</param>
        /// <param name="commandTimeout">The timeout in seconds for the command execution.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of user identifiers successfully inserted or updated.</returns>
        public async Task<List<string>> InsertAsync(IEnumerable<User>? users, int batchSize = 1000, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return [];
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await InsertAsync(npgsqlConnection, users, batchSize, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves all users from the database.
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of <see cref="User"/> entities, or null if the connection is null.</returns>
        public static async Task<List<User>?> GetUsersAsync(NpgsqlConnection? npgsqlConnection, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null)
            {
                return null;
            }

            string commandText = $@"
                SELECT email, first_name, last_name, level
                FROM {TableName}
                ORDER BY last_name ASC NULLS LAST, first_name ASC NULLS LAST, email ASC;";

            await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
            npgsqlCommand.CommandTimeout = commandTimeout;

            return await ReadAsync_User(npgsqlCommand, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves all users from the database, managing the connection.
        /// </summary>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of <see cref="User"/> entities, or null if a connection cannot be established.</returns>
        public async Task<List<User>?> GetUsersAsync(int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return null;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await GetUsersAsync(npgsqlConnection, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves a user by their unique email.
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="User"/> if found; otherwise, null.</returns>
        public static async Task<User?> GetUserByEmailAsync(NpgsqlConnection? npgsqlConnection, string? email, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null || string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            string commandText = $@"
                SELECT email, first_name, last_name, level
                FROM {TableName}
                WHERE email = @email
                LIMIT 1;";

            await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
            npgsqlCommand.CommandTimeout = commandTimeout;
            npgsqlCommand.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Text) { Value = email });

            List<User>? users = await ReadAsync_User(npgsqlCommand, cancellationToken);
            return users?.FirstOrDefault();
        }

        /// <summary>
        /// Asynchronously retrieves a user by their unique email, managing the connection.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="User"/> if found; otherwise, null.</returns>
        public async Task<User?> GetUserByEmailAsync(string? email, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return null;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await GetUserByEmailAsync(npgsqlConnection, email, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves users matching a collection of email addresses in batched queries.
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="emails">The collection of email addresses to retrieve.</param>
        /// <param name="batchSize">The maximum number of email addresses to query per batch.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of matching <see cref="User"/> entities, or null if the connection is null.</returns>
        public static async Task<List<User>?> GetUsersByEmailsAsync(NpgsqlConnection? npgsqlConnection, IEnumerable<string>? emails, int batchSize = 1000, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null || emails is null)
            {
                return null;
            }

            List<string> emailList = [.. emails.Where(email => !string.IsNullOrWhiteSpace(email))];
            if (emailList.Count == 0)
            {
                return [];
            }

            List<User> users_Result = [];

            for (int i = 0; i < emailList.Count; i += batchSize)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string[] emailChunk = emailList.Skip(i).Take(batchSize).ToArray();

                string commandText = $@"
                    SELECT email, first_name, last_name, level
                    FROM {TableName}
                    WHERE email = ANY(@emails)
                    ORDER BY last_name ASC NULLS LAST, first_name ASC NULLS LAST, email ASC;";

                await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
                npgsqlCommand.CommandTimeout = commandTimeout;
                npgsqlCommand.Parameters.Add(new NpgsqlParameter("emails", NpgsqlDbType.Array | NpgsqlDbType.Text) { Value = emailChunk });

                List<User>? chunkResult = await ReadAsync_User(npgsqlCommand, cancellationToken);
                if (chunkResult is not null)
                {
                    users_Result.AddRange(chunkResult);
                }
            }

            return users_Result;
        }

        /// <summary>
        /// Asynchronously retrieves users matching a collection of email addresses, managing the connection.
        /// </summary>
        /// <param name="emails">The collection of email addresses to retrieve.</param>
        /// <param name="batchSize">The maximum number of email addresses to query per batch.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of matching <see cref="User"/> entities, or null if a connection cannot be established.</returns>
        public async Task<List<User>?> GetUsersByEmailsAsync(IEnumerable<string>? emails, int batchSize = 1000, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return null;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await GetUsersByEmailsAsync(npgsqlConnection, emails, batchSize, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves users matching the specified last name (case-insensitive search).
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="lastName">The last name or part of the last name to search for.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of matching <see cref="User"/> entities, or null if the connection is null or the name is empty.</returns>
        public static async Task<List<User>?> GetUsersByLastNameAsync(NpgsqlConnection? npgsqlConnection, string? lastName, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null || string.IsNullOrWhiteSpace(lastName))
            {
                return null;
            }

            string commandText = $@"
                SELECT email, first_name, last_name, level
                FROM {TableName}
                WHERE last_name ILIKE @lastName
                ORDER BY last_name ASC, first_name ASC NULLS LAST, email ASC;";

            await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
            npgsqlCommand.CommandTimeout = commandTimeout;
            npgsqlCommand.Parameters.Add(new NpgsqlParameter("lastName", NpgsqlDbType.Text) { Value = $"%{lastName}%" });

            return await ReadAsync_User(npgsqlCommand, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves users matching the specified last name, managing the connection.
        /// </summary>
        /// <param name="lastName">The last name or part of the last name to search for.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of matching <see cref="User"/> entities, or null if a connection cannot be established or the name is empty.</returns>
        public async Task<List<User>?> GetUsersByLastNameAsync(string? lastName, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return null;
            }

            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return null;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await GetUsersByLastNameAsync(npgsqlConnection, lastName, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves a user by their surrogate identifier.
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="id">The surrogate identifier of the user.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="User"/> if found; otherwise, null.</returns>
        public static async Task<User?> GetUserByIdAsync(NpgsqlConnection? npgsqlConnection, int id, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null)
            {
                return null;
            }

            string commandText = $@"
                SELECT email, first_name, last_name, level
                FROM {TableName}
                WHERE id = @id
                LIMIT 1;";

            await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
            npgsqlCommand.CommandTimeout = commandTimeout;
            npgsqlCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer) { Value = id });

            List<User>? users = await ReadAsync_User(npgsqlCommand, cancellationToken);
            return users?.FirstOrDefault();
        }

        /// <summary>
        /// Asynchronously retrieves a user by their surrogate identifier, managing the connection.
        /// </summary>
        /// <param name="id">The surrogate identifier of the user.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="User"/> if found; otherwise, null.</returns>
        public async Task<User?> GetUserByIdAsync(int id, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return null;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await GetUserByIdAsync(npgsqlConnection, id, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves the stored password credential of a user by their unique email.
        /// <para>The credential is read from its own columns rather than from the <c>object</c> payload, so it never travels
        /// with the <see cref="User"/> returned by the other read operations.</para>
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="UserCredential"/> if the user exists and has a complete credential; otherwise, null.</returns>
        public static async Task<UserCredential?> GetUserCredentialAsync(NpgsqlConnection? npgsqlConnection, string? email, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null || string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            string commandText = $@"
                SELECT email, password_hash, password_salt, password_iterations
                FROM {TableName}
                WHERE email = @email
                LIMIT 1;";

            await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
            npgsqlCommand.CommandTimeout = commandTimeout;
            npgsqlCommand.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Text) { Value = email });

            await using NpgsqlDataReader reader = await npgsqlCommand.ExecuteReaderAsync(cancellationToken);
            if (!await reader.ReadAsync(cancellationToken))
            {
                return null;
            }

            // An account whose credential was never set must not be loggable, so a partially populated row reads
            // as no credential at all rather than as one that happens to verify against nothing.
            if (reader.IsDBNull(1) || reader.IsDBNull(2) || reader.IsDBNull(3))
            {
                return null;
            }

            return new UserCredential(reader.IsDBNull(0) ? null : reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
        }

        /// <summary>
        /// Asynchronously retrieves the stored password credential of a user by their unique email, managing the connection.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="UserCredential"/> if the user exists and has a complete credential; otherwise, null.</returns>
        public async Task<UserCredential?> GetUserCredentialAsync(string? email, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return null;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await GetUserCredentialAsync(npgsqlConnection, email, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously stores the password credential of an existing user.
        /// <para>This updates and never inserts: the user row addressed by <see cref="UserCredential.Email"/> must already
        /// exist, so a credential can never bring an otherwise unknown account into being.</para>
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="userCredential">The credential to store.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the credential was stored against an existing user; otherwise, false.</returns>
        public static async Task<bool> SetUserCredentialAsync(NpgsqlConnection? npgsqlConnection, UserCredential? userCredential, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null || userCredential is null || string.IsNullOrWhiteSpace(userCredential.Email))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(userCredential.PasswordHash) || string.IsNullOrWhiteSpace(userCredential.PasswordSalt) || userCredential.PasswordIterations <= 0)
            {
                return false;
            }

            // A write path migrates the table, matching InsertAsync. The credential columns do not exist on a
            // database whose users table predates them, and this is where they are added.
            bool tableCreated = await CreateTableAsync(npgsqlConnection, commandTimeout, cancellationToken);
            if (!tableCreated)
            {
                return false;
            }

            string commandText = $@"
                UPDATE {TableName}
                SET password_hash = @passwordHash,
                    password_salt = @passwordSalt,
                    password_iterations = @passwordIterations,
                    updated_at = now()
                WHERE email = @email;";

            await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
            npgsqlCommand.CommandTimeout = commandTimeout;
            npgsqlCommand.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Text) { Value = userCredential.Email });
            npgsqlCommand.Parameters.Add(new NpgsqlParameter("passwordHash", NpgsqlDbType.Text) { Value = userCredential.PasswordHash });
            npgsqlCommand.Parameters.Add(new NpgsqlParameter("passwordSalt", NpgsqlDbType.Text) { Value = userCredential.PasswordSalt });
            npgsqlCommand.Parameters.Add(new NpgsqlParameter("passwordIterations", NpgsqlDbType.Integer) { Value = userCredential.PasswordIterations });

            return await npgsqlCommand.ExecuteNonQueryAsync(cancellationToken) > 0;
        }

        /// <summary>
        /// Asynchronously stores the password credential of an existing user, managing the connection.
        /// </summary>
        /// <param name="userCredential">The credential to store.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the credential was stored against an existing user; otherwise, false.</returns>
        public async Task<bool> SetUserCredentialAsync(UserCredential? userCredential, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (userCredential is null)
            {
                return false;
            }

            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return false;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await SetUserCredentialAsync(npgsqlConnection, userCredential, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously deletes a user by their unique email.
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="email">The email address of the user to delete.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of rows deleted, or -1 if the connection is null or the email is empty.</returns>
        public static async Task<int> DeleteUserByEmailAsync(NpgsqlConnection? npgsqlConnection, string? email, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null || string.IsNullOrWhiteSpace(email))
            {
                return -1;
            }

            string commandText = $@"
                DELETE FROM {TableName}
                WHERE email = @email;";

            await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
            npgsqlCommand.CommandTimeout = commandTimeout;
            npgsqlCommand.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Text) { Value = email });

            return await npgsqlCommand.ExecuteNonQueryAsync(cancellationToken);
        }

        /// <summary>
        /// Asynchronously deletes a user by their unique email, managing the connection.
        /// </summary>
        /// <param name="email">The email address of the user to delete.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of rows deleted, or -1 if a connection cannot be established or the email is empty.</returns>
        public async Task<int> DeleteUserByEmailAsync(string? email, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return -1;
            }

            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return -1;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await DeleteUserByEmailAsync(npgsqlConnection, email, commandTimeout, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves the number of users stored in the database.
        /// </summary>
        /// <param name="npgsqlConnection">The active <see cref="NpgsqlConnection"/>.</param>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of stored users, or -1 if the connection is null.</returns>
        public static async Task<int> GetUserCountAsync(NpgsqlConnection? npgsqlConnection, int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            if (npgsqlConnection is null)
            {
                return -1;
            }

            string commandText = $@"
                SELECT COUNT(*)::int
                FROM {TableName};";

            await using NpgsqlCommand npgsqlCommand = new(commandText, npgsqlConnection);
            npgsqlCommand.CommandTimeout = commandTimeout;

            object? result = await npgsqlCommand.ExecuteScalarAsync(cancellationToken);
            if (result is null || result == DBNull.Value)
            {
                return -1;
            }

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Asynchronously retrieves the number of users stored in the database, managing the connection.
        /// </summary>
        /// <param name="commandTimeout">The timeout in seconds for the execution of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of stored users, or -1 if a connection cannot be established.</returns>
        public async Task<int> GetUserCountAsync(int commandTimeout = 30, CancellationToken cancellationToken = default)
        {
            await using NpgsqlConnection? npgsqlConnection = DiGi.PostgreSQL.Create.NpgsqlConnection(ConnectionData);
            if (npgsqlConnection is null)
            {
                return -1;
            }

            await npgsqlConnection.OpenAsync(cancellationToken);
            return await GetUserCountAsync(npgsqlConnection, commandTimeout, cancellationToken);
        }

        private static async Task<List<User>?> ReadAsync_User(NpgsqlCommand npgsqlCommand, CancellationToken cancellationToken)
        {
            await using NpgsqlDataReader reader = await npgsqlCommand.ExecuteReaderAsync(cancellationToken);
            List<User> users_Result = [];

            while (await reader.ReadAsync(cancellationToken))
            {
                User user = new(reader.IsDBNull(0) ? null : reader.GetString(0))
                {
                    FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                    LastName = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Level = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                };

                users_Result.Add(user);
            }

            return users_Result;
        }
    }
}
