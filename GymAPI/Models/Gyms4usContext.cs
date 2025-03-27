using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GymAPI.DTOs;

namespace GymAPI.Models;

public partial class Gyms4usContext : DbContext
{
    public Gyms4usContext()
    {
    }

    public Gyms4usContext(DbContextOptions<Gyms4usContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<Lokacija> Lokacijas { get; set; }

    public virtual DbSet<Pretplata> Pretplatas { get; set; }

    public virtual DbSet<Termin> Termins { get; set; }

    public virtual DbSet<Tezina> Tezinas { get; set; }

    public virtual DbSet<TipKorisnika> TipKorisnikas { get; set; }

    public virtual DbSet<TipPretplate> TipPretplates { get; set; }

    public virtual DbSet<TipTermina> TipTerminas { get; set; }

    public virtual DbSet<Trening> Trenings { get; set; }

    public virtual DbSet<Vjezba> Vjezbas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("name=ConnectionStrings:connstr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_stat_statements");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_pkey");

            entity.ToTable("admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("korisnik_pkey");

            entity.ToTable("korisnik");

            entity.HasIndex(e => e.Mail, "korisnik_mail_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DatumKreiranja)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datum_kreiranja");
            entity.Property(e => e.DatumPromjene)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datum_promjene");
            entity.Property(e => e.Ime)
                .HasMaxLength(15)
                .HasColumnName("ime");
            entity.Property(e => e.LokacijaId).HasColumnName("lokacija_id");
            entity.Property(e => e.Mail)
                .HasMaxLength(30)
                .HasColumnName("mail");
            entity.Property(e => e.OsobniTrener).HasColumnName("osobni_trener");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Pretplataid).HasColumnName("pretplataid");
            entity.Property(e => e.Prezime)
                .HasMaxLength(25)
                .HasColumnName("prezime");
            entity.Property(e => e.Spol).HasColumnName("spol");
            entity.Property(e => e.Tezinaid).HasColumnName("tezinaid");
            entity.Property(e => e.TipKorisnikaid).HasColumnName("tip_korisnikaid");
            entity.Property(e => e.Visina).HasColumnName("visina");

            entity.HasOne(d => d.Lokacija).WithMany(p => p.Korisniks)
                .HasForeignKey(d => d.LokacijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("korisnik_lokacija_id_fkey");

            entity.HasOne(d => d.OsobniTrenerNavigation).WithMany(p => p.InverseOsobniTrenerNavigation)
                .HasForeignKey(d => d.OsobniTrener)
                .HasConstraintName("korisnik_osobni_trener_fkey");

            entity.HasOne(d => d.Pretplata).WithMany(p => p.Korisniks)
                .HasForeignKey(d => d.Pretplataid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("korisnik_pretplataid_fkey");

            entity.HasOne(d => d.Tezina).WithMany(p => p.Korisniks)
                .HasForeignKey(d => d.Tezinaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("korisnik_tezinaid_fkey");

            entity.HasOne(d => d.TipKorisnika).WithMany(p => p.Korisniks)
                .HasForeignKey(d => d.TipKorisnikaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("korisnik_tip_korisnikaid_fkey");
        });

        modelBuilder.Entity<Lokacija>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lokacija_pkey");

            entity.ToTable("lokacija");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adresa)
                .HasMaxLength(25)
                .HasColumnName("adresa");
            entity.Property(e => e.Ime)
                .HasMaxLength(20)
                .HasColumnName("ime");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
        });

        modelBuilder.Entity<Pretplata>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pretplata_pkey");

            entity.ToTable("pretplata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DatumPocetka).HasColumnName("datum_pocetka");
            entity.Property(e => e.DatumZavrsetka).HasColumnName("datum_zavrsetka");
            entity.Property(e => e.TipPretplateid).HasColumnName("tip_pretplateid");

            entity.HasOne(d => d.TipPretplate).WithMany(p => p.Pretplata)
                .HasForeignKey(d => d.TipPretplateid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pretplata_tip_pretplateid_fkey");
        });

        modelBuilder.Entity<Termin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("termin_pkey");

            entity.ToTable("termin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dan).HasColumnName("dan");
            entity.Property(e => e.Korisnikid).HasColumnName("korisnikid");
            entity.Property(e => e.Lokacijaid).HasColumnName("lokacijaid");
            entity.Property(e => e.Popunjenost).HasColumnName("popunjenost");
            entity.Property(e => e.Sat).HasColumnName("sat");
            entity.Property(e => e.TipTerminaid).HasColumnName("tip_terminaid");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Termins)
                .HasForeignKey(d => d.Korisnikid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("termin_korisnikid_fkey");

            entity.HasOne(d => d.Lokacija).WithMany(p => p.Termins)
                .HasForeignKey(d => d.Lokacijaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("termin_lokacijaid_fkey");

            entity.HasOne(d => d.TipTermina).WithMany(p => p.Termins)
                .HasForeignKey(d => d.TipTerminaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("termin_tip_terminaid_fkey");

            entity.HasMany(d => d.Trenings).WithMany(p => p.Termins)
                .UsingEntity<Dictionary<string, object>>(
                    "TerminTrening",
                    r => r.HasOne<Trening>().WithMany()
                        .HasForeignKey("Treningid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("termin_trening_treningid_fkey"),
                    l => l.HasOne<Termin>().WithMany()
                        .HasForeignKey("Terminid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("termin_trening_terminid_fkey"),
                    j =>
                    {
                        j.HasKey("Terminid", "Treningid").HasName("termin_trening_pkey");
                        j.ToTable("termin_trening");
                        j.IndexerProperty<int>("Terminid").HasColumnName("terminid");
                        j.IndexerProperty<int>("Treningid").HasColumnName("treningid");
                    });
        });

        modelBuilder.Entity<Tezina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tezina_pkey");

            entity.ToTable("tezina");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datum)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datum");
            entity.Property(e => e.Tezina1)
                .HasPrecision(5, 2)
                .HasColumnName("tezina");
        });

        modelBuilder.Entity<TipKorisnika>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tip_korisnika_pkey");

            entity.ToTable("tip_korisnika");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tip).HasColumnName("tip");
        });

        modelBuilder.Entity<TipPretplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tip_pretplate_pkey");

            entity.ToTable("tip_pretplate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cijena)
                .HasPrecision(10, 2)
                .HasColumnName("cijena");
            entity.Property(e => e.Naziv)
                .HasMaxLength(30)
                .HasColumnName("naziv");
            entity.Property(e => e.Trajanje).HasColumnName("trajanje");
        });

        modelBuilder.Entity<TipTermina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tip_termina_pkey");

            entity.ToTable("tip_termina");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tip).HasColumnName("tip");
        });

        modelBuilder.Entity<Trening>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trening_pkey");

            entity.ToTable("trening");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Komentar)
                .HasMaxLength(255)
                .HasColumnName("komentar");
            entity.Property(e => e.Naziv)
                .HasMaxLength(25)
                .HasColumnName("naziv");
            entity.Property(e => e.Odradeno).HasColumnName("odradeno");
            entity.Property(e => e.Repeticija).HasColumnName("repeticija");
            entity.Property(e => e.Set).HasColumnName("set");
            entity.Property(e => e.Tezina)
                .HasPrecision(5, 2)
                .HasColumnName("tezina");
            entity.Property(e => e.Vjezbaid).HasColumnName("vjezbaid");

            entity.HasOne(d => d.Vjezba).WithMany(p => p.Trenings)
                .HasForeignKey(d => d.Vjezbaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trening_vjezbaid_fkey");
        });

        modelBuilder.Entity<Vjezba>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vjezba_pkey");

            entity.ToTable("vjezba");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Naziv)
                .HasMaxLength(20)
                .HasColumnName("naziv");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<GymAPI.DTOs.LokacijaDTO> LokacijaDTO { get; set; } = default!;
}
