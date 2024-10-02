using System;
using System.Collections.Generic;

namespace iHelpU.MODEL.Models;

public partial class TipoServico
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<AnuncioServico> AnuncioServicos { get; set; } = new List<AnuncioServico>();

    public virtual ICollection<Competencia> Competencia { get; set; } = new List<Competencia>();
}
