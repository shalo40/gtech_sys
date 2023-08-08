using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class ComprobantesRecepcion
{
    public long ComprobanteRecepcionId { get; set; }

    public long EquipoId { get; set; }

    public byte[] FechaRecepcion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual Equipo Equipo { get; set; } = null!;
}
