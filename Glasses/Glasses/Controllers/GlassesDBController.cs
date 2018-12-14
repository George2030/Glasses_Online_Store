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
    public class GlassesDBController : Controller
    {
        private readonly MyContext _context;

        public GlassesDBController(MyContext context)
        {
            _context = context;
        }

        // GET: GlassesDB
        public IActionResult Index()
        {
            var myContext = _context.Glasses.Include(g => g.Brand);
            return View(myContext.ToList());
        }

        // GET: GlassesDB/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glass = _context.Glasses
                .Include(g => g.Brand)
                .FirstOrDefault(m => m.Glass_ID == id);
            if (glass == null)
            {
                return NotFound();
            }

            return View(glass);
        }

        // GET: GlassesDB/Create
        public IActionResult Create()
        {
            ViewData["Brand_ID"] = new SelectList(_context.Brands, "Brand_ID", "Brand_ID");
            return View();
        }

        // POST: GlassesDB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Glass_ID,GName,Price,Brand_ID")] Glass glass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(glass);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Brand_ID"] = new SelectList(_context.Brands, "Brand_ID", "Brand_ID", glass.Brand_ID);
            return View(glass);
        }

        // GET: GlassesDB/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glass = _context.Glasses.Find(id);
            if (glass == null)
            {
                return NotFound();
            }
            ViewData["Brand_ID"] = new SelectList(_context.Brands, "Brand_ID", "Brand_ID", glass.Brand_ID);
            return View(glass);
        }

        // POST: GlassesDB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Glass_ID,GName,Price,Brand_ID")] Glass glass)
        {
            if (id != glass.Glass_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(glass);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlassExists(glass.Glass_ID))
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
            ViewData["Brand_ID"] = new SelectList(_context.Brands, "Brand_ID", "Brand_ID", glass.Brand_ID);
            return View(glass);
        }

        // GET: GlassesDB/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glass = _context.Glasses
                .Include(g => g.Brand)
                .FirstOrDefault(m => m.Glass_ID == id);
            if (glass == null)
            {
                return NotFound();
            }

            return View(glass);
        }

        // POST: GlassesDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var glass = _context.Glasses.Find(id);
            _context.Glasses.Remove(glass);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool GlassExists(int id)
        {
            return _context.Glasses.Any(e => e.Glass_ID == id);
        }
    }
}
