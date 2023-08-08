using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class ComprobantesPago
{
    public long ComprobantePagoId { get; set; }

    public long OrdenTrabajoId { get; set; }

    public byte[] FechaPago { get; set; } = null!;

    public double MontoPagado { get; set; }

    public virtual OrdenesTrabajo OrdenTrabajo { get; set; } = null!;
}
