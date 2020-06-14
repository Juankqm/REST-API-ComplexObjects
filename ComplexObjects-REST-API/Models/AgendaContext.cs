using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ComplexObjects_REST_API.Models
{
    public partial class AgendaContext : DbContext
    {
        public AgendaContext()
        {
        }

        public AgendaContext(DbContextOptions<AgendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<NumeroTelefono> NumeroTelefono { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-V5QUAKD\\LOCALHOST; DataBase=Agenda; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto);

                entity.Property(e => e.IdContacto).HasColumnName("ID_Contacto");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NumeroTelefono>(entity =>
            {
                entity.HasKey(e => e.IdNumeroTelefono);

                entity.Property(e => e.IdNumeroTelefono).HasColumnName("ID_NumeroTelefono");

                entity.Property(e => e.IdContacto).HasColumnName("ID_Contacto");

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.NumeroTelefono)
                    .HasForeignKey(d => d.IdContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NumeroTelefono_Contacto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
