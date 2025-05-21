using Microsoft.AspNetCore.Mvc;
using NgdLesson05.Models.DataModel;

namespace NgdLesson05.Controllers
{
    public class NgdMemberController : Controller
    {
        private static List<NgdMember> ngdListMember = new List<NgdMember>()
        {
             new NgdMember
            {
                NgdMemberId = "2310900031",
                NgdUserName = "Nguyen Duy",
                NgdPassword = "123456duy",
                NgdFullName = "Nguyen Gia Duy",
                NgdEmail = "duy01@example.com"
            },
            new NgdMember
            {
                NgdMemberId = "002",
                NgdUserName = "lethi02",
                NgdPassword = "password",
                NgdFullName = "Le Thi B",
                NgdEmail = "lethi02@example.com"
            },
            new NgdMember
            {
                NgdMemberId = "003",
                NgdUserName = "tranvan03",
                NgdPassword = "abc123",
                NgdFullName = "Tran Van C",
                NgdEmail = "tranvan03@example.com"
            },
            new NgdMember
            {
                NgdMemberId = "004",
                NgdUserName = "phamthi04",
                NgdPassword = "hello456",
                NgdFullName = "Pham Thi D",
                NgdEmail = "phamthi04@example.com"
            },
            new NgdMember
            {
                NgdMemberId = "005",
                NgdUserName = "doan05",
                NgdPassword = "secure789",
                NgdFullName = "Doan E",
                NgdEmail = "doan05@example.com"
            }
        };
          
          
         

        public IActionResult NgdIndex()
        {

            return View(ngdListMember);
        }
    }
}
