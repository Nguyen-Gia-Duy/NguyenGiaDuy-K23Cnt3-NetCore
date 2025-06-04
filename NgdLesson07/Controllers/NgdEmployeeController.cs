using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgdLesson07.Models;

namespace NgdLesson07.Controllers
{
    public class NgdEmployeeController : Controller
    {
        //Tao Mock Data
        private static List<NgdEmployee> ngdListEmployee = new List<NgdEmployee>()
    {
        new NgdEmployee { NgdId = 1, NgdName = "Nguyễn Gia Duy", NgdBirthDay = new DateTime(2005, 2, 8), NgdEmail = "duy123@example.com", NgdPhone = "0912345678", NgdSalary = 1000, NgdStatus = true },
        new NgdEmployee { NgdId = 2, NgdName = "Trần Thị B", NgdBirthDay = new DateTime(1985, 5, 20), NgdEmail = "b@example.com", NgdPhone = "0923456789", NgdSalary = 1500, NgdStatus = true },
        new NgdEmployee { NgdId = 3, NgdName = "Lê Văn C", NgdBirthDay = new DateTime(1993, 3, 15), NgdEmail = "c@example.com", NgdPhone = "0934567890", NgdSalary = 1200, NgdStatus = false },
        new NgdEmployee { NgdId = 4, NgdName = "Phạm Thị D", NgdBirthDay = new DateTime(1995, 10, 10), NgdEmail = "d@example.com", NgdPhone = "0945678901", NgdSalary = 1100, NgdStatus = true },
        new NgdEmployee { NgdId = 5, NgdName = "Sinh viên - Nguyễn Văn E", NgdBirthDay = new DateTime(2002, 12, 1), NgdEmail = "e@student.com", NgdPhone = "0956789012", NgdSalary = 500, NgdStatus = true }
    };
        // GET: NgdEmployeeController
        public ActionResult NgdIndex()
        {
            return View(ngdListEmployee);
        }

        // GET: NgdEmployeeController/NgdDetails/5
        public ActionResult NgdDetails(int id)
        {
            var ngdEmployee = ngdListEmployee.FirstOrDefault(x => x.NgdId == id);
            return View(ngdEmployee);
        }

        // GET: NgdEmployeeController/NgdCreate
        public ActionResult NgdCreate()
        {
            var ngdEmployee=new NgdEmployee();
            return View(ngdEmployee);
        }

        // POST: NgdEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NgdCreate(NgdEmployee ngdModel)
        {
            try
            {
                //Them moi nhan vien vao list
                ngdModel.NgdId= ngdListEmployee.Max(x=>x.NgdId)+1;
                ngdListEmployee.Add(ngdModel);
                return RedirectToAction(nameof(NgdIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NgdEmployeeController/NgdEdit/5
        public ActionResult NgdEdit(int id)
        {
            var ngdEmployee = ngdListEmployee.FirstOrDefault(x => x.NgdId == id);
            return View(ngdEmployee);
        }

        // POST: NgdEmployeeController/NgdEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NgdEdit(int id, NgdEmployee ngdModel)
        {
            try
            {
                for(int i = 0; i < ngdListEmployee.Count(); i++)
                {
                    if(ngdListEmployee[i].NgdId == id)
                    {
                        ngdListEmployee[i]=ngdModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(NgdIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NgdEmployeeController/Delete/5
        public ActionResult NgdDelete(int id)
        {
            var ngdEmployee = ngdListEmployee.FirstOrDefault(x => x.NgdId == id);
            return View(ngdEmployee);
        }

        // POST: NgdEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NgdDelete(int id, NgdEmployee ngdModel)
        {
            try
            {
                var employeeToDelete = ngdListEmployee.FirstOrDefault(e => e.NgdId == id);
                if (employeeToDelete != null)
                {
                    ngdListEmployee.Remove(employeeToDelete);
                }
                return RedirectToAction(nameof(NgdIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
