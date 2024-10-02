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
    [ModelMetadataType(typeof(MD_Avaliacao))]
    public class MD_Avaliacao
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Nota")]
        public double? Nota { get; set; }
        [Display(Name = "Descrição de Serviço")]
        public string? DescricaoServico { get; set; }
    }
}