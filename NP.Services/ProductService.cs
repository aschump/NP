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
                Product product =
                    new Product
                    {
                        Name = model.Name,
                        Ingredients = model.Ingredients,
                        Description = model.Description,
                        Price = model.Price,
                        Category = model.Category,

                        //IsSulfateFree = model.IsSulfateFree,
                        //IsParabenFree = model.IsParabenFree,
                        //IsFormaldehydeFree = model.IsFormaldehydeFree,
                        //IsAlcoholFree = model.IsAlcoholFree,
                        //IsAnimalTested = model.IsAnimalTested,
                        DateAdded = DateTimeOffset.UtcNow
                    };
                ctx.Products.Add(product);

                SpecialDetail specialDetail = new SpecialDetail
                {
                    IsSulfateFree = model.IsSulfateFree,
                    IsParabenFree = model.IsParabenFree,
                    IsFormaldehydeFree = model.IsFormaldehydeFree,
                    IsAlcoholFree = model.IsAlcoholFree,
                    IsAnimalTested = model.IsAnimalTested,
                };
                ctx.SpecialDetails.Add(specialDetail);
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
                        Name = e.Name,
                        Price = e.Price,
                        Category = e.Category
                    });
                return query.ToArray();
            }
        }
    }
}
