using System;
using System.Collections.Generic;

namespace iHelpU.MODEL.Models;

public partial class Avaliacao
{
    public int Id { get; set; }

    public int? ContratacaoServicoId { get; set; }

    public double? Nota { get; set; }

    public string? DescricaoServico { get; set; }

    public virtual ContratacaoServico? ContratacaoServico { get; set; }
}
