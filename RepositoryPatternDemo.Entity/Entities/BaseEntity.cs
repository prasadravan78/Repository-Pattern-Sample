namespace RepositoryPatternDemo.Entity.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides member for Common Tracking Information and Concurrency.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Is Active .
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or Sets the User Id who creates the Entity
        /// </summary>
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets the Created DateTime for the Entity
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or Sets the User Id who modifies the Entity
        /// </summary>
        [ScaffoldColumn(false)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets the Modified DateTime for the Entity
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime ModificationDate { get; set; }

        /// <summary>
        /// Gets or Sets the the Rowversion Timestamp for Optimistic Concurrency Check
        /// </summary>
        [ScaffoldColumn(false)]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
