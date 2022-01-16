using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.SqlServer
{
    public class DataContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "Data Source=URANUS; Initial Catalog=ExpenseWebAPIDB; User Id=sa; Password=abcd123!";

        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// Expense table.
        /// </summary>
        public DbSet<Expense> Expenses { get; set; }

        /// <summary>
        /// ExpenseCategories table.
        /// </summary>
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    }
}

