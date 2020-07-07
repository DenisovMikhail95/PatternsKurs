namespace PatternsKurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0006 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reminders", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reminders", "Name");
        }
    }
}
