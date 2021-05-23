namespace RepositoryPatternDemo.Model.Models
{
    using System;

    /// <summary>
    /// Provides Common Tracking Information and Concurrency.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Is Active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or Sets the User Id who creates the entity.
        /// </summary>       
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets the Created DateTime for the entity.
        /// </summary>       
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or Sets the User Id who modifies the entity.
        /// </summary>       
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets the Modified DateTime for the entity.
        /// </summary>        
        public DateTime ModificationDate { get; set; }

        /// <summary>
        /// Gets or Sets the the Rowversion Timestamp for optimistic concurrency check.
        /// </summary>          
        public byte[] RowVersion { get; set; }
    }
}
