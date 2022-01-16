using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Web.Models
{
    public class ExpenseDTO
    {
        public int ExpenseID { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
    }
}
