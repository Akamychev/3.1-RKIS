using System;
using System.Collections.Generic;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class Ackbook
{
    public int AckbookId { get; set; }

    public int FkEkzamenId { get; set; }

    public int FkStudId { get; set; }

    public int FkTypeochId { get; set; }

    public DateOnly? Datarec { get; set; }

    public virtual Ekzaman FkEkzamen { get; set; } = null!;
}
