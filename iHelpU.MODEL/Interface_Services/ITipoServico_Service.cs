using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Services
{
    public interface ITipoServico_Service
    {
        Task<IEnumerable<TipoServico>> GetAllAsync();
        Task<TipoServico> GetByIdAsync(int id);
        Task<TipoServico> CreateAsync(TipoServico tipoServico);
        Task UpdateAsync(TipoServico tipoServico);
        Task DeleteAsync(int id);
    }
}
