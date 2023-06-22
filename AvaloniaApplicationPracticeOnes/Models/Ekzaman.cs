using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Ekzaman
{
    public int EkzamenId { get; set; }

    public int FkSpecialnostId { get; set; }

    public int FkSemestrId { get; set; }

    public int FkSubjectId { get; set; }

    public int FkPrepodId { get; set; }

    public virtual ICollection<Ackbook> Ackbooks { get; set; } = new List<Ackbook>();

    public virtual Semestr FkSemestr { get; set; } = null!;
}
