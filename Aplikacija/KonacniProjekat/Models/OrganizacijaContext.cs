using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KonacniProjekat.Models
{
    public partial class OrganizacijaContext : DbContext
    {
        public OrganizacijaContext()
        {
        }

        public OrganizacijaContext(DbContextOptions<OrganizacijaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anketa> Anketa { get; set; }
        public virtual DbSet<HallOfFame> HallOfFame { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Kvizovi> Kvizovi { get; set; }
        public virtual DbSet<OcenjivanjeVodica> OcenjivanjeVodica { get; set; }
        public virtual DbSet<Pitanja> Pitanja { get; set; }
        public virtual DbSet<Rezervacije> Rezervacije { get; set; }
        public virtual DbSet<Ture> Ture { get; set; }
        public virtual DbSet<Turisti> Turisti { get; set; }
        public virtual DbSet<Vodici> Vodici { get; set; }
        public virtual DbSet<Znamenitosti> Znamenitosti { get; set; }
        public virtual DbSet<ZnamenitostiUTurama> ZnamenitostiUTurama { get; set; }
        public virtual DbSet<Slike> Slike { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=organizacija;uid=root;pwd=root", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anketa>(entity =>
            {
                entity.HasKey(e => e.IdAnkete)
                    .HasName("PRIMARY");

                entity.ToTable("anketa");

                entity.HasIndex(e => e.IdAnkete)
                    .HasName("idankete_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdTureAnk)
                    .HasName("IdTureAnk_idx");

                entity.HasIndex(e => e.IdTuristeAnk)
                    .HasName("IdTuristeAnk_idx");

                entity.HasIndex(e => e.IdVodicaAnk)
                    .HasName("IdVodicaAnk_idx");

                entity.Property(e => e.DrustvenaAtmosfera)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Komentar)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NajdosadnijaZnamenitost)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NajinteresantnijaZnamenitost)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TipTuriste)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.VremenskiUslovi)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdTureAnkNavigation)
                    .WithMany(p => p.Anketa)
                    .HasForeignKey(d => d.IdTureAnk)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("IdTureAnk");

                entity.HasOne(d => d.IdTuristeAnkNavigation)
                    .WithMany(p => p.Anketa)
                    .HasForeignKey(d => d.IdTuristeAnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdTuristeAnk");

                entity.HasOne(d => d.IdVodicaAnkNavigation)
                    .WithMany(p => p.Anketa)
                    .HasForeignKey(d => d.IdVodicaAnk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("IdVodicaAnk");
            });

            modelBuilder.Entity<HallOfFame>(entity =>
            {
                entity.HasKey(e => e.IdHallOfFame)
                    .HasName("PRIMARY");

                entity.ToTable("halloffame");

                entity.HasIndex(e => e.IdHallOfFame)
                    .HasName("IdHallOfFame_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdKvizaHof)
                    .HasName("IdKviza_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdTuristeHof)
                    .HasName("IdTuriste_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DatumRadjenja).HasColumnType("date");

                entity.HasOne(d => d.IdKvizaHofNavigation)
                    .WithOne(p => p.HallOfFame)
                    .HasForeignKey<HallOfFame>(d => d.IdKvizaHof)
                    .HasConstraintName("IdKvizaHof");

                entity.HasOne(d => d.IdTuristeHofNavigation)
                    .WithOne(p => p.HallOfFame)
                    .HasForeignKey<HallOfFame>(d => d.IdTuristeHof)
                    .HasConstraintName("IdTuristeHof");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.IdKorisnika)
                    .HasName("PRIMARY");

                entity.ToTable("korisnici");

                entity.HasIndex(e => e.IdKorisnika)
                    .HasName("IdKorisnika_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdTuristeK)
                    .HasName("IdTuristeK_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdVodicaK)
                    .HasName("IdVodicaK_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("Username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TipKorisnika)
                    .IsRequired()
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdTuristeKNavigation)
                    .WithOne(p => p.Korisnici)
                    .HasForeignKey<Korisnici>(d => d.IdTuristeK)
                    .HasConstraintName("IdTuristeK");

                entity.HasOne(d => d.IdVodicaKNavigation)
                    .WithOne(p => p.Korisnici)
                    .HasForeignKey<Korisnici>(d => d.IdVodicaK)
                    .HasConstraintName("IdVodicaK");
            });

            modelBuilder.Entity<Kvizovi>(entity =>
            {
                entity.HasKey(e => e.IdKviza)
                    .HasName("PRIMARY");

                entity.ToTable("kvizovi");

                entity.HasIndex(e => e.IdKviza)
                    .HasName("IdKviza_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdZnamenitostiK)
                    .HasName("IdZnamenitosti_idx");

                entity.Property(e => e.NazivKviza)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdZnamenitostiKNavigation)
                    .WithMany(p => p.Kvizovi)
                    .HasForeignKey(d => d.IdZnamenitostiK)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("IdZnamenitostiK");
            });

            modelBuilder.Entity<OcenjivanjeVodica>(entity =>
            {
                entity.HasKey(e => e.IdOcenjivanja)
                    .HasName("PRIMARY");

                entity.ToTable("ocenjivanjevodica");

                entity.HasIndex(e => e.IdOcenjivanja)
                    .HasName("IdOcenjivanja_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdTureO)
                    .HasName("IdTureO_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdTuristeO)
                    .HasName("IdTuristeO_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdVodicaO)
                    .HasName("IdVodicaO_UNIQUE")
                    .IsUnique();

                entity.HasOne(d => d.IdTureONavigation)
                    .WithOne(p => p.OcenjivanjeVodica)
                    .HasForeignKey<OcenjivanjeVodica>(d => d.IdTureO)
                    .HasConstraintName("IdTureO");

                entity.HasOne(d => d.IdTuristeONavigation)
                    .WithOne(p => p.OcenjivanjeVodica)
                    .HasForeignKey<OcenjivanjeVodica>(d => d.IdTuristeO)
                    .HasConstraintName("IdTuristeO");

                entity.HasOne(d => d.IdVodicaONavigation)
                    .WithOne(p => p.OcenjivanjeVodica)
                    .HasForeignKey<OcenjivanjeVodica>(d => d.IdVodicaO)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("IdVodicaO");
            });

            modelBuilder.Entity<Pitanja>(entity =>
            {
                entity.HasKey(e => e.IdPitanja)
                    .HasName("PRIMARY");

                entity.ToTable("pitanja");

                entity.HasIndex(e => e.IdKviza)
                    .HasName("IdKviza_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdPitanja)
                    .HasName("IdPitanja_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdZnamenitosti)
                    .HasName("IdZnamenitosti_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.OdgovorA)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OdgovorB)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OdgovorC)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TacanOdgovor)
                    .IsRequired()
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TekstPitanja)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdKvizaNavigation)
                    .WithOne(p => p.Pitanja)
                    .HasForeignKey<Pitanja>(d => d.IdKviza)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("IdKviza");

                entity.HasOne(d => d.IdZnamenitostiNavigation)
                    .WithOne(p => p.Pitanja)
                    .HasForeignKey<Pitanja>(d => d.IdZnamenitosti)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("IdZnamenitosti");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.IdRezervacije)
                    .HasName("PRIMARY");

                entity.ToTable("rezervacije");

                entity.HasIndex(e => e.IdRezervacije)
                    .HasName("IdRezervacije_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdTureR)
                    .HasName("IdTureR_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdTuristeR)
                    .HasName("IdTuristeR_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdVodicaR)
                    .HasName("IdVodicaR_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.HasOne(d => d.IdTureRNavigation)
                    .WithOne(p => p.Rezervacije)
                    .HasForeignKey<Rezervacije>(d => d.IdTureR)
                    .HasConstraintName("IdTureR");

                entity.HasOne(d => d.IdTuristeRNavigation)
                    .WithOne(p => p.Rezervacije)
                    .HasForeignKey<Rezervacije>(d => d.IdTuristeR)
                    .HasConstraintName("IdTuristeR");

                entity.HasOne(d => d.IdVodicaRNavigation)
                    .WithOne(p => p.Rezervacije)
                    .HasForeignKey<Rezervacije>(d => d.IdVodicaR)
                    .HasConstraintName("IdVodicaR");
            });

             modelBuilder.Entity<Slike>(entity =>
            {
                entity.HasKey(e => e.IdSlike)
                    .HasName("PRIMARY");

                entity.ToTable("slike");

                entity.HasIndex(e => e.IdZnamenitost)
                    .HasName("IdZnamenitost_idx");

                entity.Property(e => e.IdSlike).HasColumnType("int(11)");

                entity.Property(e => e.IdZnamenitost).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Slika)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdZnamenitostNavigation)
                    .WithMany(p => p.Slike)
                    .HasForeignKey(d => d.IdZnamenitost)
                    .HasConstraintName("IdZnamenitost");
            });

            modelBuilder.Entity<Ture>(entity =>
            {
                entity.HasKey(e => e.IdTure)
                    .HasName("PRIMARY");

                entity.ToTable("ture");

                entity.HasIndex(e => e.IdTure)
                    .HasName("IdTure_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdVodica)
                    .HasName("IdVodica_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DanOdrzavanja)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MestoPolaska)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NazivTure)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Opis)
                    .HasColumnType("varchar(5000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TipTure)
                    .IsRequired()
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.VremeOdrzavanja)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdVodicaNavigation)
                    .WithOne(p => p.Ture)
                    .HasForeignKey<Ture>(d => d.IdVodica)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("IdVodica");
            });

            modelBuilder.Entity<Turisti>(entity =>
            {
                entity.HasKey(e => e.IdTuriste)
                    .HasName("PRIMARY");

                entity.ToTable("turisti");

                entity.HasIndex(e => e.IdTuriste)
                    .HasName("IdTuriste_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DatumRodjenja).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ImeTuriste)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pol)
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PrezimeTuriste)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Vodici>(entity =>
            {
                entity.HasKey(e => e.IdVodica)
                    .HasName("PRIMARY");

                entity.ToTable("vodici");

                entity.HasIndex(e => e.IdVodica)
                    .HasName("IdVodica_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.BrojTelefona)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DatumRodjenja).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                    
                entity.Property(e => e.Slika)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ImeVodica)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Licenca)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Ocena).HasColumnType("decimal(2,2)");

                entity.Property(e => e.Pol)
                    .IsRequired()
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PrezimeVodica)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Znamenitosti>(entity =>
            {
                entity.HasKey(e => e.IdZnamenitosti)
                    .HasName("PRIMARY");

                entity.ToTable("znamenitosti");

                entity.HasIndex(e => e.IdZnamenitosti)
                    .HasName("IdZnamenitosti_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.BrojTelefona)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CenaUlaznice)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Lokacija)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NazivZnamenitosti)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Opis)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.RadnoVreme)
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                
                entity.Property(e => e.Slika)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

            });

            modelBuilder.Entity<ZnamenitostiUTurama>(entity =>
            {
                entity.HasKey(e => new { e.IdZnamenitostiZut, e.IdTureZut })
                    .HasName("PRIMARY");

                entity.ToTable("znamenitostiuturama");

                entity.HasIndex(e => e.IdTureZut)
                    .HasName("IdTure_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdZnamenitostiZut)
                    .HasName("IdZnamenitosti_UNIQUE")
                    .IsUnique();

                entity.HasOne(d => d.IdTureZutNavigation)
                    .WithOne(p => p.ZnamenitostiUTurama)
                    .HasForeignKey<ZnamenitostiUTurama>(d => d.IdTureZut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdTureZut");

                entity.HasOne(d => d.IdZnamenitostiZutNavigation)
                    .WithOne(p => p.ZnamenitostiUTurama)
                    .HasForeignKey<ZnamenitostiUTurama>(d => d.IdZnamenitostiZut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdZnamenitostiZut");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
