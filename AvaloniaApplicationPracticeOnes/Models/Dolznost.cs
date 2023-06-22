using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Dolznost
{
    public int DolznostId { get; set; }

    public string? Dolznost1 { get; set; }

    public virtual ICollection<Prepod> Prepods { get; set; } = new List<Prepod>();
}
