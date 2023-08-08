using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class OrdenesCompra
{
    public long OrdenCompraId { get; set; }

    public long ProveedorId { get; set; }

    public byte[] FechaEmision { get; set; } = null!;

    public double TotalCompra { get; set; }

    public virtual Proveedore Proveedor { get; set; } = null!;
}
