using System;
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

    public virtual DbSet<Actividades> Actividades { get; set; }

    public virtual DbSet<Implementos> Implementos { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Maquinarias> Maquinarias { get; set; }

    public virtual DbSet<Planes> Planes { get; set; }

    public virtual DbSet<Rutinas> Rutinas { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Valoraciones> Valoraciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HNG3HQ1\\SQLEXPRESS; Database=GymEtitc; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividades>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("PK__activida__DCD34883D99C966C");

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

        modelBuilder.Entity<Implementos>(entity =>
        {
            entity.HasKey(e => e.IdImplemento).HasName("PK__implemen__A5EEC5D0CBAED87E");

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

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("PK__login__068B3EBB688A34C5");

            entity.ToTable("login");

            entity.Property(e => e.IdLogin).HasColumnName("idLogin");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("apellidoUsuario");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("correoUsuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.PasswordUsuario)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("passwordUsuario");
        });

        modelBuilder.Entity<Maquinarias>(entity =>
        {
            entity.HasKey(e => e.IdMaquinaria).HasName("PK__maquinar__8B61DA975FF9DAA8");

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

        modelBuilder.Entity<Planes>(entity =>
        {
            entity.HasKey(e => e.IdPlan).HasName("PK__planes__3901EAE34DC5C5FD");

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

        modelBuilder.Entity<Rutinas>(entity =>
        {
            entity.HasKey(e => e.IdRutina).HasName("PK__rutinas__A28496679F38D2D4");

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

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD397D4593");

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
                .HasConstraintName("FK__usuarios__id_pla__440B1D61");
        });

        modelBuilder.Entity<Valoraciones>(entity =>
        {
            entity.HasKey(e => e.IdValoracion).HasName("PK__valoraci__1861B249D66427F7");

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
                .HasConstraintName("FK__valoracio__id_us__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
