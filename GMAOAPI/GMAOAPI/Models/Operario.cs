using System;
using System.Collections.Generic;

namespace GMAOAPI.Models;

public partial class Operario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte TipoOperario { get; set; }

    public string Email { get; set; } = null!;

    public string? Extension { get; set; }
}
