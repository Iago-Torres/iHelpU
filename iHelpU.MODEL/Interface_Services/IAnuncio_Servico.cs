using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Interface_Services
{
    public interface IAnuncioServico_Service
    {
        Task<IEnumerable<AnuncioServico>> GetAllAsync();
        Task<AnuncioServico> GetByIdAsync(int id);
        Task<AnuncioServico> CreateAsync(AnuncioServico anuncioServico);
        Task UpdateAsync(AnuncioServico anuncioServico);
        Task DeleteAsync(int id);
    }

}
