using System;
using System.Collections.Generic;

namespace GMAOAPI.Models;

public partial class AlmacenesRepuesto
{
    public int Id { get; set; }

    public int Idalmacen { get; set; }

    public int Idrepuestos { get; set; }

    public virtual Almacene IdalmacenNavigation { get; set; } = null!;

    public virtual Repuesto IdrepuestosNavigation { get; set; } = null!;
}
