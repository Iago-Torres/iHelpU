using System;
using System.Collections.Generic;

namespace iHelpU.MODEL.Models;

public partial class AnuncioServico
{
    public int Id { get; set; }

    public int? TipoServicoId { get; set; }

    public int? UsuarioId { get; set; }

    public string? NomeServico { get; set; }

    public string? Descricao { get; set; }

    public decimal? CoordenadaX { get; set; }

    public decimal? CoordenadaY { get; set; }

    public virtual ICollection<ContratacaoServico> ContratacaoServicos { get; set; } = new List<ContratacaoServico>();

    public virtual TipoServico? TipoServico { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
