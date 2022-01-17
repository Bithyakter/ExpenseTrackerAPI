using System;
using System.Collections.Generic;

namespace ExpenseTracker.Web.Models
{
    public class ExpenseCategoryDTO
    {
        public int ExpenseID { get; set; }
        public int CategoryID { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
        public List<ExpenseDTO> CategoryList { get; set; }
    }
}
