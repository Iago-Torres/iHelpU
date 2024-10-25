using System;
using System.Collections.Generic;

namespace iHelpU.MODEL.Models;

public partial class UsuarioCompetencium
{
    public int UsuarioId { get; set; }

    public int CompetenciaId { get; set; }

    public virtual Usuario Usuario { get; set; }
    public virtual Competencia Competencia { get; set; }
}
