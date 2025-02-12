using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Repositories
{
    public class RepositoryTipoServico : RepositoryBase<TipoServico>
    {
        public RepositoryTipoServico(Banco_TCCContext context, bool saveChanges = true) : base(context, saveChanges)
        {
        }

        public IEnumerable<TipoServico> ObterTodosTiposServico() //Obtém os Tipos de Serviços do Banco de Dados
        {
            return _context.TipoServicos.ToList(); 
        }
    }
}