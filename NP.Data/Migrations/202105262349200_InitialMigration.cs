namespace NP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
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
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PlanID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Category = c.Int(nullable: false),
                        HairTypeID = c.Int(nullable: false),
                        SpecialDetailID = c.Int(nullable: false),
                        PlanID = c.Int(nullable: false),
                        DateAdded = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.HairType", t => t.HairTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Plan", t => t.PlanID, cascadeDelete: true)
                .ForeignKey("dbo.SpecialDetail", t => t.SpecialDetailID, cascadeDelete: true)
                .Index(t => t.HairTypeID)
                .Index(t => t.SpecialDetailID)
                .Index(t => t.PlanID);
            
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
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Product", "SpecialDetailID", "dbo.SpecialDetail");
            DropForeignKey("dbo.Product", "PlanID", "dbo.Plan");
            DropForeignKey("dbo.Product", "HairTypeID", "dbo.HairType");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Product", new[] { "PlanID" });
            DropIndex("dbo.Product", new[] { "SpecialDetailID" });
            DropIndex("dbo.Product", new[] { "HairTypeID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.SpecialDetail");
            DropTable("dbo.Product");
            DropTable("dbo.Plan");
            DropTable("dbo.HairType");
        }
    }
}
