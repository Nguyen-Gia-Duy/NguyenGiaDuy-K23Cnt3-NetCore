using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenGiaDuy_2310900031.Models;

public partial class NgdEmployee
{
    public string NgdEmpId { get; set; } = null!;

    public string? NgdEmpName { get; set; }

    public string? NgdEmpLevel { get; set; }

    public DateOnly? NgdEmpStartDate { get; set; }
    [Display(Name = "Trạng thái")]
    public bool? NgdEmpStatus { get; set; }
}
