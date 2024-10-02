using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Interface_Services
{
    public interface IAvaliacao_Service
    {
        Task<IEnumerable<Avaliacao>> GetAllAsync();
        Task<Avaliacao> GetByIdAsync(int id);
        Task<Avaliacao> CreateAsync(Avaliacao avaliacao);
        Task UpdateAsync(Avaliacao avaliacao);
        Task DeleteAsync(int id);
    }

}
