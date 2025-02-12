using iHelpU.MODEL.Interface_Services;
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
    public class UsuarioService : IUsuario_Service
    {
        private readonly Banco_TCCContext _context;
        public RepositoryUsuario oRepositoryUsuario { get; set; }

        public UsuarioService(Banco_TCCContext context)
        {
            oRepositoryUsuario = new RepositoryUsuario(context);
           _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Usuario> ObterUsuarioporCredencial(string email, string senha)
        {
            return await _context.Usuarios
                                 .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }
    }

}
