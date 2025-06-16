using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NgdLesson09.Models;

namespace NgdLesson09.Controllers
{
    public class NgdCategoriesController : Controller
    {
        private readonly NgdBookStoreContext _context;

        public NgdCategoriesController(NgdBookStoreContext context)
        {
            _context = context;
        }

        // GET: NgdCategories
        public async Task<IActionResult> NgdIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NgdCategories/Details/5
        public async Task<IActionResult> Details(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == ngdId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NgdCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NgdCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NgdIndex));
            }
            return View(category);
        }

        // GET: NgdCategories/Edit/5
        public async Task<IActionResult> Edit(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(ngdId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: NgdCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ngdId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (ngdId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NgdIndex));
            }
            return View(category);
        }

        // GET: NgdCategories/Delete/5
        public async Task<IActionResult> Delete(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == ngdId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NgdCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ngdId)
        {
            var category = await _context.Categories.FindAsync(ngdId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NgdIndex));
        }

        private bool CategoryExists(int ngdId)
        {
            return _context.Categories.Any(e => e.CategoryId == ngdId);
        }
    }
}
