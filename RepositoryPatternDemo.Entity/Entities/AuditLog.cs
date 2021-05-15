namespace RepositoryPatternDemo.Entity.Entities
{
    using System;

    /// <summary>
    /// Provides various properties for audit logging.
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets Level.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets Logger.
        /// </summary>
        public string Logger { get; set; }

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets User Name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Controller.
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Gets or sets Action.
        /// </summary>
        public string Action { get; set; }
    }
}
