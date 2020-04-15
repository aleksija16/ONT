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

        public virtual DbSet<Korisnici> Korisnici { get; set; }
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
                optionsBuilder.UseMySql("server=localhost;port=3307;database=swe;uid=root;pwd=root", x => x.ServerVersion("5.7.17-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.Idkorisnika)
                    .HasName("PRIMARY");

                entity.ToTable("korisnici");

                entity.HasIndex(e => e.Idkorisnika)
                    .HasName("idkorisnici_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idkorisnika)
                    .HasColumnName("idkorisnika")
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
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.Idrezervacije)
                    .HasName("PRIMARY");

                entity.ToTable("rezervacije");

                entity.HasIndex(e => e.Idrezervacije)
                    .HasName("idrezervacije_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdtureRez)
                    .HasName("idture_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdturisteRez)
                    .HasName("idturiste_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdvodicaRez)
                    .HasName("idvodica_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idrezervacije)
                    .HasColumnName("idrezervacije")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.DatumIzvodjenja)
                    .HasColumnName("datumIzvodjenja")
                    .HasColumnType("datetime(1)");

                entity.Property(e => e.IdtureRez)
                    .HasColumnName("idtureRez")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdturisteRez)
                    .HasColumnName("idturisteRez")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdvodicaRez)
                    .HasColumnName("idvodicaRez")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.IdtureRezNavigation)
                    .WithOne(p => p.Rezervacije)
                    .HasForeignKey<Rezervacije>(d => d.IdtureRez)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idtureRez");

                entity.HasOne(d => d.IdturisteRezNavigation)
                    .WithOne(p => p.Rezervacije)
                    .HasForeignKey<Rezervacije>(d => d.IdturisteRez)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idturisteRez");

                entity.HasOne(d => d.IdvodicaRezNavigation)
                    .WithOne(p => p.Rezervacije)
                    .HasForeignKey<Rezervacije>(d => d.IdvodicaRez)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idvodicaRez");
            });

            modelBuilder.Entity<Ture>(entity =>
            {
                entity.HasKey(e => e.Idture)
                    .HasName("PRIMARY");

                entity.ToTable("ture");

                entity.HasIndex(e => e.Idture)
                    .HasName("idture_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idture)
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
                entity.HasKey(e => e.Idturiste)
                    .HasName("PRIMARY");

                entity.ToTable("turisti");

                entity.HasIndex(e => e.Idturiste)
                    .HasName("idturiste_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idturiste)
                    .HasColumnName("idturiste")
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedOnAdd();

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

                entity.HasOne(d => d.IdturisteNavigation)
                    .WithOne(p => p.Turisti)
                    .HasForeignKey<Turisti>(d => d.Idturiste)
                    .HasConstraintName("idturiste");
            });

            modelBuilder.Entity<Vodici>(entity =>
            {
                entity.HasKey(e => e.Idvodica)
                    .HasName("PRIMARY");

                entity.ToTable("vodici");

                entity.HasIndex(e => e.Idvodica)
                    .HasName("idvodica_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idvodica)
                    .HasColumnName("idvodica")
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedOnAdd();

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

                entity.HasOne(d => d.IdvodicaNavigation)
                    .WithOne(p => p.Vodici)
                    .HasForeignKey<Vodici>(d => d.Idvodica)
                    .HasConstraintName("idvodica");
            });

            modelBuilder.Entity<Znamenitosti>(entity =>
            {
                entity.HasKey(e => e.Idznamenitosti)
                    .HasName("PRIMARY");

                entity.ToTable("znamenitosti");

                entity.HasIndex(e => e.Idznamenitosti)
                    .HasName("idznamenitosti_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idznamenitosti)
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
