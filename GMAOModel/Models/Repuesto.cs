using System;
using System.Collections.Generic;

namespace GMAOModel.Models;

public partial class Repuesto
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int CantidadMinimaStock { get; set; }

    public int CantidadMaximaStock { get; set; }

    public virtual ICollection<AlmacenesRepuesto> AlmacenesRepuestos { get; } = new List<AlmacenesRepuesto>();
}
