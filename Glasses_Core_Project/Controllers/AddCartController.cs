using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glasses_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Glasses_Core_Project.Controllers
{
    public class AddCartController : Controller
    {
        private DataContext db = new DataContext();



        [Route("Cart")]
        public IActionResult Cart()
        {
            ViewBag.Glasses = db.Glasses.ToList();
            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View("Create", new Glasses());
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Glasses books)
        {
            if (ModelState.IsValid)
            {
                db.Glasses.Add(books);
                db.SaveChanges();

            }
            return RedirectToAction("Cart");
        }
                
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id = 0)
        {
            db.Remove(db.Glasses.Find(id));
            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id = 0)
        {
            return View("Edit", db.Glasses.Find(id));
        }

        [HttpPost]
        [Route("Edit/{id?}")]
        public IActionResult Edit(int id, Glasses books)
        {
            db.Entry(books).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChangesAsync();
            return RedirectToAction("Cart");
        }
    }
}