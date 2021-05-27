using NP.Data;
using NP.Models.Lists;
using NP.Models.RetailerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Services
{
    public class PlanService
    {
        public bool CreatePlan(PlanCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Plan plan = new Plan()
                {
                    Title = model.Title,
                    Description = model.Description
                };
                ctx.Plans.Add(plan);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlanList> GetPlans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Plans.Where(e => e.PlanID >= 1).Select(e =>
                    new PlanList
                    {
                        PlanID = e.PlanID,
                        Title = e.Title,
                        Description = e.Description
                    });
                return query.ToArray();
            }
        }
        public IEnumerable<PlanProductList> GetPlanProducts(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Where(e => e.PlanID == id)
                    .Select(f => new PlanProductList
                    {
                        //PlanID = f.PlanID,
                        ProductID = f.ProductID,
                        Name = f.Name,
                        Category = f.Category
                    });
                return query.ToArray();
            }
        } 
        public PlanList GetPlanById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Plans.Single(e => e.PlanID == id);
                return new PlanList
                {
                    PlanID = entity.PlanID,
                    Title = entity.Title,
                    Description = entity.Description
                };                
            }
        }
        public bool UpdatePlan(int planId, PlanEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Plan plan = ctx.Plans.FirstOrDefault(e => e.PlanID == planId);

                plan.Title = model.Title;
                plan.Description = model.Description;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlan(int planID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Plans.Single(e => e.PlanID == planID);
                ctx.Plans.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
