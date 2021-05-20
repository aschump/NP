using NP.Data;
using NP.Models;
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
                Product product =
            new Product()
            {
                Name = model.Name,
                Ingredients = model.Ingredients,
                Description = model.Description,
                Price = model.Price,
                Category = model.Category,
                DateAdded = DateTimeOffset.UtcNow
            };
                ctx.Products.Add(product);
                return ctx.SaveChanges() == 1;
            }
            //    var entity=
            //        new Product()
            //        {
            //            Name = model.Name,
            //            Ingredients = model.Ingredients,
            //            Description = model.Description,
            //            Price = model.Price,
            //            Category = model.Category,
            //            DateAdded = DateTimeOffset.UtcNow
            //        };

            //    new SpecialDetail ()
            //    {
            //        IsSulfateFree = model.IsSulfateFree,
            //        IsParabenFree = model.IsParabenFree,
            //        IsFormaldehydeFree = model.IsFormaldehydeFree,
            //        IsAlcoholFree = model.IsAlcoholFree,
            //        IsAnimalTested = model.IsAnimalTested,
            //    };
            //using (var ctx = new ApplicationDbContext())
            //{
            //    ctx.Products.Add(entity);
            //    return ctx.SaveChanges() == 1;
            //}
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
            using(var ctx = new ApplicationDbContext())
            {
                //var entity = ctx.Products.Single(e => e.ProductID == model.ProductID);
                int? specialDetailID = ctx.Products.Single(e => e.ProductID == productId).SpecialDetailID;
                SpecialDetail specialDetail = ctx.SpecialDetails.FirstOrDefault(e => e.SpecialDetailID == specialDetailID);

                specialDetail.IsSulfateFree = model.IsSulfateFree;
                specialDetail.IsParabenFree = model.IsParabenFree;
                specialDetail.IsFormaldehydeFree = model.IsFormaldehydeFree;
                specialDetail.IsAlcoholFree = model.IsAlcoholFree;
                specialDetail.IsAnimalTested = model.IsAnimalTested;


                Product products = ctx.Products.Single(e => e.ProductID == productId);
                products.Name = model.Name;
                products.Ingredients = model.Ingredients;
                products.Description = model.Description;
                products.Price = model.Price;
                products.Category = model.Category;
                products.ModifiedDate = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 2;
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
        public IEnumerable<ProductList> GetByCategory(Category category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Where(e => e.Category == category).Select(e => new ProductList
                {
                    ProductID = e.ProductID,
                    Name = e.Name,                    
                    Price = e.Price,
                    Category = e.Category
                });
                return query.ToList();

            };
        }
        //Get by hair type
        //Get by price range
        
    }
}
