using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class TipPretplate
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public int Trajanje { get; set; }

    public decimal Cijena { get; set; }

    public virtual ICollection<Pretplata> Pretplata { get; set; } = new List<Pretplata>();
}
