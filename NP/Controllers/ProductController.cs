using NP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductList[0];
            return View(model);
        }

        //GET: Create
        //gets the create view
        // api/product/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}