namespace RepositoryPatternDemo.DAL.UnitOfWork
{
    using System;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using RepositoryPatternDemo.Common;
    using RepositoryPatternDemo.Common.ExceptionHandling;

    /// <summary>
    /// Manages helper methods for UnitOfWork.
    /// </summary>
    internal static class UnitOfWorkHelpers
    {
        /// <summary>
        /// Handles exception.
        /// </summary>
        /// <param name="exception">Exception.</param>
        public static void HandleException(Exception exception)
        {
            if (exception is DbUpdateConcurrencyException concurrencyEx)
            {
                // A custom exception for concurrency issues.
                throw new CustomException(
                    Constants.AppError.ERRORCONCURRENCY,
                    concurrencyEx);
            }

            if (exception is DbUpdateException dbUpdateEx)
            {
                if (dbUpdateEx.InnerException != null &&
                    dbUpdateEx.InnerException.InnerException != null)
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        throw sqlException.Number switch
                        {
                            // Unique constraint error.
                            2627 => new CustomException("Record is not Unique", sqlException),

                            // Constraint check violation.
                            547 => new CustomException("Constraint Check Violation", sqlException),

                            // Duplicated key row error.
                            // Constraint violation exception.
                            2601 => new CustomException("Constraint Check Violation", sqlException),

                            // A custom exception of yours for other DB issues
                            _ => sqlException,
                        };
                    }

                    throw dbUpdateEx;
                }
            }
        }
    }
}