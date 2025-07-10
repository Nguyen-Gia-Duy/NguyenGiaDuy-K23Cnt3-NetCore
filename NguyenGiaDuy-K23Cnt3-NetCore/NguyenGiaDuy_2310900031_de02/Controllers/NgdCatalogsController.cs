using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenGiaDuy_2310900031_de02.Models;

namespace NguyenGiaDuy_2310900031_de02.Controllers
{
    public class NgdCatalogsController : Controller
    {
        private readonly NguyenGiaDuy2310900031De02Context _context;

        public NgdCatalogsController(NguyenGiaDuy2310900031De02Context context)
        {
            _context = context;
        }

        // GET: NgdCatalogs
        public async Task<IActionResult> NgdIndex()
        {
            return View(await _context.NgdCatalogs.ToListAsync());
        }

        // GET: NgdCatalogs/Details/5
        public async Task<IActionResult> NgdDetails(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var ngdCatalog = await _context.NgdCatalogs
                .FirstOrDefaultAsync(m => m.NgdCateId == ngdId);
            if (ngdCatalog == null)
            {
                return NotFound();
            }

            return View(ngdCatalog);
        }

        // GET: NgdCatalogs/Create
        public IActionResult NgdCreate()
        {
            return View();
        }

        // POST: NgdCatalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NgdCreate([Bind("NgdCateId,NgdCateName,NgdCatePrice,NgdCateQty,NgdCateActive")] NgdCatalog ngdCatalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ngdCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NgdIndex));
            }
            return View(ngdCatalog);
        }

        // GET: NgdCatalogs/Edit/5
        public async Task<IActionResult> NgdEdit(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var ngdCatalog = await _context.NgdCatalogs.FindAsync(ngdId);
            if (ngdCatalog == null)
            {
                return NotFound();
            }
            return View(ngdCatalog);
        }

        // POST: NgdCatalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NgdEdit(int ngdId, [Bind("NgdCateId,NgdCateName,NgdCatePrice,NgdCateQty,NgdCateActive")] NgdCatalog ngdCatalog)
        {
            if (ngdId != ngdCatalog.NgdCateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ngdCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgdCatalogExists(ngdCatalog.NgdCateId))
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
            return View(ngdCatalog);
        }

        // GET: NgdCatalogs/Delete/5
        public async Task<IActionResult> NgdDelete(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var ngdCatalog = await _context.NgdCatalogs
                .FirstOrDefaultAsync(m => m.NgdCateId == ngdId);
            if (ngdCatalog == null)
            {
                return NotFound();
            }

            return View(ngdCatalog);
        }

        // POST: NgdCatalogs/Delete/5
        [HttpPost, ActionName("NgdDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ngdId)
        {
            var ngdCatalog = await _context.NgdCatalogs.FindAsync(ngdId);
            if (ngdCatalog != null)
            {
                _context.NgdCatalogs.Remove(ngdCatalog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NgdIndex));
        }

        private bool NgdCatalogExists(int ngdId)
        {
            return _context.NgdCatalogs.Any(e => e.NgdCateId == ngdId);
        }
    }
}
