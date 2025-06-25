using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NgdLesson10bai1.Models;

namespace NgdLesson10bai1.Controllers
{
    public class NgdCategoriesController : Controller
    {
        private readonly NgdLesson10Bai1Context _context;

        public NgdCategoriesController(NgdLesson10Bai1Context context)
        {
            _context = context;
        }

        // GET: NgdCategories
        public async Task<IActionResult> NgdIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NgdCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NgdCategories/Create
        public IActionResult NgdCreate()
        {
            return View();
        }

        // POST: NgdCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NgdCreate([Bind("CateName,CateStatus")] Category category)

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
        public async Task<IActionResult> NgdEdit(int? ngdId)
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
        public async Task<IActionResult> NgdEdit(int ngdId, [Bind("CateId,CateName,CateStatus")] Category category)
        {
            if (ngdId != category.CateId)
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
                    if (!CategoryExists(category.CateId))
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
        public async Task<IActionResult> NgdDelete(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == ngdId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NgdCategories/Delete/5
        [HttpPost, ActionName("NgdDelete")]
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
            return _context.Categories.Any(e => e.CateId == ngdId);
        }
    }
}
