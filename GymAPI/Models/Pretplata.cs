using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class Pretplata
{
    public int Id { get; set; }

    public int TipPretplateid { get; set; }

    public DateOnly DatumPocetka { get; set; }

    public DateOnly DatumZavrsetka { get; set; }

    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();

    public virtual TipPretplate TipPretplate { get; set; } = null!;
}
