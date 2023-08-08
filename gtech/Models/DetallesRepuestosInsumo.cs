using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class DetallesRepuestosInsumo
{
    public long DetalleRepuestoId { get; set; }

    public long DetalleId { get; set; }

    public long RepuestoId { get; set; }

    public long CantidadUtilizada { get; set; }

    public virtual DetallesServicio Detalle { get; set; } = null!;

    public virtual RepuestosInsumo Repuesto { get; set; } = null!;
}
