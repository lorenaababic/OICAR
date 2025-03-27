using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class Tezina
{
    public int Id { get; set; }

    public decimal Tezina1 { get; set; }

    public DateTime Datum { get; set; }

    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();
}
