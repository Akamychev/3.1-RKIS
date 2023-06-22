using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Kur
{
    public int KursId { get; set; }

    public virtual ICollection<Gruppa> Gruppas { get; set; } = new List<Gruppa>();

    public virtual ICollection<Semestr> Semestrs { get; set; } = new List<Semestr>();
}
