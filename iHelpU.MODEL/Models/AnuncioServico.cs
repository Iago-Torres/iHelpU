﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace iHelpU.MODEL.Models;

public partial class AnuncioServico
{
    public int Id { get; set; }

    public int? TipoServicoId { get; set; }

    public int? UsuarioId { get; set; }

    public string NomeServico { get; set; }

    public string Descricao { get; set; }

    public string CoordenadaX { get; set; }

    public string CoordenadaY { get; set; }

    public int? IdStatus { get; set; }

    public string Rua { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Cep { get; set; }

    public string Pais { get; set; }

    public string NomeLocal { get; set; }

    public virtual ICollection<ContratacaoServico> ContratacaoServicos { get; set; } = new List<ContratacaoServico>();

    public virtual Status IdStatusNavigation { get; set; }

    public virtual TipoServico TipoServico { get; set; }

    public virtual Usuario Usuario { get; set; }
}