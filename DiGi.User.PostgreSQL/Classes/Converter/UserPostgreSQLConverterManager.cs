using DiGi.User.PostgreSQL.Interfaces;

namespace DiGi.User.PostgreSQL.Classes
{
    /// <summary>
    /// Manages the conversion processes specifically for User data within a PostgreSQL database context.
    /// </summary>
    public class UserPostgreSQLConverterManager : DiGi.PostgreSQL.Classes.PostgreSQLConverterManager<IUserPostgreSQLConverter>
    {
    }
}
