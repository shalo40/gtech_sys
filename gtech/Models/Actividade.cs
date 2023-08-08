using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class Actividade
{
    public long ActividadId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public long TiempoEstimado { get; set; }

    public virtual ICollection<DetallesServicio> DetallesServicios { get; set; } = new List<DetallesServicio>();
}
