namespace RepositoryPatternDemo.Common.Constants
{
    /// <summary>
    /// Defines constants being used across application.
    /// </summary>
    public static class Constants
    {
        #region Error

        /// <summary>
        /// Contains constants for User.
        /// </summary>
        public static class AppError
        {
            public const int ERROR_UNIQUE_CONSTRAINT = 2601;
            public const string ERROR_CONCURRENCY = "DbConcurrencyError";
        }

        #endregion Error
    }
}
