using System;
using System.Collections.Generic;

namespace GMAOAPI.Models;

public partial class PartesCorrectivo
{
    public int Idparte { get; set; }

    public virtual Parte IdparteNavigation { get; set; } = null!;
}
