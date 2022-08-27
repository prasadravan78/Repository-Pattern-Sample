namespace RepositoryPatternDemo.Common
{
    /// <summary>
    /// Defines constants being used across application.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Contains constants for AppError.
        /// </summary>
        public static class AppError
        {
            /// <summary>
            /// Gets ERRORUNIQUECONSTRAINT.
            /// </summary>
            public const int ERRORUNIQUECONSTRAINT = 2601;

            /// <summary>
            /// Gets ERRORCONCURRENCY.
            /// </summary>
            public const string ERRORCONCURRENCY = "DbConcurrencyError";
        }
    }
}
