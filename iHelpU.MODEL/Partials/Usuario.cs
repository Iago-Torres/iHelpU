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
    [ModelMetadataType(typeof (MD_Usuario))]
    public class MD_Usuario
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string? PrimeiroNome { get; set; }
        [Display(Name = "Sobrenome")]
        public string? SegundoNome { get; set; }
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
        [Display(Name = "CPF")]
        public string? Cpf { get; set; }
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }
    }
}
