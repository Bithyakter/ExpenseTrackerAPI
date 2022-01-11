using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Entities
{
    /// <summary>
    /// Represents Expense Table
    /// </summary>

    #region Expense
    public class Expense
    {
        /// <summary>
        /// Primary key of the table Expenses.
        /// </summary>
        [Key]
        public int ExpenseID { get; set; }

        /// <summary>
        /// Date of Expenses
        /// </summary>
        [Required(ErrorMessage = "Required!")]
        [Display(Name = "Expense date")]
        [Column(TypeName = "smalldatetime")]
        public DateTime ExpenseDate { get; set; }

        /// <summary>
        /// Expense Amount
        /// </summary>
        [Required(ErrorMessage = "Required!")]
        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Referance of the table ExpenseCategories.
        /// </summary>
        [Display(Name = "Expense category")]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }
    #endregion
}
