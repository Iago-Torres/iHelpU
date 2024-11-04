using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iHelpU.MODEL.Repositories;

namespace iHelpU.MODEL.Interface_Services
{
    public interface IUsuario_Service
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> CreateAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        public Task<Usuario> ObterUsuarioporCredencial(string email, string senha);

    }

}
