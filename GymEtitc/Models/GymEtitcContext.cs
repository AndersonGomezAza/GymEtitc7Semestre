﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GymEtitc.Models;

public partial class GymEtitcContext : DbContext
{
    public GymEtitcContext()
    {
    }

    public GymEtitcContext(DbContextOptions<GymEtitcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividade> Actividades { get; set; }

    public virtual DbSet<Implemento> Implementos { get; set; }

    public virtual DbSet<Maquinaria> Maquinarias { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Rutina> Rutinas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Valoracione> Valoraciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HNG3HQ1\\SQLEXPRESS; Database=GymEtitc; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividade>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("PK__activida__DCD34883C155B66B");

            entity.ToTable("actividades");

            entity.Property(e => e.IdActividad).HasColumnName("id_actividad");
            entity.Property(e => e.CategoriaActividad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("categoria_actividad");
            entity.Property(e => e.DescripcionActividad)
                .HasColumnType("text")
                .HasColumnName("descripcion_actividad");
            entity.Property(e => e.DuracionMinActividad).HasColumnName("duracion_min_actividad");
        });

        modelBuilder.Entity<Implemento>(entity =>
        {
            entity.HasKey(e => e.IdImplemento).HasName("PK__implemen__A5EEC5D06E66D1E4");

            entity.ToTable("implementos");

            entity.Property(e => e.IdImplemento).HasColumnName("id_implemento");
            entity.Property(e => e.CategoriaImplemento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("categoria_implemento");
            entity.Property(e => e.DescripcionImplemento)
                .HasColumnType("text")
                .HasColumnName("descripcion_implemento");
            entity.Property(e => e.NombreImplemento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_implemento");
            entity.Property(e => e.SerialImplemento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("serial_implemento");
        });

        modelBuilder.Entity<Maquinaria>(entity =>
        {
            entity.HasKey(e => e.IdMaquinaria).HasName("PK__maquinar__8B61DA9769B1D29A");

            entity.ToTable("maquinarias");

            entity.Property(e => e.IdMaquinaria).HasColumnName("id_maquinaria");
            entity.Property(e => e.CategoriaMaquinaria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("categoria_maquinaria");
            entity.Property(e => e.DescripcionMaquinaria)
                .HasColumnType("text")
                .HasColumnName("descripcion_maquinaria");
            entity.Property(e => e.EstadoMaquinaria)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado_maquinaria");
            entity.Property(e => e.NombreMaquinaria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_maquinaria");
            entity.Property(e => e.SerialMaquinaria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("serial_maquinaria");
        });

        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.IdPlan).HasName("PK__planes__3901EAE34733424F");

            entity.ToTable("planes");

            entity.Property(e => e.IdPlan).HasColumnName("id_plan");
            entity.Property(e => e.DescripcionPlan)
                .HasColumnType("text")
                .HasColumnName("descripcion_plan");
            entity.Property(e => e.DuracionMesesPlan).HasColumnName("duracion_meses_plan");
            entity.Property(e => e.ValorPlan)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_plan");
        });

        modelBuilder.Entity<Rutina>(entity =>
        {
            entity.HasKey(e => e.IdRutina).HasName("PK__rutinas__A28496675A154BCD");

            entity.ToTable("rutinas");

            entity.Property(e => e.IdRutina).HasColumnName("id_rutina");
            entity.Property(e => e.CaloriasRutina).HasColumnName("calorias_rutina");
            entity.Property(e => e.CategoriaRutina)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("categoria_rutina");
            entity.Property(e => e.DescripcionRutina)
                .HasColumnType("text")
                .HasColumnName("descripcion_rutina");
            entity.Property(e => e.NombreRutina)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_rutina");
            entity.Property(e => e.TiempoRutinaMin).HasColumnName("tiempo_rutina_min");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD1D477F6A");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdPlan).HasColumnName("id_plan");
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NumDocumento).HasColumnName("num_documento");
            entity.Property(e => e.Rol)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipo_doc");

            entity.HasOne(d => d.IdPlanNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuarios__id_pla__412EB0B6");
        });

        modelBuilder.Entity<Valoracione>(entity =>
        {
            entity.HasKey(e => e.IdValoracion).HasName("PK__valoraci__1861B249C64F999B");

            entity.ToTable("valoraciones");

            entity.Property(e => e.IdValoracion).HasColumnName("id_valoracion");
            entity.Property(e => e.CategoriaValoracion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria_valoracion");
            entity.Property(e => e.DescripcionValoracion)
                .HasColumnType("text")
                .HasColumnName("descripcion_valoracion");
            entity.Property(e => e.FechaValoracion)
                .HasColumnType("date")
                .HasColumnName("fecha_valoracion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.RecomendacionValoracion).HasColumnName("recomendacion_valoracion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Valoraciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__valoracio__id_us__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
