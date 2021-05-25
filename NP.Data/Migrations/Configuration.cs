namespace NP.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NP.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NP.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Products.AddOrUpdate(
    new Product { ProductID = 1, Name = "Daily Hydration Conditioner", Ingredients = "Jojoba Extract, Coconut Oil, Glycerin", Description = "Re-hydrate, detangle, & soften with this daily rinse out conditioner without weighing hair down.", Price = 9.99, Category = Category.Conditioner, HairTypeID = 1, SpecialDetailID = 1 },
    new Product { ProductID = 2, Name = "Daily Hydration Shampoo", Ingredients = "Jojoba Extract, Coconut Oil, Coconut Milk, Acacia Senegal", Description = "Re-hydrate, detangle, & soften with this daily rinse out conditioner without weighing hair down.", Price = 11.99, Category = Category.Shampoo, HairTypeID = 2, SpecialDetailID = 2 },
    new Product { ProductID = 3, Name = "Daily Hydration Finishing Spray", Ingredients = "Jojoba Extract, Coconut Oil, Glycerin", Description = "Leaves hair wrapped in a light costal coconut breeze.", Price = 9.99, Category = Category.Oil, HairTypeID = 3, SpecialDetailID = 3 },
    new Product { ProductID = 4, Name = "Green Tea Mask", Ingredients = "Cocos Nucifera (Coconut) Oil, Glycerin (Vegetable), Cetrimonium Chloride, Cocos Nucifera (Coconut) Fruit Juice, Glyceryl Caprylate", Description = "Rejuvenates & softens scalp and elimnates split ends.", Price = 6.99, Category = Category.DeepConditioner, HairTypeID = 4, SpecialDetailID = 4 },
    new Product { ProductID = 5, Name = "Revlon Brush", Ingredients = "N/A", Description = "Great for smoothening and de-tangling", Price = 7.99, Category = Category.StylingTool, HairTypeID = 5, SpecialDetailID = 5 },
    new Product { ProductID = 6, Name = "Charcoal Coconut Mask", Ingredients = "Active Charcoal, Coconut Oil, Coconut Milk", Description = "Designed to smoothen, restore moisture, and help you say goodbye to frizzy hair", Price = 9.99, Category = Category.DeepConditioner, HairTypeID = 6, SpecialDetailID = 6 },
    new Product { ProductID = 7, Name = "Jojoba Shea Butter Leave-In", Ingredients = "Jojoba Extract, Coconut Oil, Shea Butter, Glycerin", Description = "Light-weight, and can be used as a styling product to get your tresses silky and glossy", Price = 13.99, Category = Category.LeaveInConditioner, HairTypeID = 7, SpecialDetailID = 7 },
    new Product { ProductID = 8, Name = "No Wash Shampoo", Ingredients = "Jojoba Extract, Strawberry Extract, Glycerin", Description = "Perfect if you need to re-hydrate and cleanse your tresses on the go.", Price = 16.99, Category = Category.Shampoo, HairTypeID = 8, SpecialDetailID = 8 },
    new Product { ProductID = 9, Name = "Color Splash Midnight Blue", Ingredients = "Blue, Coconut Oil, Glycerin", Description = "Ready for something new? This dye replenishes and delivers on it's 100% color stay guarantee.", Price = 9.99, Category = Category.HairColor, HairTypeID = 9, SpecialDetailID = 9 }
    );
            context.HairTypes.AddOrUpdate(
                new HairType { HairTypeID = 1, TypeOne = false, TypeTwo = false, TypeThree = true, TypeFour = true },
                new HairType { HairTypeID = 2, TypeOne = true, TypeTwo = false, TypeThree = false, TypeFour = true },
                new HairType { HairTypeID = 3, TypeOne = true, TypeTwo = false, TypeThree = true, TypeFour = true },
                new HairType { HairTypeID = 4, TypeOne = true, TypeTwo = false, TypeThree = true, TypeFour = false },
                new HairType { HairTypeID = 5, TypeOne = true, TypeTwo = true, TypeThree = true, TypeFour = true },
                new HairType { HairTypeID = 6, TypeOne = true, TypeTwo = true, TypeThree = true, TypeFour = true },
                new HairType { HairTypeID = 7, TypeOne = false, TypeTwo = false, TypeThree = true, TypeFour = true },
                new HairType { HairTypeID = 8, TypeOne = true, TypeTwo = false, TypeThree = false, TypeFour = false },
                new HairType { HairTypeID = 9, TypeOne = true, TypeTwo = true, TypeThree = true, TypeFour = true }
                );
            context.SpecialDetails.AddOrUpdate(
                new SpecialDetail { SpecialDetailID = 1, IsSulfateFree = false, IsParabenFree = true, IsFormaldehydeFree = true, IsAlcoholFree = true, IsAnimalTested = false },
                new SpecialDetail { SpecialDetailID = 2, IsSulfateFree = true, IsParabenFree = false, IsFormaldehydeFree = true, IsAlcoholFree = true, IsAnimalTested = false },
                new SpecialDetail { SpecialDetailID = 3, IsSulfateFree = false, IsParabenFree = false, IsFormaldehydeFree = false, IsAlcoholFree = false, IsAnimalTested = true },
                new SpecialDetail { SpecialDetailID = 4, IsSulfateFree = true, IsParabenFree = true, IsFormaldehydeFree = true, IsAlcoholFree = true, IsAnimalTested = false },
                new SpecialDetail { SpecialDetailID = 5, IsSulfateFree = true, IsParabenFree = true, IsFormaldehydeFree = true, IsAlcoholFree = true, IsAnimalTested = false },
                new SpecialDetail { SpecialDetailID = 6, IsSulfateFree = true, IsParabenFree = true, IsFormaldehydeFree = true, IsAlcoholFree = true, IsAnimalTested = false },
                new SpecialDetail { SpecialDetailID = 7, IsSulfateFree = true, IsParabenFree = true, IsFormaldehydeFree = true, IsAlcoholFree = true, IsAnimalTested = false },
                new SpecialDetail { SpecialDetailID = 8, IsSulfateFree = true, IsParabenFree = true, IsFormaldehydeFree = true, IsAlcoholFree = true, IsAnimalTested = false },
                new SpecialDetail { SpecialDetailID = 9, IsSulfateFree = true, IsParabenFree = true, IsFormaldehydeFree = true, IsAlcoholFree = true, IsAnimalTested = false }
                );
        }
    }
    
}
