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

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Delegacion> Delegacion { get; set; }
        public virtual DbSet<Interaccion> Interaccion { get; set; }
        public virtual DbSet<Mascotas> Mascotas { get; set; }
        public virtual DbSet<Mensajes> Mensajes { get; set; }
        public virtual DbSet<Notificaciones> Notificaciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosNormales> UsuariosNormales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=Asura;Initial Catalog=PetCouple;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__2D89616FB02599DD");

                entity.Property(e => e.IdAdministrador).HasColumnName("ID_Administrador");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Administrador");
            });

            modelBuilder.Entity<Delegacion>(entity =>
            {
                entity.HasKey(e => e.IdDelegacion)
                    .HasName("PK__Delegaci__037D7DBD89EE649E");

                entity.Property(e => e.IdDelegacion).HasColumnName("ID_Delegacion");

                entity.Property(e => e.Delegacion1)
                    .IsRequired()
                    .HasColumnName("Delegacion")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Interaccion>(entity =>
            {
                entity.HasKey(e => e.IdInteraccion)
                    .HasName("PK__Interacc__0D3BA586425C64CD");

                entity.Property(e => e.IdInteraccion).HasColumnName("ID_Interaccion");

                entity.Property(e => e.IdMensaje).HasColumnName("ID_Mensaje");

                entity.Property(e => e.IdNotificacion).HasColumnName("ID_Notificacion");

                entity.HasOne(d => d.IdMensajeNavigation)
                    .WithMany(p => p.Interaccion)
                    .HasForeignKey(d => d.IdMensaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Mensaje_I");

                entity.HasOne(d => d.IdNotificacionNavigation)
                    .WithMany(p => p.Interaccion)
                    .HasForeignKey(d => d.IdNotificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Notificacion_I");
            });

            modelBuilder.Entity<Mascotas>(entity =>
            {
                entity.HasKey(e => e.IdMascota)
                    .HasName("PK__Mascotas__6351523015D0A725");

                entity.Property(e => e.IdMascota).HasColumnName("ID_Mascota");

                entity.Property(e => e.EdadMascota)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.NombreMascota)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Raza)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Mensajes>(entity =>
            {
                entity.HasKey(e => e.IdMensaje)
                    .HasName("PK__Mensajes__350DB61E94A10F1E");

                entity.Property(e => e.IdMensaje).HasColumnName("ID_Mensaje");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Notificaciones>(entity =>
            {
                entity.HasKey(e => e.IdNotificaciones)
                    .HasName("PK__Notifica__FC97AC770F41385A");

                entity.Property(e => e.IdNotificaciones)
                    .HasColumnName("ID_Notificaciones")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdMascota).HasColumnName("ID_Mascota");

                entity.Property(e => e.IdUsuarioNormal).HasColumnName("ID_UsuarioNormal");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__DE4431C578C62347");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UsuariosNormales>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioNormal)
                    .HasName("PK__Usuarios__DA5C19911F68CE2C");

                entity.Property(e => e.IdUsuarioNormal).HasColumnName("ID_UsuarioNormal");

                entity.Property(e => e.IdDelegacion).HasColumnName("ID_Delegacion");

                entity.Property(e => e.IdInteraccion).HasColumnName("ID_Interaccion");

                entity.Property(e => e.IdMascota).HasColumnName("ID_Mascota");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.NumeroTel)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdDelegacionNavigation)
                    .WithMany(p => p.UsuariosNormales)
                    .HasForeignKey(d => d.IdDelegacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Delegacion");

                entity.HasOne(d => d.IdInteraccionNavigation)
                    .WithMany(p => p.UsuariosNormales)
                    .HasForeignKey(d => d.IdInteraccion)
                    .HasConstraintName("fk_Interaccion");

                entity.HasOne(d => d.IdMascotaNavigation)
                    .WithMany(p => p.UsuariosNormales)
                    .HasForeignKey(d => d.IdMascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Mascota");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosNormales)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Normal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
