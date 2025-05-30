using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZoneManagement.Models;

public partial class TblGame
{
    public int Id { get; set; }

    public int? TypeId { get; set; }

    public string? Games { get; set; }

    public string? Duration { get; set; }

    public string? Price { get; set; }

    [NotMapped]
    public List<SelectListItem> GetModesList { get; set; }

    [NotMapped]
    public List<SelectListItem> GetTypesList { get; set; }

    [NotMapped]
    public int? ModeId { get; set; }
}
