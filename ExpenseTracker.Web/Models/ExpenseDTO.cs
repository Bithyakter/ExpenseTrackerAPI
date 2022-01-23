using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Web.Models
{
    public class ExpenseDTO : BaseDTO
    {
        public int ExpenseID { get; set; }
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "The Expense Date field is required!")]
        [Display(Name = "Expense date")]
        [Column(TypeName = "smalldatetime")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "The Amount field is required!")]
        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please select Category!")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public List<ExpenseCategoryDTO> CategoryDropDownList { get; set; }
        public virtual ExpenseCategoryDTO ExpenseCategory { get; set; }
    }
}
