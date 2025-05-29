using System;
using System.Collections.Generic;

namespace GameZoneManagement.Models;

public partial class TblPlayerRecord
{
    public int BookingId { get; set; }

    public int PlayerId { get; set; }

    public string? PlayerName { get; set; }

    public string? Games { get; set; }

    public string? Duration { get; set; }

    public string? Price { get; set; }

    public DateOnly? Date { get; set; }

    public string? Discount { get; set; }
}
