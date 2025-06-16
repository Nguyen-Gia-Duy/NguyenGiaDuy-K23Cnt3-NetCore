using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgdLesson08.Models;

namespace NgdLesson08.Controllers
{

    public class NgdAccountController : Controller
    {
        private static List<NgdAccount> ngdListAccount = new List<NgdAccount>()
        {
             new NgdAccount
                {
                    NgdId = 1,
                    NgdFullName = "Nguyen gia Duy",
                    NgdEmail = "duy123@gmail.com",
                    NgdPhone = "0321321312",
                    NgdAddress = "Lớp K23CNT3",
                    NgdAvatar = "duyab.jpg",
                    NgdBirthday = new DateTime(2005, 2, 08),
                    NgdGender = "Nam",
                    NgdPassword = "123456duy",
                    NgdFacebook = "https://www.facebook.com/tams.cas.39"
                },
                new NgdAccount
                {
                    NgdId = 2,
                    NgdFullName = "Trần Thị B",
                    NgdEmail = "tranthib@example.com",
                    NgdPhone = "0987654321",
                    NgdAddress = "456 Đường B, Quận 3, TP.HCM",
                    NgdAvatar = "avatar2.jpg",
                    NgdBirthday = new DateTime(1992, 8, 15),
                    NgdGender = "Nữ",
                    NgdPassword = "password2",
                    NgdFacebook = "https://facebook.com/tranthib"
                },
                new NgdAccount
                {
                    NgdId = 3,
                    NgdFullName = "Lê Văn C",
                    NgdEmail = "levanc@example.com",
                    NgdPhone = "0911222333",
                    NgdAddress = "789 Đường C, Quận 5, TP.HCM",
                    NgdAvatar = "avatar3.jpg",
                    NgdBirthday = new DateTime(1988, 12, 1),
                    NgdGender = "Nam",
                    NgdPassword = "password3",
                    NgdFacebook = "https://facebook.com/levanc"
                },
                new NgdAccount
                {
                    NgdId = 4,
                    NgdFullName = "Phạm Thị D",
                    NgdEmail = "phamthid@example.com",
                    NgdPhone = "0909876543",
                    NgdAddress = "321 Đường D, Quận 7, TP.HCM",
                    NgdAvatar = "avatar4.jpg",
                    NgdBirthday = new DateTime(1995, 3, 10),
                    NgdGender = "Nữ",
                    NgdPassword = "password4",
                    NgdFacebook = "https://facebook.com/phamthid"
                },
                new NgdAccount
                {
                    NgdId = 5,
                    NgdFullName = "Hoàng Văn E",
                    NgdEmail = "hoangvane@example.com",
                    NgdPhone = "0933444555",
                    NgdAddress = "654 Đường E, Quận 10, TP.HCM",
                    NgdAvatar = "avatar5.jpg",
                    NgdBirthday = new DateTime(1991, 7, 22),
                    NgdGender = "Nam",
                    NgdPassword = "password5",
                    NgdFacebook = "https://facebook.com/hoangvane"
                }
        };
        // GET: NgdAccountController
        public ActionResult NgdIndex()
        {
            return View(ngdListAccount);
        }

        // GET: NgdAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NgdAccountController/Create
        public ActionResult NgdCreate()
        {
            var ngdModel = new NgdAccount();
            return View();
        }

        // POST: NgdAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NgdAccount ngdModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Giả sử bạn có DbContext tên _context đã được Inject trong Controller
                    //_context.NgdAccounts.Add(NgdModel);
                    //_context.SaveChanges();
                    ngdListAccount.Add(ngdModel);
                    return RedirectToAction(nameof(Index));
                }

                // Nếu dữ liệu không hợp lệ, trả về View để người dùng sửa
                return View(ngdModel);
            }
            catch (Exception ex)
            {
                // Bạn có thể log lỗi ở đây nếu cần
                ModelState.AddModelError("", "Có lỗi xảy ra khi thêm mới: " + ex.Message);
                return View(ngdModel);
            }
        }

        // GET: NgdAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NgdAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NgdAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NgdAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
