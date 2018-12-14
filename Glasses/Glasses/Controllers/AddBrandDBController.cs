using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Glasses.Models;

namespace Glasses.Controllers
{
    public class AddBrandDBController : Controller
    {
        private readonly MyContext _context;

        public AddBrandDBController(MyContext context)
        {
            _context = context;
        }

        // GET: AddBrandDB
        public IActionResult Index()
        {
            return View(_context.Brands.ToList());
        }

        // GET: AddBrandDB/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = _context.Brands
                .FirstOrDefault(m => m.Brand_ID == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: AddBrandDB/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddBrandDB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Brand_ID,Glassbrand")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: AddBrandDB/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = _context.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: AddBrandDB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Brand_ID,Glassbrand")] Brand brand)
        {
            if (id != brand.Brand_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Brand_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: AddBrandDB/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = _context.Brands
                .FirstOrDefault(m => m.Brand_ID == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: AddBrandDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var brand = _context.Brands.Find(id);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.Brand_ID == id);
        }
    }
}
