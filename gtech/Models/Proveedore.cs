using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class Proveedore
{
    public long ProveedorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();

    public virtual ICollection<RepuestosInsumo> RepuestosInsumos { get; set; } = new List<RepuestosInsumo>();
}
