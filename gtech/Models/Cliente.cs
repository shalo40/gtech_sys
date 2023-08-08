using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gtech.Models;

public partial class Cliente
{
    public long ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Rut { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaIngreso { get; set; }

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

    public virtual ICollection<OrdenesTrabajo> OrdenesTrabajos { get; set; } = new List<OrdenesTrabajo>();

    public virtual ICollection<PresupuestosTrabajo> PresupuestosTrabajos { get; set; } = new List<PresupuestosTrabajo>();
}
