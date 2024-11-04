using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Repositories
{
    public class RepositoryCompetencia : RepositoryBase<Competencia>
    {
        public RepositoryCompetencia(BancoTccContext context, bool saveChanges = true) : base(context, saveChanges)
        {
        }
    }
}
