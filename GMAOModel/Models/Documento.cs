using System;
using System.Collections.Generic;

namespace GMAOModel.Models;

public partial class Documento
{
    public int Id { get; set; }

    public int Idpartes { get; set; }

    public string RutaDocumento { get; set; } = null!;

    public virtual Parte IdpartesNavigation { get; set; } = null!;
}
