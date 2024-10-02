using System;
using System.Collections.Generic;

namespace iHelpU.MODEL.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? PrimeiroNome { get; set; }

    public string? SegundoNome { get; set; }

    public string? Email { get; set; }

    public string? Cpf { get; set; }

    public string? Telefone { get; set; }

    public virtual ICollection<AnuncioServico> AnuncioServicos { get; set; } = new List<AnuncioServico>();

    public virtual ICollection<ContratacaoServico> ContratacaoServicos { get; set; } = new List<ContratacaoServico>();

    public virtual ICollection<Competencia> Competencia { get; set; } = new List<Competencia>();
}
