namespace DiGi.User.PostgreSQL.Interfaces
{
    /// <summary>
    /// Defines the contract for a User-specific PostgreSQL converter.
    /// </summary>
    public interface IUserPostgreSQLConverter : DiGi.PostgreSQL.Interfaces.IPostgreSQLConverter, IUserPostgreSQLObject
    {
    }
}
