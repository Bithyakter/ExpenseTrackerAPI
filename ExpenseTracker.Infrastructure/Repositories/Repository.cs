using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Contracts;
using ExpenseTracker.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    /// <summary>
    /// Implements IRepository interface.
    /// </summary>
    /// <typeparam name="T">T is a model class</typeparam>

    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly DataContext _context;
        public Repository(DataContext context)
        {
            this._context = context;
        }

        public virtual T Add(T entity)
        {
            try
            {
                entity.IsRowDeleted = false;
                entity.DateCreated = DateTime.Now;
                return _context.Set<T>().Add(entity).Entity;
            }
            catch
            {
                throw;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                entity.IsRowDeleted = true;
                entity.DateModified = DateTime.Now;
                _context.Set<T>().Update(entity);
            }
            catch
            {
                throw;
            }

        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>()
                    .AsNoTracking().Where(x => x.IsRowDeleted.Equals(false))
                    .FirstOrDefault(predicate);
            }
            catch
            {
                throw;
            }
        }
        public virtual T Get(int id)
        {
            try
            {
                return _context.Set<T>().Find(id);
                ;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>()
                    .AsQueryable()
                    .AsNoTracking().Where(x => x.IsRowDeleted.Equals(false))
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>()
                    .AsQueryable()
                    .AsNoTracking().Where(x => x.IsRowDeleted.Equals(false))
                    .Where(predicate)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public T Update(T entity)
        {
            try
            {
                entity.IsRowDeleted = false;
                entity.DateModified = DateTime.Now;
                return _context.Set<T>().Update(entity).Entity;
            }
            catch
            {
                throw;
            }

        }

        //public IEnumerable<Expense> GetSearchResult(string searchString)
        //{
        //    List<Expense> exp = new List<Expense>();
        //    try
        //    {
        //        exp = GetAll().ToList();
        //        return exp.Where(x => x.ExpenseType.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }

}
