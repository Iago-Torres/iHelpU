using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using iHelpU.MODEL.Repositories;

namespace Projeto_iHelpU.Controllers
{
    public class UsuarioController : Controller
    {
       
        private BancoTccContext _context;
        public RepositoryUsuario _RepositoryUsuario;

        public UsuarioController(BancoTccContext context)
        {
            _context = context;
            _RepositoryUsuario = new RepositoryUsuario(context);
        }

        public async Task<IActionResult> Index()
        {
            var db = new BancoTccContext();
            var listaUsuario = await db.Usuarios.ToListAsync();
            return View(listaUsuario);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(usuario);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var db = new BancoTccContext();
            var usuario = await db.TipoServicos.FindAsync(id);
            return View(usuario);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(usuario);
        }
        public async Task<IActionResult> Details(int id)
        {
            var db = new BancoTccContext();
            var tipoServico = await db.TipoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(tipoServico);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new BancoTccContext();
            var usuario = await db.TipoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Usuario usuario)
        {
            var db = new BancoTccContext();
            db.Entry(usuario).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
