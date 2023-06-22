using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Oblast
{
    public int OblastId { get; set; }

    public string? Oblast1 { get; set; }

    public virtual ICollection<Acdegree> Acdegrees { get; set; } = new List<Acdegree>();
}
