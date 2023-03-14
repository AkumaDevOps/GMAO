using System;
using System.Collections.Generic;

namespace GMAOAPI.Models;

public partial class PartesExterno
{
    public int Idpartes { get; set; }

    public virtual Parte IdpartesNavigation { get; set; } = null!;
}
