using Microsoft.AspNetCore.Mvc;
using NgdLesson02.Models;
using System.Security.Principal;

namespace NgdLesson02.Controllers
{
    public class NgdAccountController : Controller
    {
        public IActionResult NgdIndex()
        {
            List<NgdAccount> accounts = new List<NgdAccount>
            {
                new NgdAccount
                {
                    Id = 1,
                    Name = "Nguyen Duy",
                    Email = "Duy12345@gmail.com",
                    Phone = "0986698780",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe1.jpg"),
                    Gender = 1,
                    Bio = "My name is DUy",
                    Birthday = new DateTime(2005, 2, 8)
                },
                new NgdAccount
                {
                    Id = 2,
                    Name = "Huyen Trang",
                    Email = "Trang123@example.com",
                    Phone = "03299300",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe2.jpg"),
                    Gender = 1,
                    Bio = "My name is TrangChuche",
                    Birthday = new DateTime(2005, 9, 17)
                },
                new NgdAccount
                {
                    Id = 3,
                    Name = "Be Bu",
                    Email = "bebu456@example.com",
                    Phone = "0329939",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe3.jpg"),
                    Gender = 1,
                    Bio = "My name is Babi",
                    Birthday = new DateTime(2005, 3, 2)
                },
                 new NgdAccount
                {
                    Id = 4,
                    Name = "Chubby",
                    Email = "chubby001@example.com",
                    Phone = "0329939213",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe4.jpg"),
                    Gender = 1,
                    Bio = "My name is Chubby",
                    Birthday = new DateTime(2005, 5, 20)
                },
                  new NgdAccount
                {
                    Id = 5,
                    Name = "Khanh Anh",
                    Email = "Khanh6@example.com",
                    Phone = "0329939",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe5.jpg"),
                    Gender = 1,
                    Bio = "My name is Babi",
                    Birthday = new DateTime(2005, 2, 6)
                }
            };
            ViewBag.Accounts = accounts;
            return View();
        }
        //dinh nghia url va nam cho action
        [Route("ho-so-cua-toi",Name="profile")]

        public IActionResult NgdProfile(int id)
        {
            List<NgdAccount> accounts = new List<NgdAccount>
            {
                new NgdAccount
                {
                    Id = 1,
                    Name = "Nguyen Duy",
                    Email = "Duy12345@gmail.com",
                    Phone = "0986698780",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe1.jpg"),
                    Gender = 1,
                    Bio = "My name is DUy",
                    Birthday = new DateTime(2005, 2, 8)
                },
                new NgdAccount
                {
                    Id = 2,
                    Name = "Huyen Trang",
                    Email = "Trang123@example.com",
                    Phone = "03299300",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe2.jpg"),
                    Gender = 1,
                    Bio = "My name is TrangChuche",
                    Birthday = new DateTime(2005, 9, 17)
                },
                new NgdAccount
                {
                    Id = 3,
                    Name = "Be Bu",
                    Email = "bebu456@example.com",
                    Phone = "0329939",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe3.jpg"),
                    Gender = 1,
                    Bio = "My name is Babi",
                    Birthday = new DateTime(2005, 3, 2)
                },
                 new NgdAccount
                {
                    Id = 4,
                    Name = "Chubby",
                    Email = "chubby001@example.com",
                    Phone = "0329939213",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe4.jpg"),
                    Gender = 1,
                    Bio = "My name is Chubby",
                    Birthday = new DateTime(2005, 5, 20)
                },
                  new NgdAccount
                {
                    Id = 5,
                    Name = "Khanh Anh",
                    Email = "Khanh6@example.com",
                    Phone = "0329939",
                    Address = "Ha Noi",
                    Avatar = Url.Content("~/Avatar/xe5.jpg"),
                    Gender = 1,
                    Bio = "My name is Babi",
                    Birthday = new DateTime(2005, 2, 6)
                },
            };
            //Truy xuat doi tuong theo id
            NgdAccount account = accounts.FirstOrDefault(ac => ac.Id == id);
            ViewBag.account = account;
            return View();
        }
    }
}
