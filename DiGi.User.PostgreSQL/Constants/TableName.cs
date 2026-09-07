namespace DiGi.User.PostgreSQL.Constants
{
    /// <summary>
    /// Provides constant values for database table names used in the PostgreSQL User system.
    /// </summary>
    public static class TableName
    {
        /// <summary>
        /// The name of the user table. One row is a single user, addressed by its unique email.
        /// </summary>
        public const string User = "users";
    }
}
