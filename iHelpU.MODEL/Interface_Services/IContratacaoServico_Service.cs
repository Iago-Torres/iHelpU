using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Interface_Services
{
    public interface IContratacaoServico_Service
    {
        Task<IEnumerable<ContratacaoServico>> GetAllAsync();
        Task<ContratacaoServico> GetByIdAsync(int id);
        Task<ContratacaoServico> CreateAsync(ContratacaoServico contratacaoServico);
        Task UpdateAsync(ContratacaoServico contratacaoServico);
        Task DeleteAsync(int id);
    }

}
