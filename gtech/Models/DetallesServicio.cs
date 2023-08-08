using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class DetallesServicio
{
    public long DetalleId { get; set; }

    public long EquipoId { get; set; }

    public long ActividadId { get; set; }

    public byte[] FechaInicio { get; set; } = null!;

    public byte[]? FechaFin { get; set; }

    public virtual Actividade Actividad { get; set; } = null!;

    public virtual ICollection<DetallesRepuestosInsumo> DetallesRepuestosInsumos { get; set; } = new List<DetallesRepuestosInsumo>();

    public virtual Equipo Equipo { get; set; } = null!;
}
