namespace NP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "IsSulfateFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsParabenFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsFormaldehydeFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsAlcoholFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsAnimalTested", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Product", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Product", "IsAnimalTested");
            DropColumn("dbo.Product", "IsAlcoholFree");
            DropColumn("dbo.Product", "IsFormaldehydeFree");
            DropColumn("dbo.Product", "IsParabenFree");
            DropColumn("dbo.Product", "IsSulfateFree");
        }
    }
}
