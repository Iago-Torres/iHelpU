﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace iHelpU.MODEL.Models;

public partial class Competencia
{
    public int Id { get; set; }

    public int? TipoServicoId { get; set; }

    public string NomeCompetencia { get; set; }

    public string Descricao { get; set; }

    public virtual TipoServico TipoServico { get; set; }

    public virtual ICollection<UsuarioCompetencium> UsuarioCompetencia { get; set; } = new List<UsuarioCompetencium>();
}