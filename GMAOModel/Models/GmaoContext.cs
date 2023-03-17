using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GMAOModel.Models;

public partial class GmaoContext : DbContext
{
    public GmaoContext()
    {
    }

    public GmaoContext(DbContextOptions<GmaoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacene> Almacenes { get; set; }

    public virtual DbSet<AlmacenesRepuesto> AlmacenesRepuestos { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<FichajesOperario> FichajesOperarios { get; set; }

    public virtual DbSet<Operario> Operarios { get; set; }

    public virtual DbSet<OperariosTipo> OperariosTipos { get; set; }

    public virtual DbSet<Parte> Partes { get; set; }

    public virtual DbSet<PartesCorrectivo> PartesCorrectivos { get; set; }

    public virtual DbSet<PartesEstado> PartesEstados { get; set; }

    public virtual DbSet<PartesEstadoAprobacion> PartesEstadoAprobacions { get; set; }

    public virtual DbSet<PartesExterno> PartesExternos { get; set; }

    public virtual DbSet<PartesExternosCompra> PartesExternosCompras { get; set; }

    public virtual DbSet<PartesFichaje> PartesFichajes { get; set; }

    public virtual DbSet<PartesInterno> PartesInternos { get; set; }

    public virtual DbSet<PartesInternosAlmacenesPuesto> PartesInternosAlmacenesPuestos { get; set; }

    public virtual DbSet<PartesOperario> PartesOperarios { get; set; }

    public virtual DbSet<PartesPreventivo> PartesPreventivos { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<PuestosUtillaje> PuestosUtillajes { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<Utillaje> Utillajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TestSQL2019; Database=GMAO; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacene>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AlmacenesRepuesto>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idalmacen).HasColumnName("IDAlmacen");
            entity.Property(e => e.Idrepuestos).HasColumnName("IDRepuestos");

            entity.HasOne(d => d.IdalmacenNavigation).WithMany(p => p.AlmacenesRepuestos)
                .HasForeignKey(d => d.Idalmacen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlmacenesRepuestos_AlmacenesRepuestos");

            entity.HasOne(d => d.IdrepuestosNavigation).WithMany(p => p.AlmacenesRepuestos)
                .HasForeignKey(d => d.Idrepuestos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlmacenesRepuestos_Repuestos");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idpartes).HasColumnName("IDPartes");
            entity.Property(e => e.RutaDocumento)
                .HasMaxLength(512)
                .IsUnicode(false);

            entity.HasOne(d => d.IdpartesNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.Idpartes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documentos_Partes");
        });

        modelBuilder.Entity<FichajesOperario>(entity =>
        {
            entity.HasKey(e => new { e.Idfichajes, e.Idoperarios });

            entity.Property(e => e.Idfichajes).HasColumnName("IDFichajes");
            entity.Property(e => e.Idoperarios).HasColumnName("IDOperarios");
        });

        modelBuilder.Entity<Operario>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Extension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OperariosTipo>(entity =>
        {
            entity.ToTable("OperariosTipo");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Parte>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<PartesCorrectivo>(entity =>
        {
            entity.HasKey(e => e.Idparte);

            entity.Property(e => e.Idparte)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDParte");

            entity.HasOne(d => d.IdparteNavigation).WithOne(p => p.PartesCorrectivo)
                .HasForeignKey<PartesCorrectivo>(d => d.Idparte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartesCorrectivos_Partes");
        });

        modelBuilder.Entity<PartesEstado>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PartesEstadoAprobacion>(entity =>
        {
            entity.ToTable("PartesEstadoAprobacion");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PartesExterno>(entity =>
        {
            entity.HasKey(e => e.Idpartes).HasName("PK_PartesExternos_1");

            entity.Property(e => e.Idpartes)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDPartes");

            entity.HasOne(d => d.IdpartesNavigation).WithOne(p => p.PartesExterno)
                .HasForeignKey<PartesExterno>(d => d.Idpartes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartesExternos_Partes");
        });

        modelBuilder.Entity<PartesExternosCompra>(entity =>
        {
            entity.HasKey(e => new { e.IdpartesExternos, e.Idcompras });

            entity.Property(e => e.IdpartesExternos).HasColumnName("IDPartesExternos");
            entity.Property(e => e.Idcompras).HasColumnName("IDCompras");
        });

        modelBuilder.Entity<PartesFichaje>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idparte).HasColumnName("IDParte");
        });

        modelBuilder.Entity<PartesInterno>(entity =>
        {
            entity.HasKey(e => e.Idpartes);

            entity.Property(e => e.Idpartes)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDPartes");

            entity.HasOne(d => d.IdpartesNavigation).WithOne(p => p.PartesInterno)
                .HasForeignKey<PartesInterno>(d => d.Idpartes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartesInternos_Partes");
        });

        modelBuilder.Entity<PartesInternosAlmacenesPuesto>(entity =>
        {
            entity.HasKey(e => new { e.IdpartesInternos, e.IdalmacenesRepuestos });

            entity.Property(e => e.IdpartesInternos).HasColumnName("IDPartesInternos");
            entity.Property(e => e.IdalmacenesRepuestos).HasColumnName("IDAlmacenesRepuestos");
        });

        modelBuilder.Entity<PartesOperario>(entity =>
        {
            entity.HasKey(e => new { e.Idparte, e.Idoperario });

            entity.Property(e => e.Idparte).HasColumnName("IDParte");
            entity.Property(e => e.Idoperario).HasColumnName("IDOperario");
        });

        modelBuilder.Entity<PartesPreventivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PartePreventivo");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PuestosUtillaje>(entity =>
        {
            entity.HasKey(e => new { e.Idpuestos, e.Idutillajes });

            entity.Property(e => e.Idpuestos).HasColumnName("IDPuestos");
            entity.Property(e => e.Idutillajes).HasColumnName("IDUtillajes");
        });

        modelBuilder.Entity<Repuesto>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Utillaje>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
