using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gtech.Models;

public partial class GtechContext : DbContext
{
    public GtechContext()
    {
    }

    public GtechContext(DbContextOptions<GtechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividade> Actividades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ComprobantesPago> ComprobantesPagos { get; set; }

    public virtual DbSet<ComprobantesRecepcion> ComprobantesRecepcions { get; set; }

    public virtual DbSet<DetallesRepuestosInsumo> DetallesRepuestosInsumos { get; set; }

    public virtual DbSet<DetallesServicio> DetallesServicios { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Modalidade> Modalidades { get; set; }

    public virtual DbSet<OrdenesCompra> OrdenesCompras { get; set; }

    public virtual DbSet<OrdenesTrabajo> OrdenesTrabajos { get; set; }

    public virtual DbSet<PresupuestosTrabajo> PresupuestosTrabajos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<RepuestosInsumo> RepuestosInsumos { get; set; }

    public virtual DbSet<Trabajadore> Trabajadores { get; set; }

 //   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
 //       => optionsBuilder.UseSqlite("Data Source=gtech.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividade>(entity =>
        {
            entity.HasKey(e => e.ActividadId);

            entity.Property(e => e.ActividadId).HasColumnName("actividad_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.TiempoEstimado).HasColumnName("tiempo_estimado");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("DATE")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Rut).HasColumnName("rut");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<ComprobantesPago>(entity =>
        {
            entity.HasKey(e => e.ComprobantePagoId);

            entity.ToTable("ComprobantesPago");

            entity.Property(e => e.ComprobantePagoId).HasColumnName("comprobante_pago_id");
            entity.Property(e => e.FechaPago)
                .HasColumnType("DATE")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.MontoPagado).HasColumnName("monto_pagado");
            entity.Property(e => e.OrdenTrabajoId).HasColumnName("orden_trabajo_id");

            entity.HasOne(d => d.OrdenTrabajo).WithMany(p => p.ComprobantesPagos)
                .HasForeignKey(d => d.OrdenTrabajoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ComprobantesRecepcion>(entity =>
        {
            entity.HasKey(e => e.ComprobanteRecepcionId);

            entity.ToTable("ComprobantesRecepcion");

            entity.Property(e => e.ComprobanteRecepcionId).HasColumnName("comprobante_recepcion_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.EquipoId).HasColumnName("equipo_id");
            entity.Property(e => e.FechaRecepcion)
                .HasColumnType("DATE")
                .HasColumnName("fecha_recepcion");

            entity.HasOne(d => d.Equipo).WithMany(p => p.ComprobantesRecepcions)
                .HasForeignKey(d => d.EquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DetallesRepuestosInsumo>(entity =>
        {
            entity.HasKey(e => e.DetalleRepuestoId);

            entity.Property(e => e.DetalleRepuestoId).HasColumnName("detalle_repuesto_id");
            entity.Property(e => e.CantidadUtilizada).HasColumnName("cantidad_utilizada");
            entity.Property(e => e.DetalleId).HasColumnName("detalle_id");
            entity.Property(e => e.RepuestoId).HasColumnName("repuesto_id");

            entity.HasOne(d => d.Detalle).WithMany(p => p.DetallesRepuestosInsumos)
                .HasForeignKey(d => d.DetalleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Repuesto).WithMany(p => p.DetallesRepuestosInsumos)
                .HasForeignKey(d => d.RepuestoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DetallesServicio>(entity =>
        {
            entity.HasKey(e => e.DetalleId);

            entity.ToTable("DetallesServicio");

            entity.Property(e => e.DetalleId).HasColumnName("detalle_id");
            entity.Property(e => e.ActividadId).HasColumnName("actividad_id");
            entity.Property(e => e.EquipoId).HasColumnName("equipo_id");
            entity.Property(e => e.FechaFin)
                .HasColumnType("DATE")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("DATE")
                .HasColumnName("fecha_inicio");

            entity.HasOne(d => d.Actividad).WithMany(p => p.DetallesServicios)
                .HasForeignKey(d => d.ActividadId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Equipo).WithMany(p => p.DetallesServicios)
                .HasForeignKey(d => d.EquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.Property(e => e.EquipoId).HasColumnName("equipo_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("DATE")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("DATE")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.Marca).HasColumnName("marca");
            entity.Property(e => e.Modalidad).HasColumnName("modalidad");
            entity.Property(e => e.Modelo).HasColumnName("modelo");
            entity.Property(e => e.NumeroSerie).HasColumnName("numero_serie");
            entity.Property(e => e.TipoEquipo).HasColumnName("tipo_equipo");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Modalidade>(entity =>
        {
            entity.HasKey(e => e.ModalidadId);

            entity.Property(e => e.ModalidadId).HasColumnName("modalidad_id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<OrdenesCompra>(entity =>
        {
            entity.HasKey(e => e.OrdenCompraId);

            entity.ToTable("OrdenesCompra");

            entity.Property(e => e.OrdenCompraId).HasColumnName("orden_compra_id");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("DATE")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.TotalCompra).HasColumnName("total_compra");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.OrdenesCompras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrdenesTrabajo>(entity =>
        {
            entity.HasKey(e => e.OrdenTrabajoId);

            entity.ToTable("OrdenesTrabajo");

            entity.Property(e => e.OrdenTrabajoId).HasColumnName("orden_trabajo_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("DATE")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.TipoTrabajo).HasColumnName("tipo_trabajo");
            entity.Property(e => e.TotalTrabajo).HasColumnName("total_trabajo");

            entity.HasOne(d => d.Cliente).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PresupuestosTrabajo>(entity =>
        {
            entity.HasKey(e => e.PresupuestoId);

            entity.ToTable("PresupuestosTrabajo");

            entity.Property(e => e.PresupuestoId).HasColumnName("presupuesto_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("DATE")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.TotalPresupuesto).HasColumnName("total_presupuesto");

            entity.HasOne(d => d.Cliente).WithMany(p => p.PresupuestosTrabajos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.ProveedorId);

            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<RepuestosInsumo>(entity =>
        {
            entity.HasKey(e => e.RepuestoId);

            entity.Property(e => e.RepuestoId).HasColumnName("repuesto_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.RepuestosInsumos).HasForeignKey(d => d.ProveedorId);
        });

        modelBuilder.Entity<Trabajadore>(entity =>
        {
            entity.HasKey(e => e.TrabajadorId);

            entity.Property(e => e.TrabajadorId).HasColumnName("trabajador_id");
            entity.Property(e => e.Cargo).HasColumnName("cargo");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("DATE")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Rut).HasColumnName("rut");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
