using System;
using System.Collections.Generic;

namespace GameZoneManagement.Models;

public partial class TblGame
{
    public int Id { get; set; }

    public int? TypeId { get; set; }

    public string? Games { get; set; }

    public string? Duration { get; set; }

    public string? Price { get; set; }
}
