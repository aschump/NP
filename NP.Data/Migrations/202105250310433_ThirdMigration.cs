namespace NP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HairType",
                c => new
                    {
                        HairTypeID = c.Int(nullable: false, identity: true),
                        TypeOne = c.Boolean(nullable: false),
                        TypeTwo = c.Boolean(nullable: false),
                        TypeThree = c.Boolean(nullable: false),
                        TypeFour = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HairTypeID);
            
            AddColumn("dbo.Product", "HairTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "HairTypeID");
            AddForeignKey("dbo.Product", "HairTypeID", "dbo.HairType", "HairTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "HairTypeID", "dbo.HairType");
            DropIndex("dbo.Product", new[] { "HairTypeID" });
            DropColumn("dbo.Product", "HairTypeID");
            DropTable("dbo.HairType");
        }
    }
}
