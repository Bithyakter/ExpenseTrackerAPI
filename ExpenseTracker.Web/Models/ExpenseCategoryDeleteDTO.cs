using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Models
{
    public class ExpenseCategoryDeleteDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName{ get; set; }
    }
}
