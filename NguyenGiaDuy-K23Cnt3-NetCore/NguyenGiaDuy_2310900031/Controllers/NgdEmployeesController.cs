using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenGiaDuy_2310900031.Models;

namespace NguyenGiaDuy_2310900031.Controllers
{
    public class NgdEmployeesController : Controller
    {
        private readonly NguyenGiaDuy2310900031Context _context;

        public NgdEmployeesController(NguyenGiaDuy2310900031Context context)
        {
            _context = context;
        }

        // GET: NgdEmployees
        public async Task<IActionResult> NgdIndex()
        {
            return View(await _context.NgdEmployees.ToListAsync());
        }

        // GET: NgdEmployees/Details/5
        public async Task<IActionResult> NgdDetails(string ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var ngdEmployee = await _context.NgdEmployees
                .FirstOrDefaultAsync(m => m.NgdEmpId == ngdId);
            if (ngdEmployee == null)
            {
                return NotFound();
            }

            return View(ngdEmployee);
        }

        // GET: NgdEmployees/Create
        public IActionResult NgdCreate()
        {
            return View();
        }

        // POST: NgdEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NgdCreate([Bind("NgdEmpId,NgdEmpName,NgdEmpLevel,NgdEmpStartDate,NgdEmpStatus")] NgdEmployee ngdEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ngdEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NgdIndex));
            }
            ModelState.AddModelError("NgdEmpId", "Mã nhân viên đã tồn tại.");
            return View(ngdEmployee);
        }

        // GET: NgdEmployees/Edit/5
        public async Task<IActionResult> NgdEdit(string ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var ngdEmployee = await _context.NgdEmployees.FindAsync(ngdId);
            if (ngdEmployee == null)
            {
                return NotFound();
            }
            return View(ngdEmployee);
        }

        // POST: NgdEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NgdEdit(string ngdId, [Bind("NgdEmpId,NgdEmpName,NgdEmpLevel,NgdEmpStartDate,NgdEmpStatus")] NgdEmployee ngdEmployee)
        {
            if (ngdId != ngdEmployee.NgdEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ngdEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgdEmployeeExists(ngdEmployee.NgdEmpId))
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
            return View(ngdEmployee);
        }

        // GET: NgdEmployees/Delete/5
        public async Task<IActionResult> NgdDelete(string ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var ngdEmployee = await _context.NgdEmployees
                .FirstOrDefaultAsync(m => m.NgdEmpId == ngdId);
            if (ngdEmployee == null)
            {
                return NotFound();
            }

            return View(ngdEmployee);
        }

        // POST: NgdEmployees/Delete/5
        [HttpPost, ActionName("NgdDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string ngdId)
        {
            var ngdEmployee = await _context.NgdEmployees.FindAsync(ngdId);
            if (ngdEmployee != null)
            {
                _context.NgdEmployees.Remove(ngdEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NgdIndex));
        }

        private bool NgdEmployeeExists(string ngdId)
        {
            return _context.NgdEmployees.Any(e => e.NgdEmpId == ngdId);
        }
    }
}
