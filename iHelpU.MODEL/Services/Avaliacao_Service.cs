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
    public class Avaliacao_Service : IAvaliacao_Service
    {
        private readonly BancoTccContext _context;
        public RepositoryAvaliacao oRepositoryAvaliacao { get; set; }


        public Avaliacao_Service(BancoTccContext context)
        {
            oRepositoryAvaliacao = new RepositoryAvaliacao(context);
            _context = context;
        }

        public async Task<IEnumerable<Avaliacao>> GetAllAsync()
        {
            return await _context.Avaliacaos.ToListAsync();
        }

        public async Task<Avaliacao> GetByIdAsync(int id)
        {
            return await _context.Avaliacaos.FindAsync(id);
        }

        public async Task<Avaliacao> CreateAsync(Avaliacao avaliacao)
        {
            _context.Avaliacaos.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        public async Task UpdateAsync(Avaliacao avaliacao)
        {
            _context.Avaliacaos.Update(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var avaliacao = await _context.Avaliacaos.FindAsync(id);
            if (avaliacao != null)
            {
                _context.Avaliacaos.Remove(avaliacao);
                await _context.SaveChangesAsync();
            }
        }
    }

}
