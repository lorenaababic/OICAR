using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class Vjezba
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Trening> Trenings { get; set; } = new List<Trening>();
}
