using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Acdegree
{
    public int AcdegreeId { get; set; }

    public string FkUrovenId { get; set; } = null!;

    public int? FkOblastId { get; set; }

    public string? Acdegree1 { get; set; }

    public string? Acdegreeshort { get; set; }

    public virtual Oblast? FkOblast { get; set; }

    public virtual Uroven FkUroven { get; set; } = null!;

    public virtual ICollection<Prepod> Prepods { get; set; } = new List<Prepod>();
}
