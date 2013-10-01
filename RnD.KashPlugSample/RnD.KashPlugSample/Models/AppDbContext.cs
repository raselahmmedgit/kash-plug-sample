using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RnD.KashPlugSample.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<SaleOrIncome> SaleOrIncomes { get; set; }
        public DbSet<SaleOrIncomeCategory> SaleOrIncomeCategories { get; set; }
        public DbSet<CostsOrExpense> CostsOrExpenses { get; set; }
        public DbSet<CostsOrExpenseCategory> CostsOrExpenseCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class DBInitializer : DropCreateDatabaseAlways<AppDbContext>
    //public class DBInitializer : CreateDatabaseIfNotExists<AppDbContext>
    public class DBInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {

        }
    }

    #endregion
}