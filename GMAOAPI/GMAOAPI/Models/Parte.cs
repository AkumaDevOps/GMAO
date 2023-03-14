using System;
using System.Collections.Generic;

namespace GMAOAPI.Models;

public partial class Parte
{
    public int Id { get; set; }

    public byte EstadoIncidencia { get; set; }

    public byte EstadoAprobacion { get; set; }

    public int Responsable { get; set; }

    public virtual ICollection<Documento> Documentos { get; } = new List<Documento>();

    public virtual PartesCorrectivo? PartesCorrectivo { get; set; }

    public virtual PartesExterno? PartesExterno { get; set; }

    public virtual PartesInterno? PartesInterno { get; set; }
}
