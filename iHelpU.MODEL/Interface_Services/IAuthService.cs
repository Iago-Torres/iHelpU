using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Interface_Services
{
    public interface IAuthService
    {
        Task<int?> UsuarioLogadoAsync();
        int? UsuarioLogado();
        Task<bool> AutenticarUsuarioAsync(string email, string senha);
        bool AutenticarUsuario(string email, string senha);
        Task LogoutAsync();
    }
}
