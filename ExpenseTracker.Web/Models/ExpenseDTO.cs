using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Web.Models
{
    public class ExpenseDTO : BaseDTO
    {
        public int ExpenseID { get; set; }
        public int CategoryID { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
        public List<ExpenseCategoryDTO> CategoryDropDownList { get; set; }
        public virtual ExpenseCategoryDTO ExpenseCategory { get; set; }
    }
}
