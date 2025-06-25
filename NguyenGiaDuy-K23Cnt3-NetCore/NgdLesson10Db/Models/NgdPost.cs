using System;
using System.Collections.Generic;

namespace NgdLesson10Db.Models;

public partial class NgdPost
{
    public int NgdId { get; set; }

    public string? NgdTitle { get; set; }

    public string? NgdImage { get; set; }

    public string? NgdContent { get; set; }

    public bool? NgdStatus { get; set; }
}
