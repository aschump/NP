namespace NP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
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
            
            AddColumn("dbo.Product", "SpecialDetailID", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            CreateIndex("dbo.Product", "SpecialDetailID");
            AddForeignKey("dbo.Product", "SpecialDetailID", "dbo.SpecialDetail", "SpecialDetailID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SpecialDetailID", "dbo.SpecialDetail");
            DropIndex("dbo.Product", new[] { "SpecialDetailID" });
            AlterColumn("dbo.Product", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Product", "SpecialDetailID");
            DropTable("dbo.SpecialDetail");
        }
    }
}
