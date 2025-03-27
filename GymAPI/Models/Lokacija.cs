using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class Lokacija
{
    public int Id { get; set; }

    public string Ime { get; set; } = null!;

    public string Adresa { get; set; } = null!;

    public int Longitude { get; set; }

    public int Latitude { get; set; }

    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();
}
