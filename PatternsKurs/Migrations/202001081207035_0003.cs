namespace PatternsKurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FamilyMemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyMembers", t => t.FamilyMemberId)
                .Index(t => t.FamilyMemberId);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        RemindTypeId = c.Int(),
                        FamilyMemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyMembers", t => t.FamilyMemberId)
                .ForeignKey("dbo.RemindTypes", t => t.RemindTypeId)
                .Index(t => t.RemindTypeId)
                .Index(t => t.FamilyMemberId);
            
            CreateTable(
                "dbo.ExpenseSubcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ExpenseCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategoryId)
                .Index(t => t.ExpenseCategoryId);
            
            CreateTable(
                "dbo.IncomeSubcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IncomeCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IncomeCategories", t => t.IncomeCategoryId)
                .Index(t => t.IncomeCategoryId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SumInValuta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumInRub = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        FromAccountId = c.Int(),
                        ToAccountId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.FromAccountId)
                .ForeignKey("dbo.IncomeCategories", t => t.ToAccountId)
                .Index(t => t.FromAccountId)
                .Index(t => t.ToAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "ToAccountId", "dbo.IncomeCategories");
            DropForeignKey("dbo.Transfers", "FromAccountId", "dbo.Accounts");
            DropForeignKey("dbo.IncomeSubcategories", "IncomeCategoryId", "dbo.IncomeCategories");
            DropForeignKey("dbo.ExpenseSubcategories", "ExpenseCategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.Reminders", "RemindTypeId", "dbo.RemindTypes");
            DropForeignKey("dbo.Reminders", "FamilyMemberId", "dbo.FamilyMembers");
            DropForeignKey("dbo.Accounts", "FamilyMemberId", "dbo.FamilyMembers");
            DropIndex("dbo.Transfers", new[] { "ToAccountId" });
            DropIndex("dbo.Transfers", new[] { "FromAccountId" });
            DropIndex("dbo.IncomeSubcategories", new[] { "IncomeCategoryId" });
            DropIndex("dbo.ExpenseSubcategories", new[] { "ExpenseCategoryId" });
            DropIndex("dbo.Reminders", new[] { "FamilyMemberId" });
            DropIndex("dbo.Reminders", new[] { "RemindTypeId" });
            DropIndex("dbo.Accounts", new[] { "FamilyMemberId" });
            DropTable("dbo.Transfers");
            DropTable("dbo.IncomeSubcategories");
            DropTable("dbo.ExpenseSubcategories");
            DropTable("dbo.Reminders");
            DropTable("dbo.Accounts");
        }
    }
}
