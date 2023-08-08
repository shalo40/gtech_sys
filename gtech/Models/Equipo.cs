using System;
using System.Collections.Generic;

namespace gtech.Models;

public partial class Equipo
{
    public long EquipoId { get; set; }

    public long ClienteId { get; set; }

    public string TipoEquipo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string NumeroSerie { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public byte[] FechaIngreso { get; set; } = null!;

    public byte[]? FechaSalida { get; set; }

    public string Modalidad { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<ComprobantesRecepcion> ComprobantesRecepcions { get; set; } = new List<ComprobantesRecepcion>();

    public virtual ICollection<DetallesServicio> DetallesServicios { get; set; } = new List<DetallesServicio>();
}
