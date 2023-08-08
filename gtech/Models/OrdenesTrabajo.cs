using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class OrdenesTrabajo
{
    public long OrdenTrabajoId { get; set; }

    public long ClienteId { get; set; }

    public byte[] FechaEmision { get; set; } = null!;

    public string TipoTrabajo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public double TotalTrabajo { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<ComprobantesPago> ComprobantesPagos { get; set; } = new List<ComprobantesPago>();
}
