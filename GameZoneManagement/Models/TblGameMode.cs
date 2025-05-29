using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZoneManagement.Models;

public partial class TblGameMode
{
    public int ModeId { get; set; }

    public string? GamingMode { get; set; }

    [NotMapped]
    public List<SelectListItem> GetModesList { get; set; }
}
