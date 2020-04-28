using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Projekat_1.Model
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

        public virtual DbSet<HallOfFame> HallOfFame { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Kviz> Kviz { get; set; }
        public virtual DbSet<OcenjivanjeVodica> OcenjivanjeVodica { get; set; }
        public virtual DbSet<Pitanje> Pitanje { get; set; }
        public virtual DbSet<Rezervacije> Rezervacije { get; set; }
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
            modelBuilder.Entity<HallOfFame>(entity =>
            {
                entity.HasKey(e => e.RedniBroj)
                    .HasName("PRIMARY");

                entity.ToTable("halloffame");

                entity.Property(e => e.RedniBroj).HasColumnName("rednibroj");

                entity.Property(e => e.BrojPoena).HasColumnName("brojpoena");

                entity.Property(e => e.ImeTuriste)
                    .IsRequired()
                    .HasColumnName("imeturiste")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PrezimeTuriste)
                    .IsRequired()
                    .HasColumnName("prezimeturiste")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.IdKorisnika)
                    .HasName("PRIMARY");

                entity.ToTable("korisnici");

                entity.HasIndex(e => e.IdKorisnika)
                    .HasName("idkorisnici_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdKorisnika).HasColumnName("idkorisnika");

                entity.Property(e => e.IdTuristeKor).HasColumnName("idturisteKor");

                entity.Property(e => e.IdVodicaKor).HasColumnName("idvodicaKor");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Kviz>(entity =>
            {
                entity.HasKey(e => e.IdKviz)
                    .HasName("PRIMARY");

                entity.ToTable("kviz");

                entity.Property(e => e.IdKviz).HasColumnName("idkviz");

                entity.Property(e => e.NazivKviza)
                    .IsRequired()
                    .HasColumnName("nazivkviza")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<OcenjivanjeVodica>(entity =>
            {
                entity.HasKey(e => e.IdOcenjivanjeVodica)
                    .HasName("PRIMARY");

                entity.ToTable("ocenjivanjevodica");

                entity.Property(e => e.IdOcenjivanjeVodica).HasColumnName("idocenjivanjevodica");

                entity.Property(e => e.IdVodicaOcenjivanje).HasColumnName("idvodicaOcenjivanje");

                entity.Property(e => e.Ocena).HasColumnName("ocena");
            });

            modelBuilder.Entity<Pitanje>(entity =>
            {
                entity.HasKey(e => e.IdPitanje)
                    .HasName("PRIMARY");

                entity.ToTable("pitanje");

                entity.HasIndex(e => e.KvizId)
                    .HasName("KvizId_idx");

                entity.Property(e => e.Opa)
                    .HasColumnName("OPA")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Opb)
                    .HasColumnName("OPB")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Opc)
                    .HasColumnName("OPC")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PitanjeTekst)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tacan)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Kviz)
                    .WithMany(p => p.Pitanje)
                    .HasForeignKey(d => d.KvizId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("KvizId");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.IdRezervacije)
                    .HasName("PRIMARY");

                entity.ToTable("rezervacije");

                entity.HasIndex(e => e.IdTureRez)
                    .HasName("idTureRez_idx");

                entity.HasIndex(e => e.IdTuristeRez)
                    .HasName("idTuristeRez_idx");

                entity.HasIndex(e => e.IdVodicaRez)
                    .HasName("idVodicaRez_idx");

                entity.Property(e => e.IdRezervacije).HasColumnName("idrezervacije");

                entity.Property(e => e.BrojOsoba).HasColumnName("brojOsoba");

                entity.Property(e => e.DatumIzvodjenja)
                    .HasColumnName("datumIzvodjenja")
                    .HasColumnType("datetime(1)");

                entity.Property(e => e.IdTureRez).HasColumnName("idTureRez");

                entity.Property(e => e.IdTuristeRez).HasColumnName("idturisteRez");

                entity.Property(e => e.IdVodicaRez).HasColumnName("idvodicaRez");

                entity.HasOne(d => d.IdTureRezNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.IdTureRez)
                    .HasConstraintName("idTureRez");

                entity.HasOne(d => d.IdTuristeRezNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.IdTuristeRez)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idTuristeRez");

                entity.HasOne(d => d.IdVodicaRezNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.IdVodicaRez)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idVodicaRez");
            });

            modelBuilder.Entity<Ture>(entity =>
            {
                entity.HasKey(e => e.IdTure)
                    .HasName("PRIMARY");

                entity.ToTable("ture");

                entity.HasIndex(e => e.IdVodicaTura)
                    .HasName("idVodicaTura_idx");

                entity.HasIndex(e => e.IdTure)
                    .HasName("idture_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTure).HasColumnName("idture");

                entity.Property(e => e.DatumOdrzavanja)
                    .HasColumnName("datumOdrzavanja")
                    .HasColumnType("date");

                entity.Property(e => e.IdVodicaTura).HasColumnName("idVodicaTura");

                entity.Property(e => e.NazivTure)
                    .HasColumnName("nazivTure")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.TrajanjeTure).HasColumnName("trajanjeTure");

                entity.Property(e => e.VremeOdrzavanja)
                    .HasColumnName("vremeOdrzavanja")
                    .HasColumnType("time");

                entity.HasOne(d => d.IdVodicaTuraNavigation)
                    .WithMany(p => p.Ture)
                    .HasForeignKey(d => d.IdVodicaTura)
                    .HasConstraintName("idVodicaTura");
            });

            modelBuilder.Entity<Turisti>(entity =>
            {
                entity.HasKey(e => e.IdTuriste)
                    .HasName("PRIMARY");

                entity.ToTable("turisti");

                entity.HasIndex(e => e.IdTuriste)
                    .HasName("idturiste_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTuriste).HasColumnName("idturiste");

                entity.Property(e => e.DatumRodjenja)
                    .HasColumnName("datumRodjenja")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ImeTuriste)
                    .IsRequired()
                    .HasColumnName("imeTuriste")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Pol)
                    .HasColumnName("pol")
                    .HasColumnType("char(1)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PrezimeTuriste)
                    .HasColumnName("prezimeTuriste")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Vodici>(entity =>
            {
                entity.HasKey(e => e.IdVodica)
                    .HasName("PRIMARY");

                entity.ToTable("vodici");

                entity.HasIndex(e => e.IdVodica)
                    .HasName("idvodica_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdVodica).HasColumnName("idvodica");

                entity.Property(e => e.BrojTelefona)
                    .HasColumnName("brojTelefona")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ImeVodica)
                    .HasColumnName("imeVodica")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Ocena).HasColumnName("ocena");

                entity.Property(e => e.Pol)
                    .HasColumnName("pol")
                    .HasColumnType("char(1)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PrezimeVodica)
                    .HasColumnName("prezimeVodica")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Znamenitosti>(entity =>
            {
                entity.HasKey(e => e.IdZnamenitosti)
                    .HasName("PRIMARY");

                entity.ToTable("znamenitosti");

                entity.HasIndex(e => e.IdZnamenitosti)
                    .HasName("idznamenitosti_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdZnamenitosti).HasColumnName("idznamenitosti");

                entity.Property(e => e.LokacijaZnamenitosti)
                    .HasColumnName("lokacijaZnamenitosti")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NazivZnamenitosti)
                    .HasColumnName("nazivZnamenitosti")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

             modelBuilder.Entity<ZnamenitostiUTurama>(entity =>
            {
                entity.HasKey(e => new { e.TuraId, e.ZnamenitostId })
                    .HasName("PRIMARY");

                entity.ToTable("znamenitostiuturama");

                entity.HasIndex(e => e.TuraId)
                    .HasName("TuraId_idx");

                entity.HasIndex(e => e.ZnamenitostId)
                    .HasName("ZnamenitostID_idx");

                entity.Property(e => e.TuraId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.ZnamenitostId).HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Tura)
                    .WithMany(p => p.ZnamenitostiUTurama)
                    .HasForeignKey(d => d.TuraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TuraId");

                entity.HasOne(d => d.Znamenitost)
                    .WithMany(p => p.ZnamenitostiUTurama)
                    .HasForeignKey(d => d.ZnamenitostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ZnamenitostID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
