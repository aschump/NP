using NP.Data;
using NP.Models;
using NP.Models.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Services
{
    public class ProductService
    {
        //private readonly Guid _userId;
        //public ProductService(Guid userID)
        //{
        //    _userId = userID;
        //}

        public bool CreateProduct(ProductCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                SpecialDetail specialDetail = new
                    SpecialDetail()
                {
                    IsSulfateFree = model.IsSulfateFree,
                    IsParabenFree = model.IsParabenFree,
                    IsFormaldehydeFree = model.IsFormaldehydeFree,
                    IsAlcoholFree = model.IsAlcoholFree,
                    IsAnimalTested = model.IsAnimalTested,
                };
                ctx.SpecialDetails.Add(specialDetail);

                HairType hairType = new HairType()
                {
                    TypeOne = model.TypeOne,
                    TypeTwo = model.TypeTwo,
                    TypeThree = model.TypeThree,
                    TypeFour = model.TypeFour
                };
                ctx.HairTypes.Add(hairType);

              
                Product product =
            new Product()
            {
                Name = model.Name,
                Ingredients = model.Ingredients,
                Description = model.Description,
                Price = model.Price,
                Category = model.Category,
                PlanID = model.PlanID,
                DateAdded = DateTimeOffset.Now
            };
                ctx.Products.Add(product);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductList> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Products.Where(e => e.ProductID >= 1).Select(e =>
                    new ProductList
                    {
                        ProductID = e.ProductID,
                        Name = e.Name,
                        Price = e.Price,
                        Category = e.Category
                    });
                return query.ToArray();
            }
        }
        //Edit
        public bool UpdateProduct(int productId, ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var entity = ctx.Products.Single(e => e.ProductID == model.ProductID);
                int specialDetailID = ctx.Products.Single(e => e.ProductID == productId).SpecialDetailID;
                SpecialDetail specialDetail = ctx.SpecialDetails.FirstOrDefault(e => e.SpecialDetailID == specialDetailID);

                specialDetail.IsSulfateFree = model.IsSulfateFree;
                specialDetail.IsParabenFree = model.IsParabenFree;
                specialDetail.IsFormaldehydeFree = model.IsFormaldehydeFree;
                specialDetail.IsAlcoholFree = model.IsAlcoholFree;
                specialDetail.IsAnimalTested = model.IsAnimalTested;

                int hairTypeID = ctx.Products.Single(e => e.ProductID == productId).HairTypeID;
                HairType hairType = ctx.HairTypes.FirstOrDefault(e => e.HairTypeID == hairTypeID);
                hairType.TypeOne = model.TypeOne;
                hairType.TypeTwo = model.TypeTwo;
                hairType.TypeThree = model.TypeThree;
                hairType.TypeFour = model.TypeFour;

                //int planID = ctx.Products.Single(e => e.ProductID == productId).PlanID;
                //Plan plan = ctx.Plans.FirstOrDefault(e => e.PlanID == planID);
                //plan.PlanID = model.PlanID;

                Product products = ctx.Products.Single(e => e.ProductID == productId);
                products.Name = model.Name;
                products.Ingredients = model.Ingredients;
                products.Description = model.Description;
                products.Price = model.Price;
                products.Category = model.Category;
                products.ModifiedDate = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 3;
            }
        }

        //Delete
        public bool DeleteProduct(int productID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductID == productID);
                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //Get by product ID for Details
        //Special Detail keeps returning as null but there is data in the table
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductID == id);
                return new ProductDetail
                {
                    ProductID = entity.ProductID,
                    Name = entity.Name,
                    Ingredients = entity.Ingredients,
                    Description = entity.Description,
                    Price = entity.Price,
                    Category = entity.Category,
                    TypeOne = ctx.HairTypes.FirstOrDefault(e => e.HairTypeID == entity.HairTypeID).TypeOne,
                    TypeTwo = ctx.HairTypes.FirstOrDefault(e => e.HairTypeID == entity.HairTypeID).TypeTwo,
                    TypeThree = ctx.HairTypes.FirstOrDefault(e => e.HairTypeID == entity.HairTypeID).TypeThree,
                    TypeFour = ctx.HairTypes.FirstOrDefault(e => e.HairTypeID == entity.HairTypeID).TypeFour,
                    IsSulfateFree = ctx.SpecialDetails.FirstOrDefault(e => e.SpecialDetailID == entity.SpecialDetailID).IsSulfateFree,
                    IsParabenFree = ctx.SpecialDetails.FirstOrDefault(e => e.SpecialDetailID == entity.SpecialDetailID).IsParabenFree,
                    IsFormaldehydeFree = ctx.SpecialDetails.FirstOrDefault(e => e.SpecialDetailID == entity.SpecialDetailID).IsFormaldehydeFree,
                    IsAlcoholFree = ctx.SpecialDetails.FirstOrDefault(e => e.SpecialDetailID == entity.SpecialDetailID).IsAlcoholFree,
                    IsAnimalTested = ctx.SpecialDetails.FirstOrDefault(e => e.SpecialDetailID == entity.SpecialDetailID).IsAnimalTested,
                    DateAdded = entity.DateAdded,
                    ModifiedUtc = entity.ModifiedDate

                };
            }
        }
        //Get by Category
        public IEnumerable<CategoryBuildList> GetByCategory(Category category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Where(e => e.Category == category).Select(e => new CategoryBuildList
                {
                    ProductID = e.ProductID,
                    Name = e.Name,
                    Category = e.Category,
                    Description = e.Description
                });
                return query.ToList();

            };
        }

        //Get By HairType
        //public IEnumerable<HairTypeBuildList> GetByHairType(bool hairType)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        //if (hairType == ctx.Products.Where(e => e.HairType.TypeOne || e.HairType.TypeTwo || e.HairType.TypeThree || e.HairType.TypeFour))
        //        var query = ctx.Products.Where(e => e.HairType.TypeOne || e.HairType.TypeTwo || e.HairType.TypeThree || e.HairType.TypeFour == hairType).Select(e => new HairTypeBuildList
        //        {
        //            ProductID = e.ProductID,
        //            Name = e.Name,
        //            Category = e.Category,
        //            TypeOne = ctx.HairTypes.FirstOrDefault(z => z.HairTypeID == e.HairTypeID).TypeOne,
        //            TypeTwo = ctx.HairTypes.FirstOrDefault(z => z.HairTypeID == e.HairTypeID).TypeTwo,
        //            TypeThree = ctx.HairTypes.FirstOrDefault(z => z.HairTypeID == e.HairTypeID).TypeThree,
        //            TypeFour = ctx.HairTypes.FirstOrDefault(z => z.HairTypeID == e.HairTypeID).TypeFour
        //        });
        //        return query.ToList();
        //    }
            ////Get by Naturals
            //public IEnumerable<CategoryBuildList> GetByNatural(GetNaturalList model)
            //{
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        var query = ctx.SpecialDetails.Where(e => (e.IsSulfateFree == true) || (e.IsParabenFree == true) || (e.IsFormaldehydeFree == true) || (e.IsAlcoholFree == true) || (e.IsAnimalTested == false)).ToArray()
            //            .Select(f => BuildProduct(f));
            //        return query.ToList();

            //    }
            //}

            ////Get by hair type
            ////Helper Method
            //private CategoryBuildList BuildProduct(SpecialDetail product)
            //{
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        CategoryBuildList productList = new CategoryBuildList
            //        {
            //            ProductID = ctx.Products.FirstOrDefault(e => e.SpecialDetailID == product.SpecialDetailID).ProductID,
            //            Name = ctx.Products.FirstOrDefault(e => e.SpecialDetailID == product.SpecialDetailID).Name,
            //            Category = ctx.Products.FirstOrDefault(e => e.SpecialDetailID == product.SpecialDetailID).Category,
            //            Description = ctx.Products.FirstOrDefault(e => e.SpecialDetailID == product.SpecialDetailID).Description
            //        };
            //        return productList;

            //    }
        //    }

        //}
    }
}
