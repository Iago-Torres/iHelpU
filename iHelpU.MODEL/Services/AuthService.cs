using iHelpU.MODEL.Interface_Services;
using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool AutenticarUsuario(string email, string senha)
        {
            using (var db = new BancoTccContext())
            {
                var usuario = db.Usuarios
                    .FirstOrDefault(u => u.Email == email && u.Senha == senha);

                if (usuario != null)
                {
                    _httpContextAccessor.HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                    return true;
                }

                return false;
            }
        }

        public async Task<bool> AutenticarUsuarioAsync(string email, string senha)
        {
            using (var db = new BancoTccContext())
            {
                var usuario = await db.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

                if (usuario != null)
                {
                    // Salva o ID do usuário na sessão
                    _httpContextAccessor.HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

                    // Define o tempo de expiração da sessão em minutos
                    int tempoExpiracaoEmMinutos = 30; // Defina a duração desejada
                    _httpContextAccessor.HttpContext.Session.SetString("SessionStart", DateTime.Now.ToString());
                    _httpContextAccessor.HttpContext.Session.SetInt32("SessionDuration", tempoExpiracaoEmMinutos);

                    return true;
                }

                return false;
            }
        }

        public async Task LogoutAsync()
        {
            // Limpa a sessão
            _httpContextAccessor.HttpContext.Session.Remove("UsuarioId");
            _httpContextAccessor.HttpContext.Session.Remove("SessionStart");
            _httpContextAccessor.HttpContext.Session.Remove("SessionDuration");
        }

        public int? UsuarioLogado()
        {
            // Retorna o ID do usuário logado diretamente
            return _httpContextAccessor.HttpContext.Session.GetInt32("UsuarioId");
        }

        public async Task<int?> UsuarioLogadoAsync()
        {
            int? userId = _httpContextAccessor.HttpContext.Session.GetInt32("UsuarioId");
            return await Task.FromResult(userId);
        }
    }
}
