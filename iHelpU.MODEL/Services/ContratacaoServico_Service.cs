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
    public class ContratacaoServicoService : IContratacaoServico_Service
    {
        private readonly BancoTccContext _context;
        public RepositoryContratacaoServico oRepositoryContratacaoServico { get; set; }

        public ContratacaoServicoService(BancoTccContext context)
        {
            oRepositoryContratacaoServico = new RepositoryContratacaoServico(context);
            _context = context;
        }

        public async Task<IEnumerable<ContratacaoServico>> GetAllAsync()
        {
            return await _context.ContratacaoServicos.ToListAsync();
        }
        public async Task<ContratacaoServico> GetByIdAsync(int id)
        {
            return await _context.ContratacaoServicos.FindAsync(id);
        }

        public async Task<ContratacaoServico> CreateAsync(ContratacaoServico contratacaoServico)
        {
            _context.ContratacaoServicos.Add(contratacaoServico);
            await _context.SaveChangesAsync();
            return contratacaoServico;
        }
        public async Task UpdateAsync(ContratacaoServico contratacaoServico)
        {
            _context.ContratacaoServicos.Update(contratacaoServico);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var contratacaoServico = await _context.ContratacaoServicos.FindAsync(id);
            if (contratacaoServico != null)
            {
                _context.ContratacaoServicos.Remove(contratacaoServico);
                await _context.SaveChangesAsync();
            }
        }
    }

}
