using iHelpU.MODEL.Interface_Services;
using iHelpU.MODEL.Models;
using Microsoft.EntityFrameworkCore;
using iHelpU.MODEL.Services;
using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BancoTccContext>(opt => opt.UseSqlServer("Server=.\\SQLExpress;Database=Banco_TCC;Trusted_Connection=True;trustservercertificate=true"));
builder.Services.AddScoped<IUsuario_Service, UsuarioService>();
builder.Services.AddScoped<IRepositoryBase<AnuncioServico>, RepositoryAnuncioServico>();
builder.Services.AddScoped<IAnuncioServico_Service, AnuncioServico_Service>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpContextAccessor();




builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});



var app = builder.Build();

app.UseSession(); 
app.UseRouting();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
