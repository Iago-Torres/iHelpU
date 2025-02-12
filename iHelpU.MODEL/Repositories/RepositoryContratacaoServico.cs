using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Repositories
{
    public class RepositoryContratacaoServico : RepositoryBase<ContratacaoServico>
    {
        public RepositoryContratacaoServico(Banco_TCCContext context, bool saveChanges = true) : base(context, saveChanges) 
        {
        }
    }
}
