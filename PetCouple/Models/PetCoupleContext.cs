﻿using System;
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
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=Asura;Initial Catalog=PetCouple;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interaccion>(entity =>
            {
                entity.HasKey(e => e.IdInteraccion)
                    .HasName("PK__Interacc__18BDD9FC9A6244F1");

                entity.Property(e => e.IdInteraccion).HasColumnName("Id_Interaccion");

                entity.HasOne(d => d.Usuario1Navigation)
                    .WithMany(p => p.InteraccionUsuario1Navigation)
                    .HasForeignKey(d => d.Usuario1)
                    .HasConstraintName("fk_1User");

                entity.HasOne(d => d.Usuario2Navigation)
                    .WithMany(p => p.InteraccionUsuario2Navigation)
                    .HasForeignKey(d => d.Usuario2)
                    .HasConstraintName("fk_2User");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__63C76BE2D3DBA6B7");

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
                    .HasMaxLength(2);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.NombreMascota)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NumeroTel)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Raza)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("Usuario")
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
