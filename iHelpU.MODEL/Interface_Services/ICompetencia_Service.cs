using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Services
{
    public interface ICompetenciaService
    {
        Task<IEnumerable<Competencia>> GetAllAsync();
        Task<Competencia> GetByIdAsync(int id);
        Task<Competencia> CreateAsync(Competencia competencia);
        Task UpdateAsync(Competencia competencia);
        Task DeleteAsync(int id);
    }
}
