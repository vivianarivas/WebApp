using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Models;

public partial class InmobiliariaContext : DbContext
{
    public InmobiliariaContext()
    {
    }

    public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Condicion> Condicions { get; set; }

    public virtual DbSet<FormaPago> FormaPagos { get; set; }

    public virtual DbSet<Inmueble> Inmuebles { get; set; }

    public virtual DbSet<TipoInmueble> TipoInmuebles { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("server=localhost; database=Inmobiliaria; integrated security=true; Encrypt=False;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__677F38F50E158137");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("id_cliente");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_cliente");
            entity.Property(e => e.DirCliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dir_cliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_cliente");
            entity.Property(e => e.TelefonoCliente)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("telefono_cliente");
        });

        modelBuilder.Entity<Condicion>(entity =>
        {
            entity.HasKey(e => e.IdCondicion).HasName("PK__Condicio__C923740093DA2B3F");

            entity.ToTable("Condicion");

            entity.Property(e => e.IdCondicion)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("id_condicion");
            entity.Property(e => e.DescCondicion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desc_condicion");
        });

        modelBuilder.Entity<FormaPago>(entity =>
        {
            entity.HasKey(e => e.IdFormaPago).HasName("PK__Forma_Pa__DA9B39EE24C58295");

            entity.ToTable("Forma_Pago");

            entity.Property(e => e.IdFormaPago)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("id_forma_pago");
            entity.Property(e => e.DescFormaPago)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desc_forma_pago");
        });

        modelBuilder.Entity<Inmueble>(entity =>
        {
            entity.HasKey(e => e.IdInmueble).HasName("PK__Inmueble__82C5A282A8C5713A");

            entity.ToTable("Inmueble");

            entity.Property(e => e.IdInmueble)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("id_inmueble");
            entity.Property(e => e.CostoInmueble)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("costo_inmueble");
            entity.Property(e => e.DescInmueble)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desc_inmueble");
            entity.Property(e => e.UbicacionInmueble)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ubicacion_inmueble");
        });

        modelBuilder.Entity<TipoInmueble>(entity =>
        {
            entity.HasKey(e => e.IdTipoInmueble).HasName("PK__Tipo_Inm__007461719995D6A4");

            entity.ToTable("Tipo_Inmueble");

            entity.Property(e => e.IdTipoInmueble)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("id_tipo_inmueble");
            entity.Property(e => e.DescInmueble)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desc_inmueble");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__459533BFB2C89019");

            entity.Property(e => e.IdVenta)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("id_venta");
            entity.Property(e => e.DescVenta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desc_venta");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("date")
                .HasColumnName("fecha_venta");
            entity.Property(e => e.IdCliente)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("id_cliente");
            entity.Property(e => e.IdCondicion)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("id_condicion");
            entity.Property(e => e.IdFormaPago)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("id_forma_pago");
            entity.Property(e => e.IdInmueble)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("id_inmueble");
            entity.Property(e => e.TotalGral)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("total_gral");
            entity.Property(e => e.TotalIva)
                .HasColumnType("numeric(8, 2)")
                .HasColumnName("total_iva");
            entity.Property(e => e.TotalVenta)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total_venta");
            entity.Property(e => e.TotalVentas)
                .HasColumnType("numeric(8, 2)")
                .HasColumnName("total_ventas");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cliente");

            entity.HasOne(d => d.IdCondicionNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCondicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Condicion");

            entity.HasOne(d => d.IdFormaPagoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdFormaPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Forma_Pago");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Inmueble");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
