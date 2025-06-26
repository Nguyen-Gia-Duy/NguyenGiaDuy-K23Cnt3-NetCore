using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NgdLesson10Db.Models;

namespace NgdLesson10Db.Controllers
{
    public class NgdPostsController : Controller
    {
        private readonly NgdK23cnt3Ls10DbContext _context;

        public NgdPostsController(NgdK23cnt3Ls10DbContext context)
        {
            _context = context;
        }

        // GET: NgdPosts
        public async Task<IActionResult> NgdIndex()
        {
            return View(await _context.NgdPosts.ToListAsync());
        }

        // GET: NgdPosts/Details/5
        public async Task<IActionResult> NgdDetails(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var ngdPost = await _context.NgdPosts
                .FirstOrDefaultAsync(m => m.NgdId == ngdId);
            if (ngdPost == null)
            {
                return NotFound();
            }

            return View(ngdPost);
        }

        // GET: NgdPosts/Create
        public IActionResult NgdCreate()
        {
            return View();
        }

        // POST: NgdPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NgdCreate([Bind("NgdId,NgdTitle,NgdImage,NgdContent,NgdStatus")] NgdPost ngdPost,IFormFile NgdImage)
        {
            if (ModelState.IsValid)
            {
                if (NgdImage != null && NgdImage.Length > 0)
                {
                   //Tao ten fole duy nhat de tranh trung lap
                    var fileName = Path.GetFileNameWithoutExtension(NgdImage.FileName);
                    var extension = Path.GetExtension(NgdImage.FileName);

                    var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";

                    var path=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",newFileName);
                    //Luu vao file thu muc
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await NgdImage.CopyToAsync(stream);
                    }

                    ngdPost.NgdImage ="images/"+ newFileName;
                }


                _context.Add(ngdPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NgdIndex));
            }
            return View(ngdPost);
        }

        // GET: NgdPosts/Edit/5
        public async Task<IActionResult> NgdEdit(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var ngdPost = await _context.NgdPosts.FindAsync(ngdId);
            if (ngdPost == null)
            {
                return NotFound();
            }
            return View(ngdPost);
        }

        // POST: NgdPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NgdEdit(int ngdId, [Bind("NgdId,NgdTitle,NgdImage,NgdContent,NgdStatus")] NgdPost ngdPost, IFormFile NgdImage)
        {
            if (ngdId != ngdPost.NgdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (NgdImage != null && NgdImage.Length > 0)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(NgdImage.FileName);
                        var extension = Path.GetExtension(NgdImage.FileName);
                        var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";

                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        var path = Path.Combine(folderPath, newFileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await NgdImage.CopyToAsync(stream);
                        }

                        ngdPost.NgdImage = "images/" + newFileName;
                    }

                    _context.Update(ngdPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgdPostExists(ngdPost.NgdId))
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
            return View(ngdPost);
        }

        // GET: NgdPosts/Delete/5
        public async Task<IActionResult> NgdDelete(int? ngdId)
        {
            if (ngdId == null)
            {
                return NotFound();
            }

            var ngdPost = await _context.NgdPosts
                .FirstOrDefaultAsync(m => m.NgdId == ngdId);
            if (ngdPost == null)
            {
                return NotFound();
            }

            return View(ngdPost);
        }

        // POST: NgdPosts/Delete/5
        [HttpPost, ActionName("NgdDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NgdDeleteConfirmed(int ngdId)
        {
            var ngdPost = await _context.NgdPosts.FindAsync(ngdId);
            if (ngdPost != null)
            {
                _context.NgdPosts.Remove(ngdPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NgdIndex));
        }

        private bool NgdPostExists(int ngdId)
        {
            return _context.NgdPosts.Any(e => e.NgdId == ngdId);
        }
    }
}
