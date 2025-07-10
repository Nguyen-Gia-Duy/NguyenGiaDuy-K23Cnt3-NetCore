using System;
using System.Collections.Generic;

namespace NguyenGiaDuy_2310900031_de02.Models;

public partial class NgdCatalog
{
    public int NgdCateId { get; set; }

    public string? NgdCateName { get; set; }

    public string? NgdCatePrice { get; set; }

    public string? NgdCateQty { get; set; }

    public bool? NgdCateActive { get; set; }
}
