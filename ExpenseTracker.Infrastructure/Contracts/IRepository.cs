using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Contracts
{
    /// <summary>
    /// Contains signature of all generic methods.
    /// </summary>
    /// <typeparam name="T">T is a Model class</typeparam>

    #region IRepository
    public interface IRepository<T>
    {
        /// <summary>
        ///  Inserts information available in the given object.
        /// </summary>
        /// <param name="entity">Object name</param>
        /// <returns>Inserted object</returns>
        T Add(T entity);

        /// <summary>
        /// Deletes the given object.
        /// </summary>
        /// <param name="entity">Delete to be removed</param>
        void Delete(T entity);

        /// <summary>
        /// Searches using primary key.
        /// </summary>
        /// <param name="Key">Primary Key of the Table</param>
        /// <returns>Retrieved row in the form of model object.</returns>
        T Get(int key);

        /// <summary>
        ///  Loads all rows from the database table.
        /// </summary>
        /// <returns>Object list.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Searches using the given criteria.
        /// </summary>
        /// <param name="predicate">Search criteria.</param>
        /// <returns>Object list.</returns>
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Searches using the given criteria.
        /// </summary>
        /// <param name="predicate">Search criteria.</param>
        /// <returns>Retrieved row in the form of model object.</returns>
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Updates database table with the information available in the given object.
        /// </summary>
        /// <param name="entity">Object to be updated.</param>
        T Update(T entity);

        //IEnumerable<Expense> GetSearchResult(string searchString);
    }
    #endregion
}
