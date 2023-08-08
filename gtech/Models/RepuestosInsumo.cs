using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class RepuestosInsumo
{
    public long RepuestoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public long Cantidad { get; set; }

    public long? ProveedorId { get; set; }

    public virtual ICollection<DetallesRepuestosInsumo> DetallesRepuestosInsumos { get; set; } = new List<DetallesRepuestosInsumo>();

    public virtual Proveedore? Proveedor { get; set; }
}
