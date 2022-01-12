using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Contracts;
using ExpenseTracker.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        //private DbContext _db;
        //private DbSet<Expense> Expenses;

        //public ExpenseRepository(DbContext db)
        //{
        //    this._db = db;
        //    Expenses = _db.Set<Expense>();
        //}

        public ExpenseRepository(DataContext context) : base(context)
        {
            
        }

        public IEnumerable<Expense> getAllEnpenses()
        {
            //return Expense.AsNoTracking().AsEnumerable();
            return _context.Set<Expense>().AsQueryable().AsNoTracking().ToList();
        }

        //public void DeleteExpense(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Expense GetExpenses(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SaveExpenses(Expense expences)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
