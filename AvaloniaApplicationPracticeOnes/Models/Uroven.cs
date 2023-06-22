using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Uroven
{
    public string UrovenId { get; set; } = null!;

    public string? Uroven1 { get; set; }

    public virtual ICollection<Acdegree> Acdegrees { get; set; } = new List<Acdegree>();
}
