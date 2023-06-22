using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Stud
{
    public int StudId { get; set; }

    public int FkPolId { get; set; }

    public int FkGruppaId { get; set; }

    public string? Nozach { get; set; }

    public string? Lname { get; set; }

    public string? Fname { get; set; }

    public string? Mname { get; set; }

    public DateOnly? Birthday { get; set; }

    public decimal? Rost { get; set; }

    public int? Ves { get; set; }

    public int? Stipendia { get; set; }

    public virtual Gruppa FkGruppa { get; set; } = null!;

    public virtual Pol FkPol { get; set; } = null!;
}
