﻿using NP.Models;
using NP.Services;
using System;
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
            if (!ModelState.IsValid) 
                return View(model);
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
        public ActionResult Details(int id)
        {
            var svc = new ProductService();
            var model = svc.GetProductById(id);
            return View(model);
        }
        //GET edit
        public ActionResult Edit(int id)
        {
            var service = new ProductService();
            var detail = service.GetProductById(id);
            var model =
                new ProductEdit
                {
                    ProductID = detail.ProductID,
                    Name = detail.Name,
                    Ingredients = detail.Ingredients,
                    Description = detail.Description,
                    Price = detail.Price,
                    Category = detail.Category,
                    IsSulfateFree = detail.IsSulfateFree,
                    IsParabenFree = detail.IsParabenFree,
                    IsFormaldehydeFree = detail.IsFormaldehydeFree,
                    IsAlcoholFree = detail.IsAlcoholFree,
                    IsAnimalTested = detail.IsAnimalTested,
                    ModifiedDate = DateTimeOffset.UtcNow
                };
                return View(model);
        }
        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if(model.ProductID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new ProductService();
            if (service.UpdateProduct(id, model))
            {
                TempData["SaveResult"] = "Product has been updated.";
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Product could not be updated.");
            }
            return View(model);
        }

        //Delete
    }
}