using NP.Models.ProductModels;
using NP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NP.Controllers
{
    public class PlanController : Controller
    {
        // GET: Retailer
        public ActionResult Index()
        {
            var service = new PlanService();
            var model = service.GetPlans();
            return View(model);
        }

        //GET: Create
        //gets the create view
        // api/plan/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        // api/plan/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanCreate model)
        {
            var service = new PlanService();
            if (service.CreatePlan(model))
            {
                TempData["SaveResult"] = "Plan has been created.";
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Plan could not be created.");
            return View(model);
        }
        //GET view for specific products on a plan
       
        public ActionResult Details(int id)
        {
            var svc = new PlanService();
            var model = svc.GetPlanProducts(id);
            return View(model);
        }
        //GET Edit
        public ActionResult Edit(int id)
        {
            var service = new PlanService();
            var detail = service.GetPlanById(id);
            var model =
                new PlanEdit
                {
                    PlanID = detail.PlanID,
                    Title = detail.Title,
                    Description = detail.Description
                };
            return View(model);
        }
        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlanEdit model)
        {
            var service = new PlanService();

            if (service.UpdatePlan(id, model))
            {
                TempData["SaveResult"] = "Plan has been updated.";
                return RedirectToAction("Index");

            }
           ModelState.AddModelError("", "Plan could not be updated.");
            return View(model);
        }

        //GET Delete
        public ActionResult Delete(int id)
        {
            var svc = new PlanService();
            var model = svc.GetPlanById(id);
            return View(model);
        }

        //POST Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlan(int id)
        {
            var service = new PlanService();
            service.DeletePlan(id);
            TempData["SaveResult"] = "Plan has been deleted";
            return RedirectToAction("Index");
        }
    }
}