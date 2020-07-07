namespace PatternsKurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FamilyMembers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FamilyMembers", "Password");
        }
    }
}
