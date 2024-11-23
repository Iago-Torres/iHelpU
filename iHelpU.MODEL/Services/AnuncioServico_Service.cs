using iHelpU.MODEL.Interface_Services;
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
    public class AnuncioServico_Service : IAnuncioServico_Service
    {
        private readonly BancoTccContext _context;
        public RepositoryAnuncioServico oRepositoryAnuncioServico { get; set; }

        public AnuncioServico_Service(BancoTccContext context)
        {
            _context = context;
            oRepositoryAnuncioServico = new RepositoryAnuncioServico(context);
        }

        public async Task<IEnumerable<AnuncioServico>> GetAllAsync()
        {
            return await _context.AnuncioServicos.ToListAsync();
        }

        public async Task<AnuncioServico> GetByIdAsync(int id)
        {
            return await _context.AnuncioServicos.FindAsync(id);
        }

        public async Task<AnuncioServico> CreateAsync(AnuncioServico anuncioServico)
        {
            _context.AnuncioServicos.Add(anuncioServico);
            await _context.SaveChangesAsync();
            return anuncioServico;
        }

        public async Task UpdateAsync(AnuncioServico anuncioServico)
        {
            _context.AnuncioServicos.Update(anuncioServico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var anuncioServico = await _context.AnuncioServicos.FindAsync(id);
            if (anuncioServico != null)
            {
                _context.AnuncioServicos.Remove(anuncioServico);
                await _context.SaveChangesAsync();
            }
        }
    }
}
