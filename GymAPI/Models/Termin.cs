using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class Termin
{
    public int Id { get; set; }

    public DateOnly Dan { get; set; }

    public int Sat { get; set; }

    public int Lokacijaid { get; set; }

    public int TipTerminaid { get; set; }

    public int Popunjenost { get; set; }

    public int Korisnikid { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual Lokacija Lokacija { get; set; } = null!;

    public virtual TipTermina TipTermina { get; set; } = null!;

    public virtual ICollection<Trening> Trenings { get; set; } = new List<Trening>();
}
