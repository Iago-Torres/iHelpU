using iHelpU.MODEL.Interfaces;
using iHelpU.MODEL.Models;
using iHelpU.MODEL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Services
{
    public class CompetenciaService : ICompetenciaService
    {
        private readonly Banco_TCCContext _context;
        public RepositoryCompetencia oRepositoryCompetencia { get; set; }

        public CompetenciaService(Banco_TCCContext context)
        {
            oRepositoryCompetencia = new RepositoryCompetencia(context);
            _context = context;
        }

        public async Task<IEnumerable<Competencia>> GetAllAsync()
        {
            return await _context.Competencias.ToListAsync();
        }

        public async Task<Competencia> GetByIdAsync(int id)
        {
            return await _context.Competencias.FindAsync(id);
        }

        public async Task<Competencia> CreateAsync(Competencia competencia)
        {
            _context.Competencias.Add(competencia);
            await _context.SaveChangesAsync();
            return competencia;
        }

        public async Task UpdateAsync(Competencia competencia)
        {
            _context.Competencias.Update(competencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var competencia = await _context.Competencias.FindAsync(id);
            if (competencia != null)
            {
                _context.Competencias.Remove(competencia);
                await _context.SaveChangesAsync();
            }
        }
    }

}
