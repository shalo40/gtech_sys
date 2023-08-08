using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gtech.Models;

public partial class Trabajadore
{
    public long TrabajadorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Rut { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaIngreso { get; set; }
}
