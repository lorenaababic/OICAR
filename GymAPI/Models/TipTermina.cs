using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class TipTermina
{
    public int Id { get; set; }

    public int Tip { get; set; }

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();
}
