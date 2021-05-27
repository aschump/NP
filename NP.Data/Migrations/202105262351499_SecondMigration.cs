namespace NP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plan", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Plan", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plan", "Description", c => c.String());
            AlterColumn("dbo.Plan", "Title", c => c.String());
        }
    }
}
