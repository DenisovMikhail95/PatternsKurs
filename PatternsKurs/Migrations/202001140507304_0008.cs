namespace PatternsKurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0008 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transfers", "ValutaId", "dbo.Valutas");
            DropForeignKey("dbo.Transfers", "ToAccountId", "dbo.Accounts");
            DropForeignKey("dbo.Transfers", "FromAccountId", "dbo.Accounts");
            DropIndex("dbo.Transfers", new[] { "FromAccountId" });
            DropIndex("dbo.Transfers", new[] { "ToAccountId" });
            DropIndex("dbo.Transfers", new[] { "ValutaId" });
            DropTable("dbo.Transfers");
        }
        
        public override void Down()
        {
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
                        ValutaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Transfers", "ValutaId");
            CreateIndex("dbo.Transfers", "ToAccountId");
            CreateIndex("dbo.Transfers", "FromAccountId");
            AddForeignKey("dbo.Transfers", "FromAccountId", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Transfers", "ToAccountId", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Transfers", "ValutaId", "dbo.Valutas", "Id");
        }
    }
}
