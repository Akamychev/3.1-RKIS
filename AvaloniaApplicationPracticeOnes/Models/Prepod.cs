using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Prepod
{
    public int PrepodId { get; set; }

    public int FkDolznostId { get; set; }

    public int FkAcdegreeId { get; set; }

    public int FkKafedraId { get; set; }

    public string? Lname { get; set; }

    public string? Fname { get; set; }

    public string? Mname { get; set; }

    public DateOnly? Birthday { get; set; }

    public virtual Acdegree FkAcdegree { get; set; } = null!;

    public virtual Dolznost FkDolznost { get; set; } = null!;

    public virtual Kafedra FkKafedra { get; set; } = null!;
}
