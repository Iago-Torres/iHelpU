using iHelpU.MODEL.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace iHelpU.MODEL.ViewModel
{
    public class AnuncioEditVM
    {
        public AnuncioServico AnuncioServico { get; set; }
        public IEnumerable<SelectListItem> TipoServicoList { get; set; }
        public IEnumerable<SelectListItem> UsuarioList { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public int Id { get; set; }
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public string TipoServico { get; set; }
        public decimal coordenada_x { get; set; }
        public decimal coordenada_y { get; set; }
    }
}
