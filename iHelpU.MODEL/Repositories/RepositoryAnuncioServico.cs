using iHelpU.MODEL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace iHelpU.MODEL.Repositories
{
    public class RepositoryAnuncioServico : RepositoryBase<AnuncioServico>
    {
        public RepositoryAnuncioServico(BancoTccContext context, bool saveChanges = true) : base(context, saveChanges)
        {
        }

        // Obter todos os anúncios criados
        public async Task<List<AnuncioServico>> ObterServicosCriados(int userId)
        {
            return await _context.AnuncioServicos
                .Where(a => a.UsuarioId == userId)
                .ToListAsync();
        }

        // Obter todos os serviços prestados
        public async Task<List<AnuncioServico>> ObterServicosPrestados(int userId)
        {
            return await _context.ContratacaoServicos
                .Include(c => c.AnuncioServico)
                .Where(c => c.AnuncioServico.UsuarioId == userId)
                .Select(c => c.AnuncioServico)
                .ToListAsync();
        }
    }
}
