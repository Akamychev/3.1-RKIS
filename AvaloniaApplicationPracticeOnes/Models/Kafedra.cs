using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Kafedra
{
    public int KafedraId { get; set; }

    public string? Kafedra1 { get; set; }

    public string? Kafedrashort { get; set; }

    public virtual ICollection<Prepod> Prepods { get; set; } = new List<Prepod>();
}
