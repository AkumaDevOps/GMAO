using System;
using System.Collections.Generic;

namespace GMAOModel.Models;

public partial class Almacene
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<AlmacenesRepuesto> AlmacenesRepuestos { get; } = new List<AlmacenesRepuesto>();
}
