using NP.Models;
using NP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NP.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var service = new ProductService();
            var model = service.GetProducts();
            return View(model);
        }

        //GET: Create
        //gets the create view
        // api/product/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        // api/product/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new ProductService();
            if (service.CreateProduct(model))
            {
                TempData["SaveResult"] = "Product has been created.";
                return RedirectToAction("Index");

            }
            else
            {
            ModelState.AddModelError("", "Product could not be created.");
            }
            return View(model);
        }
    }
}