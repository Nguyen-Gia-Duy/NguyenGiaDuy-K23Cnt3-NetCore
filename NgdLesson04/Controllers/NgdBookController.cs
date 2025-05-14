using Microsoft.AspNetCore.Mvc;
using NgdLesson04.Models;
using System;

namespace NgdLesson04.Controllers
{
    public class NgdBookController : Controller
    {
        //Get:/NgdBook/NgdIndex=> Lay ra cac cuon sach
        private List<NgdBook> ngdBooks = new List<NgdBook>
        {
            new NgdBook
               {
        NgdId = "B001",
        NgdTitle = "Lập trình C# cơ bản",
        NgdDescription = "Hướng dẫn chi tiết lập trình C# từ cơ bản đến nâng cao.",
        NgdImage = "images/sach1.jpg",
        NgdPrice = 150000f,
        NgdPage = 320
    },
    new NgdBook
    {
        NgdId = "B002",
        NgdTitle = "ASP.NET Core thực chiến",
        NgdDescription = "Xây dựng ứng dụng web hiện đại với ASP.NET Core.",
        NgdImage = "images/sach2.jpg",
        NgdPrice = 180000f,
        NgdPage = 400
    },
    new NgdBook
    {
        NgdId = "B003",
        NgdTitle = "Cấu trúc dữ liệu & Giải thuật",
        NgdDescription = "Cẩm nang học cấu trúc dữ liệu và giải thuật bằng C#.",
        NgdImage = "images/sach3.jpg",
        NgdPrice = 200000f,
        NgdPage = 450
    },
    new NgdBook
            {
        NgdId = "B004",
        NgdTitle = "Dac nhan tam",
        NgdDescription = "Cẩm nang Cuoc song",
        NgdImage = "images/sach4.jpg",
        NgdPrice = 99000f,
        NgdPage = 350
    },
    new NgdBook
             {
        NgdId = "B005",
        NgdTitle = "Bai giang cuoi cung",
        NgdDescription = "hoc tap",
        NgdImage = "images/sach5.jpg",
        NgdPrice = 55000f,
        NgdPage = 300
    }
        };
        public IActionResult NgdIndex()
        {
            //Dua du lieu len view

            return View(ngdBooks);
        }
        //Get:/NgdBook/NgdCrete/
        public IActionResult NgdCreate()
        {
            NgdBook ngdBook = new NgdBook();

            return View(ngdBook);
        }
        //Get:/NgdBook/NgdCreteSubmit
        public IActionResult NgdCreateSubmit()
        {
            
                //...
                return RedirectToAction("NgdIndex");
        }
        //Get:/NgdBook/NgdCrete/
        public IActionResult NgdEdit(string id)
        {
            return View();
        }
        //Get:/NgdBook/NgdCreteSubmit
        public IActionResult NgdEditSubmit()
        {
            //...
            return RedirectToAction("NgdIndex");
        }
    }
}
