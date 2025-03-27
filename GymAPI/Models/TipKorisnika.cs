using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class TipKorisnika
{
    public int Id { get; set; }

    public int Tip { get; set; }

    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();
}
