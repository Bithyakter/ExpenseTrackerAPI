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
        protected readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private IExpenseCategoryRepository expenseCategoryRepository;
        public IExpenseCategoryRepository ExpenseCategoryRepository
        {
            get
            {
                if (expenseCategoryRepository == null)
                    expenseCategoryRepository = new ExpenseCategoryRepository(_context);

                return expenseCategoryRepository;
            }
        }     
    }
}
