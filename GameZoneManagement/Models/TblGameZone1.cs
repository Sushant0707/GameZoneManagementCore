using System;
using System.Collections.Generic;

namespace GameZoneManagement.Models;

public partial class TblGameZone1
{
    public int UserId { get; set; }

    public string? UserType { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? UserPhone { get; set; }

    public string? UserGender { get; set; }

    public string? UserState { get; set; }

    public string? UserCity { get; set; }

    public string? UserPassword { get; set; }

    public string? UserConfirmPassword { get; set; }
}
