using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Entities
{
    /// <summary>
    /// Contains common properties for all models.
    /// </summary>

    #region BaseModel
    public class BaseModel
    {
        /// <summary>
        /// Creation Date of the row.
        /// </summary>
        [Column(TypeName = "smalldatetime")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Last modification date of the row.
        /// </summary>
        [Column(TypeName = "smalldatetime")]
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// Indicates the row is deleted or not.
        /// </summary>
        public bool IsRowDeleted { get; set; }
    }
    #endregion
}
