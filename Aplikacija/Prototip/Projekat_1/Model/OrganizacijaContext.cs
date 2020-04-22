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

        public virtual DbSet<HallofFame> HallofFame { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Kviz> Kviz { get; set; }
        public virtual DbSet<OcenjivanjeVodica> OcenjivanjeVodica { get; set; }
        public virtual DbSet<Odgovor> Odgovor { get; set; }
        public virtual DbSet<Pitanje> Pitanje { get; set; }
        public virtual DbSet<Rezervacije> Rezervacije { get; set; }
        public virtual DbSet<Ture> Ture { get; set; }
        public virtual DbSet<Turisti> Turisti { get; set; }
        public virtual DbSet<Vodici> Vodici { get; set; }
        public virtual DbSet<Znamenitosti> Znamenitosti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=organizacija;user=root;password=root", x => x.ServerVersion("5.7.17-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HallofFame>(entity =>
            {
                entity.HasKey(e => e.RedniBroj)
                    .HasName("PRIMARY");

                entity.ToTable("halloffame");

                entity.Property(e => e.RedniBroj)
                    .HasColumnName("rednibroj")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BrojPoena)
                    .HasColumnName("brojpoena")
                    .HasColumnType("int(10) unsigned");

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
                     entity.HasIndex(e => e.IdTuristeKor)
                    .HasName("iddrugi_idx");

                entity.HasIndex(e => e.IdVodicaKor)
                    .HasName("idvodicaKor_idx");

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdKorisnika)
                    .HasColumnName("idkorisnika")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdTuristeKor)
                    .HasColumnName("idturisteKor")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdVodicaKor)
                    .HasColumnName("idvodicaKor")
                    .HasColumnType("int(10) unsigned");

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

                   entity.HasOne(d => d.IdTuristeKorNavigation)
                    .WithMany(p => p.Korisnici)
                    .HasForeignKey(d => d.IdTuristeKor)
                    .HasConstraintName("idturisteKor");

                      entity.HasOne(d => d.IdVodicaKorNavigation)
                    .WithMany(p => p.Korisnici)
                    .HasForeignKey(d => d.IdVodicaKor)
                    .HasConstraintName("idvodicaKor");
                
            });

            modelBuilder.Entity<Kviz>(entity =>
            {
                entity.HasKey(e => e.Idkviz)
                    .HasName("PRIMARY");

                entity.ToTable("kviz");

                entity.Property(e => e.Idkviz)
                    .HasColumnName("idkviz")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Nazivkviza)
                    .IsRequired()
                    .HasColumnName("nazivkviza")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<OcenjivanjeVodica>(entity =>
            {
                entity.HasKey(e => e.IdOcenjivanjeVodica)
                    .HasName("PRIMARY");

                entity.ToTable("ocenjivanjevodica");

                entity.Property(e => e.IdOcenjivanjeVodica)
                    .HasColumnName("idocenjivanjevodica")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdVodicaOcenjivanje)
                    .HasColumnName("idvodicaOcenjivanje")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Ocena)
                    .HasColumnName("ocena")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<Odgovor>(entity =>
            {
                entity.HasKey(e => e.Idodgovor)
                    .HasName("PRIMARY");

                entity.ToTable("odgovor");

                entity.HasIndex(e => e.Pitanjeid)
                    .HasName("pitanjeid_idx");

                entity.Property(e => e.Idodgovor)
                    .HasColumnName("idodgovor")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Pitanjeid)
                    .HasColumnName("pitanjeid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Tacno)
                    .HasColumnName("tacno")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Tekstodg)
                    .IsRequired()
                    .HasColumnName("tekstodg")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Pitanje)
                    .WithMany(p => p.Odgovor)
                    .HasForeignKey(d => d.Pitanjeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pitanjeid");
            });

            modelBuilder.Entity<Pitanje>(entity =>
            {
                entity.HasKey(e => e.Idpitanje)
                    .HasName("PRIMARY");

                entity.ToTable("pitanje");

                entity.HasIndex(e => e.Kvizid)
                    .HasName("kvizid_idx");

                entity.Property(e => e.Idpitanje)
                    .HasColumnName("idpitanje")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Kvizid)
                    .HasColumnName("kvizid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Tekstpitanja)
                    .IsRequired()
                    .HasColumnName("tekstpitanja")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Kviz)
                    .WithMany(p => p.Pitanje)
                    .HasForeignKey(d => d.Kvizid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kvizid");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.IdRezervacije)
                    .HasName("PRIMARY");

                entity.ToTable("rezervacije");

                entity.Property(e => e.IdRezervacije)
                    .HasColumnName("idrezervacije")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BrojOsoba)
                    .HasColumnName("brojOsoba")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.DatumIzvodjenja)
                    .HasColumnName("datumIzvodjenja")
                    .HasColumnType("datetime(1)");

                entity.Property(e => e.IdTuristeRez)
                    .HasColumnName("idturisteRez")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdVodicaRez)
                    .HasColumnName("idvodicaRez")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<Ture>(entity =>
            {
                entity.HasKey(e => e.IdTure)
                    .HasName("PRIMARY");

                entity.ToTable("ture");

                entity.HasIndex(e => e.IdTure)
                    .HasName("idture_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTure)
                    .HasColumnName("idture")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.NazivTure)
                    .HasColumnName("nazivTure")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.TrajanjeTure)
                    .HasColumnName("trajanjeTure")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<Turisti>(entity =>
            {
                entity.HasKey(e => e.IdTuriste)
                    .HasName("PRIMARY");

                entity.ToTable("turisti");

                entity.HasIndex(e => e.IdTuriste)
                    .HasName("idturiste_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTuriste)
                    .HasColumnName("idturiste")
                    .HasColumnType("int(10) unsigned");

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

                entity.Property(e => e.IdVodica)
                    .HasColumnName("idvodica")
                    .HasColumnType("int(10) unsigned");

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

                entity.Property(e => e.IdZnamenitosti)
                    .HasColumnName("idznamenitosti")
                    .HasColumnType("int(10) unsigned");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
