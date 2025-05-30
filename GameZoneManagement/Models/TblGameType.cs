using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZoneManagement.Models;

public partial class TblGameType
{
    public int GameTypeId { get; set; }

    public string? GameType { get; set; }

    public int? ModeId { get; set; }



}
