using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class PetCoupleContext : DbContext
    {
        public PetCoupleContext()
        {
        }

        public PetCoupleContext(DbContextOptions<PetCoupleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Interaccion> Interaccion { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Parques> Parques { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:petcoupleserver.database.windows.net,1433;Initial Catalog=PetCouple;Persist Security Info=False;User ID=PetCoupleAdmi;Password=PetCouplecontraseña1.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interaccion>(entity =>
            {
                entity.HasKey(e => e.IdInteraccion)
                    .HasName("PK__Interacc__18BDD9FC990E9190");

                entity.Property(e => e.IdInteraccion).HasColumnName("Id_Interaccion");

                entity.Property(e => e.IdParque).HasColumnName("Id_Parque");

                entity.HasOne(d => d.IdParqueNavigation)
                    .WithMany(p => p.Interaccion)
                    .HasForeignKey(d => d.IdParque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Parque");

                entity.HasOne(d => d.Usuario1Navigation)
                    .WithMany(p => p.InteraccionUsuario1Navigation)
                    .HasForeignKey(d => d.Usuario1)
                    .HasConstraintName("fk_1User");

                entity.HasOne(d => d.Usuario2Navigation)
                    .WithMany(p => p.InteraccionUsuario2Navigation)
                    .HasForeignKey(d => d.Usuario2)
                    .HasConstraintName("fk_2User");
            });

            modelBuilder.Entity<Likes>(entity =>
            {
                entity.HasKey(e => e.IdLikes)
                    .HasName("PK__Likes__F8B73847F9DB7748");

                entity.Property(e => e.IdLikes).HasColumnName("Id_Likes");

                entity.Property(e => e.Like)
                    .HasColumnName("LIKE")
                    .HasMaxLength(2);

                entity.HasOne(d => d.Usuario1Navigation)
                    .WithMany(p => p.LikesUsuario1Navigation)
                    .HasForeignKey(d => d.Usuario1)
                    .HasConstraintName("fk_Like_User1");

                entity.HasOne(d => d.Usuario2Navigation)
                    .WithMany(p => p.LikesUsuario2Navigation)
                    .HasForeignKey(d => d.Usuario2)
                    .HasConstraintName("fk_Like_User2");
            });

            modelBuilder.Entity<Parques>(entity =>
            {
                entity.HasKey(e => e.IdParque)
                    .HasName("PK__Parques__43EDB85E0245FDA9");

                entity.Property(e => e.IdParque).HasColumnName("Id_Parque");

                entity.Property(e => e.Lugar)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__Tipo__0641639266400D82");

                entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");

                entity.Property(e => e.NombreTipo)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__63C76BE209F22CC1");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Delegacion)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EdadMascota)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");

                entity.Property(e => e.Identficador).IsRequired();

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.NombreMascota)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NumeroTel)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
