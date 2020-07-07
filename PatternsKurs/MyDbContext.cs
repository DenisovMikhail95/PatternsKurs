using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PatternsKurs
{
    public class MyDbContext : DbContext
    {
        private static MyDbContext instance;
        private MyDbContext () : base ("DbConnectionString") { }
        public static MyDbContext getInstance()
        {
            if (instance == null)
                instance = new MyDbContext();
            return instance;
        }

        public DbSet<ExpenseCategory> ExpenseCategorys { get; set; } 
        public DbSet<IncomeCategory> IncomeCategorys { get; set; }
        public DbSet<Valuta> Valutas { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<RemindType> RemindTypes { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<IncomeSubcategory> IncomeSubcategorys { get; set; }
        public DbSet<ExpenseSubcategory> ExpenseSubcategorys { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }

    }
}
