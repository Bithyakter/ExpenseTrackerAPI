using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Contracts;
using ExpenseTracker.Infrastructure.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    /// <summary>
    /// Implements IUnitOfWork interface.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private IExpenseCategoryRepository expenseCategoryRepository;
        private IExpenseRepository expenseRepository;

        protected readonly DataContext dbcontext;
        public UnitOfWork(DataContext context)
        {
            this.dbcontext = context;
        }
        public void SaveChanges()
        {
            dbcontext.SaveChanges();
        }

        public IExpenseCategoryRepository ExpenseCategoryRepository
        {
            get
            {
                if (expenseCategoryRepository == null)
                    expenseCategoryRepository = new ExpenseCategoryRepository(dbcontext);

                return expenseCategoryRepository;
            }
            
        }

        public IExpenseRepository ExpenseRepository
        {
            get
            {
                if (expenseRepository == null)
                    expenseRepository = new ExpenseRepository(dbcontext);

                return expenseRepository;
            }
        }
    }
}
