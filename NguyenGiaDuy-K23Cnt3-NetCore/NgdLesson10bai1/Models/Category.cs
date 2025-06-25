using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgdLesson10bai1.Models;

public partial class Category
{
    [Key]
    public int CateId { get; set; }

    public string? CateName { get; set; }

    public bool? CateStatus { get; set; }
}
