using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Web.Models
{
    public class ExpenseCategoryDTO : BaseDTO
    {
        public int ExpenseID { get; set; }
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "The Expense Date is required!")]
        [Display(Name = "Expense date")]
        [Column(TypeName = "smalldatetime")]
        public DateTime ExpenseDate { get; set; }

        [Required(ErrorMessage = "The Amount field is required!")]
        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "The Category Name field is required!")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public bool IsDuplicateFound { get; set; }
        public List<ExpenseDTO> CategoryList { get; set; }
    }
}
