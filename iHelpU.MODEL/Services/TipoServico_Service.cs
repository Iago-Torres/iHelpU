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
    public class TipoServicoService : ITipoServico_Service
    {
        private readonly Banco_TCCContext _context;
        public RepositoryTipoServico oRepositoryTipoServico { get; set; }

        public TipoServicoService(Banco_TCCContext context)
        {
            oRepositoryTipoServico = new RepositoryTipoServico(context);
            _context = context;
        }

        public async Task<IEnumerable<TipoServico>> GetAllAsync()
        {
            return await _context.TipoServicos.ToListAsync();
        }

        public async Task<TipoServico> GetByIdAsync(int id)
        {
            return await _context.TipoServicos.FindAsync(id);
        }

        public async Task<TipoServico> CreateAsync(TipoServico tipoServico)
        {
            _context.TipoServicos.Add(tipoServico);
            await _context.SaveChangesAsync();
            return tipoServico;
        }

        public async Task UpdateAsync(TipoServico tipoServico)
        {
            _context.TipoServicos.Update(tipoServico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tipoServico = await _context.TipoServicos.FindAsync(id);
            if (tipoServico != null)
            {
                _context.TipoServicos.Remove(tipoServico);
                await _context.SaveChangesAsync();
            }
        }
    }

}
