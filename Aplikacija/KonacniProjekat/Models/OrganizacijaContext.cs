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
        public virtual DbSet<Slike> Slike { get; set; }
        public virtual DbSet<Ture> Ture { get; set; }
        public virtual DbSet<Turisti> Turisti { get; set; }
        public virtual DbSet<Vodici> Vodici { get; set; }
        public virtual DbSet<Znamenitosti> Znamenitosti { get; set; }
        public virtual DbSet<ZnamenitostiUTurama> ZnamenitostiUTurama { get; set; }

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

                entity.HasIndex(e => e.IdTureAnk)
                    .HasName("IdTureAnk_idx");

                entity.HasIndex(e => e.IdTuristeAnk)
                    .HasName("IdTuristeAnk_idx");

                entity.HasIndex(e => e.IdVodicaAnk)
                    .HasName("IdVodicaAnk_idx");

				entity.Property(e => e.IdAnkete).HasColumnType("int(10) unsigned");																   
				entity.Property(e => e.FizickaZahtevnostTure).HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdTureAnk).HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdTuristeAnk).HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdVodicaAnk).HasColumnType("int(10) unsigned");

                entity.Property(e => e.InformisanostVodica).HasColumnType("int(10) unsigned");						  																																																																											   																					  
				entity.Property(e => e.Komentar)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
				entity.Property(e => e.KonacnaOcena).HasColumnType("int(10) unsigned");																	   

                entity.Property(e => e.NajdosadnijaZnamenitost)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NajinteresantnijaZnamenitost)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

				 entity.Property(e => e.OrganizovanostTure).HasColumnType("int(10) unsigned");																			 
                entity.Property(e => e.TipTuriste)
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

                entity.HasIndex(e => e.IdKvizaHof)
                    .HasName("IdKviza_idx");

                entity.HasIndex(e => e.IdTuristeHof)
                    .HasName("IdTuristeHof_idx");

                entity.Property(e => e.DatumRadjenja).HasColumnType("date");

                entity.HasOne(d => d.IdKvizaHofNavigation)
                    .WithMany(p => p.HallOfFame)
                    .HasForeignKey(d => d.IdKvizaHof)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdKvizaHof");

                entity.HasOne(d => d.IdTuristeHofNavigation)
                    .WithMany(p => p.HallOfFame)
                    .HasForeignKey(d => d.IdTuristeHof)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdTuristeHof");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.IdKorisnika)
                    .HasName("PRIMARY");

                entity.ToTable("korisnici");

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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("IdVodicaK");
            });

            modelBuilder.Entity<Kvizovi>(entity =>
            {
                entity.HasKey(e => e.IdKviza)
                    .HasName("PRIMARY");

                entity.ToTable("kvizovi");

                entity.HasIndex(e => e.IdTureK)
                    .HasName("IdTureK_idx");

                entity.HasIndex(e => e.IdZnamenitostiK)
                    .HasName("IdZnamenitosti_idx");

                entity.Property(e => e.NazivKviza)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdTureKNavigation)
                    .WithMany(p => p.Kvizovi)
                    .HasForeignKey(d => d.IdTureK)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("IdTureK");

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
                    .HasName("IdOcenjivanja_idx");

                entity.HasIndex(e => e.IdTureO)
                    .HasName("IdTureO_idx");

                entity.HasIndex(e => e.IdTuristeO)
                    .HasName("IdTuristeO_idx");

                entity.HasIndex(e => e.IdVodicaO)
                    .HasName("IdVodicaO_idx");

                entity.HasOne(d => d.IdTureONavigation)
                    .WithMany(p => p.OcenjivanjeVodica)
                    .HasForeignKey(d => d.IdTureO)
                    .HasConstraintName("IdTureO");

                entity.HasOne(d => d.IdTuristeONavigation)
                    .WithMany(p => p.OcenjivanjeVodica)
                    .HasForeignKey(d => d.IdTuristeO)
                    .HasConstraintName("IdTuristeO");

                entity.HasOne(d => d.IdVodicaONavigation)
                    .WithMany(p => p.OcenjivanjeVodica)
                    .HasForeignKey(d => d.IdVodicaO)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("IdVodicaO");
            });

            modelBuilder.Entity<Pitanja>(entity =>
            {
                entity.HasKey(e => e.IdPitanja)
                    .HasName("PRIMARY");

                entity.ToTable("pitanja");

                entity.HasIndex(e => e.IdKviza)
                    .HasName("IdKviza_idx");

                entity.HasIndex(e => e.IdZnamenitosti)
                    .HasName("IdZnamenitosti_idx");

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
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TekstPitanja)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdKvizaNavigation)
                    .WithMany(p => p.Pitanja)
                    .HasForeignKey(d => d.IdKviza)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("IdKviza");

                entity.HasOne(d => d.IdZnamenitostiNavigation)
                    .WithMany(p => p.Pitanja)
                    .HasForeignKey(d => d.IdZnamenitosti)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("IdZnamenitosti");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.IdRezervacije)
                    .HasName("PRIMARY");

                entity.ToTable("rezervacije");

                entity.HasIndex(e => e.IdTureR)
                    .HasName("IdTureR_idx");

                entity.HasIndex(e => e.IdTuristeR)
                    .HasName("IdTuristeR_idx");

                entity.HasIndex(e => e.IdVodicaR)
                    .HasName("IdVodicaR_idx");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.HasOne(d => d.IdTureRNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.IdTureR)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdTureR");

                entity.HasOne(d => d.IdTuristeRNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.IdTuristeR)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdTuristeR");

                entity.HasOne(d => d.IdVodicaRNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.IdVodicaR)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdVodicaR");
            });

            modelBuilder.Entity<Slike>(entity =>
            {
                entity.HasKey(e => e.IdSlike)
                    .HasName("PRIMARY");

                entity.ToTable("slike");

                entity.HasIndex(e => e.IdZnamenitost)
                    .HasName("IdZnamenitost_idx");

                entity.Property(e => e.Slika)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

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

                entity.HasIndex(e => e.IdVodica)
                    .HasName("IdVodica_idx");

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
                    .HasColumnType("varchar(100)")
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
                    .WithMany(p => p.Ture)
                    .HasForeignKey(d => d.IdVodica)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("IdVodica");
            });

            modelBuilder.Entity<Turisti>(entity =>
            {
                entity.HasKey(e => e.IdTuriste)
                    .HasName("PRIMARY");

                entity.ToTable("turisti");

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

                entity.Property(e => e.BrojTelefona)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DatumRodjenja).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(45)")
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

                entity.Property(e => e.Ocena).HasColumnType("decimal(4,2)");

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

                entity.Property(e => e.Slika)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Znamenitosti>(entity =>
            {
                entity.HasKey(e => e.IdZnamenitosti)
                    .HasName("PRIMARY");

                entity.ToTable("znamenitosti");

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
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tip)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<ZnamenitostiUTurama>(entity =>
            {
                entity.HasKey(e => e.IdZnamenitostiUTurama)
                    .HasName("PRIMARY");

                entity.ToTable("znamenitostiuturama");

                entity.HasIndex(e => e.IdTureZut)
                    .HasName("IdTureZut_idx");

                entity.HasIndex(e => e.IdZnamenitostiZut)
                    .HasName("IdZnamenitostiZut_idx");

                entity.Property(e => e.IdZnamenitostiUTurama).HasColumnName("IdZnamenitostiUTurama");

                entity.HasOne(d => d.IdTureZutNavigation)
                    .WithMany(p => p.ZnamenitostiUTurama)
                    .HasForeignKey(d => d.IdTureZut)
                    .HasConstraintName("IdTureZut");

                entity.HasOne(d => d.IdZnamenitostiZutNavigation)
                    .WithMany(p => p.ZnamenitostiUTurama)
                    .HasForeignKey(d => d.IdZnamenitostiZut)
                    .HasConstraintName("IdZnamenitostiZut");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
