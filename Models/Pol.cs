using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Pol
{
    public int PolId { get; set; }

    public string? Pol1 { get; set; }

    public string? PolShort { get; set; }

    public virtual ICollection<Stud> Studs { get; set; } = new List<Stud>();
}
