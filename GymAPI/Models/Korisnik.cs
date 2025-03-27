using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class Korisnik
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public int Spol { get; set; }

    public int Visina { get; set; }

    public DateTime DatumKreiranja { get; set; }

    public DateTime DatumPromjene { get; set; }

    public int LokacijaId { get; set; }

    public int TipKorisnikaid { get; set; }

    public int Tezinaid { get; set; }

    public int Pretplataid { get; set; }

    public int? OsobniTrener { get; set; }

    public virtual ICollection<Korisnik> InverseOsobniTrenerNavigation { get; set; } = new List<Korisnik>();

    public virtual Lokacija Lokacija { get; set; } = null!;

    public virtual Korisnik? OsobniTrenerNavigation { get; set; }

    public virtual Pretplata Pretplata { get; set; } = null!;

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();

    public virtual Tezina Tezina { get; set; } = null!;

    public virtual TipKorisnika TipKorisnika { get; set; } = null!;
}
