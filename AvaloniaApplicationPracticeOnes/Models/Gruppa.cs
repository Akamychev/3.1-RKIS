using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Gruppa
{
    public int GruppaId { get; set; }

    public int FkFacultyId { get; set; }

    public int FkKursId { get; set; }

    public int? FkSpecialnostId { get; set; }

    public string? Gruppa1 { get; set; }

    public virtual Kur FkKurs { get; set; } = null!;

    public virtual ICollection<Stud> Studs { get; set; } = new List<Stud>();
}
