using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gtech.Models;

public partial class PresupuestosTrabajo
{
    public long PresupuestoId { get; set; }

    public long ClienteId { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaEmision { get; set; }

    public string Descripcion { get; set; } = null!;

    public double TotalPresupuesto { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
