﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnNETcORE2.Models;
using LearnNETcORE2.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnNETcORE2.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        [Authorize]
        public ViewResult Index() => View(repository.Products);

        [Authorize]
        public ViewResult Edit(int productId) =>View(repository.Products
                                                               .FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values                
                return View(product);
            }
        }

        [Authorize]
        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}