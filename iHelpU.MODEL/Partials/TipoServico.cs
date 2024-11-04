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
    [ModelMetadataType(typeof(MD_TipoServico))]
    public class MD_TipoServico
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Descrição do Tipo de Serviço")]
        public string? Descricao { get; set; }

    }
}
