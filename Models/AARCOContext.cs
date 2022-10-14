using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AARCOAPI.Models
{
    public partial class AARCOContext : DbContext
    {
        public AARCOContext()
        {
        }

        public AARCOContext(DbContextOptions<AARCOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Descripcion> Descripcions { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Submarca> Submarcas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server= JOSE-ESTRADA\\MSSQLSERVER01;Database=AARCO; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Descripcion>(entity =>
            {
                entity.ToTable("Descripcion");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Descripcion");

                entity.Property(e => e.DescripcionId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Descripcions)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idModelo");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Marca1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Marca");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("Modelo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdSubMarca).HasColumnName("idSubMarca");

                entity.Property(e => e.Modelo1).HasColumnName("Modelo");

                entity.HasOne(d => d.IdSubMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdSubMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idSubMarca");
            });

            modelBuilder.Entity<Submarca>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.Submarca1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Submarca");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Submarcas)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idMarca");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contra)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("contra");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
