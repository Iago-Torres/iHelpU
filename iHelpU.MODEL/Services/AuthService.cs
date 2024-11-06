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
        private readonly BancoTccContext _db;

        public AuthService(IHttpContextAccessor httpContextAccessor, BancoTccContext db)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public bool AutenticarUsuario(string email, string senha)
        {
            var usuario = _db.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                SetSessionExpiration(30); // Define a expiração da sessão em 30 minutos
                return true;
            }

            return false;
        }

        public async Task<bool> AutenticarUsuarioAsync(string email, string senha)
        {
            var usuario = await _db.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                SetSessionExpiration(30); // Define a expiração da sessão em 30 minutos
                return true;
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            // Limpa a sessão
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public int? UsuarioLogado()
        {
            // Verifica se a sessão expirou antes de retornar o ID do usuário logado
            if (SessionExpired())
            {
                LogoutAsync().Wait();
                return null;
            }

            return _httpContextAccessor.HttpContext.Session.GetInt32("UsuarioId");
        }

        public async Task<int?> UsuarioLogadoAsync()
        {
            if (SessionExpired())
            {
                await LogoutAsync();
                return null;
            }

            return _httpContextAccessor.HttpContext.Session.GetInt32("UsuarioId");
        }

        private void SetSessionExpiration(int minutos)
        {
            _httpContextAccessor.HttpContext.Session.SetString("SessionStart", DateTime.Now.ToString());
            _httpContextAccessor.HttpContext.Session.SetInt32("SessionDuration", minutos);
        }

        private bool SessionExpired()
        {
            var sessionStart = _httpContextAccessor.HttpContext.Session.GetString("SessionStart");
            var sessionDuration = _httpContextAccessor.HttpContext.Session.GetInt32("SessionDuration");

            if (sessionStart != null && sessionDuration.HasValue)
            {
                var inicio = DateTime.Parse(sessionStart);
                return DateTime.Now > inicio.AddMinutes(sessionDuration.Value);
            }

            return true; // Considera expirado se não encontrar a sessão
        }
    }
}
