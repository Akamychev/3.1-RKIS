using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Semestr
{
    public int SemestrId { get; set; }

    public int FkKursId { get; set; }

    public int? Semestr1 { get; set; }

    public virtual ICollection<Ekzaman> Ekzamen { get; set; } = new List<Ekzaman>();

    public virtual Kur FkKurs { get; set; } = null!;
}
