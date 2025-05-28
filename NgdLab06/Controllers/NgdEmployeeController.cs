using Microsoft.AspNetCore.Mvc;
using NgdLab06.Models;

namespace NgdLab06.Controllers
{
    public class NgdEmployeeController : Controller
    {
        private static List<NgdEmployee> ngdListEmployee = new List<NgdEmployee>
    {
        new NgdEmployee { NgdId = 1, NgdName = "Nguyễn Gia Duy", NgdBirthDay = new DateTime(2005, 2, 8), NgdEmail = "duy123@example.com", NgdPhone = "0912345678", NgdSalary = 1000, NgdStatus = true },
        new NgdEmployee { NgdId = 2, NgdName = "Trần Thị B", NgdBirthDay = new DateTime(1985, 5, 20), NgdEmail = "b@example.com", NgdPhone = "0923456789", NgdSalary = 1500, NgdStatus = true },
        new NgdEmployee { NgdId = 3, NgdName = "Lê Văn C", NgdBirthDay = new DateTime(1993, 3, 15), NgdEmail = "c@example.com", NgdPhone = "0934567890", NgdSalary = 1200, NgdStatus = false },
        new NgdEmployee { NgdId = 4, NgdName = "Phạm Thị D", NgdBirthDay = new DateTime(1995, 10, 10), NgdEmail = "d@example.com", NgdPhone = "0945678901", NgdSalary = 1100, NgdStatus = true },
        new NgdEmployee { NgdId = 5, NgdName = "Sinh viên - Nguyễn Văn E", NgdBirthDay = new DateTime(2002, 12, 1), NgdEmail = "e@student.com", NgdPhone = "0956789012", NgdSalary = 500, NgdStatus = true }
    };
        public IActionResult NgdIndex()
        {
            return View(ngdListEmployee);
        }
        public IActionResult NgdCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NgdCreate(NgdEmployee model)
        {
            if (ModelState.IsValid)
            {
                // Tạo Id mới (ví dụ lấy max Id hiện có + 1)
                int newId = ngdListEmployee.Any() ? ngdListEmployee.Max(e => e.NgdId) + 1 : 1;
                model.NgdId = newId;

                ngdListEmployee.Add(model);
                //Chuyen huong ve danh sach
                return RedirectToAction("NgdIndex");
            }
            // Nếu dữ liệu không hợp lệ thì trả về lại view form kèm dữ liệu đã nhập
            return View(model);
        }
        // GET: Hiển thị form sửa
        public IActionResult NgdEdit(int id)
        {
            var employee = ngdListEmployee.FirstOrDefault(e => e.NgdId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Xử lý cập nhật nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NgdEdit(NgdEmployee model)
        {
            if (ModelState.IsValid)
            {
                var employee = ngdListEmployee.FirstOrDefault(e => e.NgdId == model.NgdId);
                if (employee == null)
                {
                    return NotFound();
                }
                // Cập nhật thông tin
                employee.NgdName = model.NgdName;
                employee.NgdBirthDay = model.NgdBirthDay;
                employee.NgdEmail = model.NgdEmail;
                employee.NgdPhone = model.NgdPhone;
                employee.NgdSalary = model.NgdSalary;
                employee.NgdStatus = model.NgdStatus;

                return RedirectToAction("NgdIndex");
            }
            return View(model);
        }

        // GET: Xác nhận xóa
        public IActionResult NgdDelete(int id)
        {
            var employee = ngdListEmployee.FirstOrDefault(e => e.NgdId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Xóa nhân viên
        [HttpPost, ActionName("NgdDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult NgdDeleteConfirm(int id)
        {
            var employee = ngdListEmployee.FirstOrDefault(e => e.NgdId == id);
            if (employee == null)
            {
                return NotFound();
            }
            ngdListEmployee.Remove(employee);
            return RedirectToAction("NgdIndex");
        }



    }
}
