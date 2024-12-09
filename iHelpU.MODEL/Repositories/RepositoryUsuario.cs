using iHelpU.MODEL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario>
    {
        private readonly BancoTccContext _context;

        public RepositoryUsuario(BancoTccContext context, bool saveChanges = true) : base(context, saveChanges)
        {
            _context = context;
        }

        public async Task<Usuario> ObterUsuarioPorId(int usuarioId)
        {
            return await _context.Usuarios
                                 .FirstOrDefaultAsync(u => u.Id == usuarioId);
        }

        public async Task<Usuario> ObterUsuarioporCredencial(string email, string cpf) //Verificação na AuthController
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Cpf == cpf); 
        }
        public Usuario UsuarioLogado(int usuarioId) //Pega ID do Usuário também 
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
        }
    }
}
