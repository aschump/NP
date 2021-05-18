namespace NP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialDetail",
                c => new
                    {
                        SpecialDetailID = c.Int(nullable: false, identity: true),
                        IsSulfateFree = c.Boolean(nullable: false),
                        IsParabenFree = c.Boolean(nullable: false),
                        IsFormaldehydeFree = c.Boolean(nullable: false),
                        IsAlcoholFree = c.Boolean(nullable: false),
                        IsAnimalTested = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialDetailID);
            
            AddColumn("dbo.Product", "SpecialDetailID", c => c.Int());
            CreateIndex("dbo.Product", "SpecialDetailID");
            AddForeignKey("dbo.Product", "SpecialDetailID", "dbo.SpecialDetail", "SpecialDetailID");
            DropColumn("dbo.Product", "IsSulfateFree");
            DropColumn("dbo.Product", "IsParabenFree");
            DropColumn("dbo.Product", "IsFormaldehydeFree");
            DropColumn("dbo.Product", "IsAlcoholFree");
            DropColumn("dbo.Product", "IsAnimalTested");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "IsAnimalTested", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsAlcoholFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsFormaldehydeFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsParabenFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsSulfateFree", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Product", "SpecialDetailID", "dbo.SpecialDetail");
            DropIndex("dbo.Product", new[] { "SpecialDetailID" });
            DropColumn("dbo.Product", "SpecialDetailID");
            DropTable("dbo.SpecialDetail");
        }
    }
}
