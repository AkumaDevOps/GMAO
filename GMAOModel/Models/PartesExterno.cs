using System;
using System.Collections.Generic;

namespace GMAOModel.Models;

public partial class PartesExterno
{
    public int Idpartes { get; set; }

    public virtual Parte IdpartesNavigation { get; set; } = null!;
}
