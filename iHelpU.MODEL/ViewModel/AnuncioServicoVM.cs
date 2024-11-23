using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace iHelpU.MODEL.ViewModel
{
    public class AnuncioServicoVM
    {
        public AnuncioServico AnuncioServico { get; set; }
        public IEnumerable<SelectListItem> TipoServicoList { get; set; }
        public List<SelectListItem> UsuarioList { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }


    }
}
