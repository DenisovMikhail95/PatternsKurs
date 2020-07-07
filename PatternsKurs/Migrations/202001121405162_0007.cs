namespace PatternsKurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0007 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "ExpenseCategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.Incomes", "IncomeCategoryId", "dbo.IncomeCategories");
            DropIndex("dbo.Expenses", new[] { "ExpenseCategoryId" });
            DropIndex("dbo.Incomes", new[] { "IncomeCategoryId" });
            AddColumn("dbo.Expenses", "ExpenseSubcategoryId", c => c.Int());
            AddColumn("dbo.Incomes", "IncomeSubcategoryId", c => c.Int());
            CreateIndex("dbo.Expenses", "ExpenseSubcategoryId");
            CreateIndex("dbo.Incomes", "IncomeSubcategoryId");
            AddForeignKey("dbo.Expenses", "ExpenseSubcategoryId", "dbo.ExpenseSubcategories", "Id");
            AddForeignKey("dbo.Incomes", "IncomeSubcategoryId", "dbo.IncomeSubcategories", "Id");
            DropColumn("dbo.Expenses", "ExpenseCategoryId");
            DropColumn("dbo.Incomes", "IncomeCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incomes", "IncomeCategoryId", c => c.Int());
            AddColumn("dbo.Expenses", "ExpenseCategoryId", c => c.Int());
            DropForeignKey("dbo.Incomes", "IncomeSubcategoryId", "dbo.IncomeSubcategories");
            DropForeignKey("dbo.Expenses", "ExpenseSubcategoryId", "dbo.ExpenseSubcategories");
            DropIndex("dbo.Incomes", new[] { "IncomeSubcategoryId" });
            DropIndex("dbo.Expenses", new[] { "ExpenseSubcategoryId" });
            DropColumn("dbo.Incomes", "IncomeSubcategoryId");
            DropColumn("dbo.Expenses", "ExpenseSubcategoryId");
            CreateIndex("dbo.Incomes", "IncomeCategoryId");
            CreateIndex("dbo.Expenses", "ExpenseCategoryId");
            AddForeignKey("dbo.Incomes", "IncomeCategoryId", "dbo.IncomeCategories", "Id");
            AddForeignKey("dbo.Expenses", "ExpenseCategoryId", "dbo.ExpenseCategories", "Id");
        }
    }
}
