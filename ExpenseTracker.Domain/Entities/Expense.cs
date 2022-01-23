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
    public class Expense : BaseModel
    {
        /// <summary>
        /// Primary key of the table Expenses.
        /// </summary>
        [Key]
        public int ExpenseID { get; set; }

        /// <summary>
        /// Date of Expenses
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The Expense Date is required!")]
        [Display(Name = "Expense date")]
        [Column(TypeName = "smalldatetime")]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Expense Amount
        /// </summary>
        [Required(ErrorMessage = "The Amount field is required!")]
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
