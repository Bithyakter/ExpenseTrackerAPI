using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.ViewModel;
using ExpenseTracker.Infrastructure.Contracts;
using ExpenseTracker.Infrastructure.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class ExpenseCategoryRepository : Repository<ExpenseCategory>, IExpenseCategoryRepository
    {
        private readonly DataContext _context;
        public ExpenseCategoryRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

        public IList<ExpenseCategoryVM> GetAllCategory()
        {
            var list = (from a in _context.ExpenseCategories
                        where a.IsRowDeleted.Equals(false)
                        select new ExpenseCategoryVM
                        {
                            CategoryName = a.CategoryName 
                        }).ToList();
            return list;
        }

        public bool IsDeleteID(int categoryId)
        {
            var DeleteID = _context.Expenses.FirstOrDefault(c => c.CategoryID == categoryId && !c.IsRowDeleted);
            if (DeleteID != null)
            {
                return true;
            }
            return false;
        }

        #region IsExpenseCategoryDuplicate
        public bool IsExpenseCategoryDuplicate(ExpenseCategory expenseCategory)
        {
            try
            {
                var catInDb = _context.ExpenseCategories.FirstOrDefault(c => c.CategoryName.ToLower().Replace(" ", "-") == expenseCategory.CategoryName.ToLower().Replace(" ", "-") && !c.IsRowDeleted);

                if (catInDb != null)
                {
                    //if (catInDb.CategoryID != expenseCategory.CategoryID)
                        return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion
 
    }
}
