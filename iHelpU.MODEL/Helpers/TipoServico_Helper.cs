using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Helpers
{
    public static class TipoServicoHelper
    {
        public static List<TipoServico> ObterTiposServico(Banco_TCCContext context)
        {
            // Obtém a lista de tipos de serviço diretamente do contexto
            return context.TipoServicos.ToList();
        }
    }
}
