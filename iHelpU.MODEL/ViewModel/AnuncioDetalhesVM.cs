using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace iHelpU.MODEL.ViewModel
{
    public class AnuncioDetalhesVM
    {
        public int Id { get; set; }
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public string TipoServico { get; set; }
        public string Status { get; set; }
        public string coordenada_x { get; set; }    // Coordenada X
        public string coordenada_y { get; set; }   // Coordenada Y
    }
}
