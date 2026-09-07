using DiGi.PostgreSQL.Classes;
using DiGi.User.PostgreSQL.Classes;
using System.IO;
using System.Reflection;

namespace DiGi.User.PostgreSQL
{
    public static partial class Create
    {
        /// <summary>
        /// Creates a <see cref="UserPostgreSQLConverterManager"/> with all PostgreSQL converters registered.
        /// Reads the connection configuration from the <c>PostgreSQL_Main</c> file in the executing assembly's directory.
        /// <para>
        /// IMPORTANT: Every converter consumed by a User WebAPI controller MUST be registered here.
        /// The WebAPI <c>InitializeAsync</c> reads converters from the returned manager and adds them to the DI container.
        /// A missing registration causes the controller's converter dependency to be <see langword="null"/>,
        /// resulting in a 500 Internal Server Error at runtime.
        /// </para>
        /// </summary>
        /// <returns>A configured <see cref="UserPostgreSQLConverterManager"/> if successful; otherwise, null.</returns>
        public static UserPostgreSQLConverterManager? UserPostgreSQLConverterManager()
        {
            string? directory_ExecutingAssembly = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (string.IsNullOrWhiteSpace(directory_ExecutingAssembly) || !Directory.Exists(directory_ExecutingAssembly))
            {
                return null;
            }

            UserPostgreSQLConverterManager result = new();

            string path = Path.Combine(directory_ExecutingAssembly, Constants.FileName.PostgreSQL_Main);
            if (!string.IsNullOrWhiteSpace(path) && Path.Exists(path) && DiGi.PostgreSQL.Create.PostgreSQLConfigurationFile(path) is PostgreSQLConfigurationFile postgreSQLConfigurationFile_Main)
            {
                ConnectionData? connectionData = DiGi.PostgreSQL.Create.ConnectionData(postgreSQLConfigurationFile_Main);
                if (connectionData is not null)
                {
                    result.Add(new UserPostgreSQLConverter(connectionData), postgreSQLConfigurationFile_Main);
                }
            }

            return result;
        }
    }
}
