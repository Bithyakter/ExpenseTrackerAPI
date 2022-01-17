using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Contracts
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Declare SaveChanges method
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Create properties for Expense
        /// </summary>
        IExpenseRepository ExpenseRepository { get; }

        /// <summary>
        /// Create properties for Expense categories
        /// </summary>
        IExpenseCategoryRepository ExpenseCategoryRepository { get; }
    }
}
