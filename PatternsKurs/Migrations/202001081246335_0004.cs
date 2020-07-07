namespace PatternsKurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SumInValuta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumInRub = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        ExpenseCategoryId = c.Int(),
                        AccountId = c.Int(),
                        ValutaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategoryId)
                .ForeignKey("dbo.Valutas", t => t.ValutaId)
                .Index(t => t.ExpenseCategoryId)
                .Index(t => t.AccountId)
                .Index(t => t.ValutaId);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SumInValuta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumInRub = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        IncomeCategoryId = c.Int(),
                        AccountId = c.Int(),
                        ValutaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.IncomeCategories", t => t.IncomeCategoryId)
                .ForeignKey("dbo.Valutas", t => t.ValutaId)
                .Index(t => t.IncomeCategoryId)
                .Index(t => t.AccountId)
                .Index(t => t.ValutaId);
            
            AddColumn("dbo.Transfers", "ValutaId", c => c.Int());
            CreateIndex("dbo.Transfers", "ValutaId");
            AddForeignKey("dbo.Transfers", "ValutaId", "dbo.Valutas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "ValutaId", "dbo.Valutas");
            DropForeignKey("dbo.Incomes", "ValutaId", "dbo.Valutas");
            DropForeignKey("dbo.Incomes", "IncomeCategoryId", "dbo.IncomeCategories");
            DropForeignKey("dbo.Incomes", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Expenses", "ValutaId", "dbo.Valutas");
            DropForeignKey("dbo.Expenses", "ExpenseCategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.Expenses", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Transfers", new[] { "ValutaId" });
            DropIndex("dbo.Incomes", new[] { "ValutaId" });
            DropIndex("dbo.Incomes", new[] { "AccountId" });
            DropIndex("dbo.Incomes", new[] { "IncomeCategoryId" });
            DropIndex("dbo.Expenses", new[] { "ValutaId" });
            DropIndex("dbo.Expenses", new[] { "AccountId" });
            DropIndex("dbo.Expenses", new[] { "ExpenseCategoryId" });
            DropColumn("dbo.Transfers", "ValutaId");
            DropTable("dbo.Incomes");
            DropTable("dbo.Expenses");
        }
    }
}
