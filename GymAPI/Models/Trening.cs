using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class Trening
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public int Vjezbaid { get; set; }

    public int Set { get; set; }

    public int Repeticija { get; set; }

    public decimal Tezina { get; set; }

    public string? Komentar { get; set; }

    public bool Odradeno { get; set; }

    public virtual Vjezba Vjezba { get; set; } = null!;

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();
}
