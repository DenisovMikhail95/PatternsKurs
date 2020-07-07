namespace PatternsKurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0009 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reminders", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reminders", "Date");
        }
    }
}
