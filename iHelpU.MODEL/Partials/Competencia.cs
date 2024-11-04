using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iHelpU.MODEL.Partials
{
    [ModelMetadataType(typeof(MD_Competencia))]
    public class MD_Competencia
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID do Tipo de Serviço")]
        public int? TipoServicoId { get; set; }
        [Display(Name = "Nome da Competência")]
        public string? NomeCompetencia { get; set; }
        [Display(Name = "Descrição da Competência")]
        public string? Descricao { get; set; }
    }
}


