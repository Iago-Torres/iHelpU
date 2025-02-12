using iHelpU.MODEL.Interface_Services;
using iHelpU.MODEL.Models;
using Microsoft.EntityFrameworkCore;
using iHelpU.MODEL.Services;
using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os ao cont�iner
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Banco_TCCContext>(opt => opt.UseSqlServer("Server=.\\SQLExpress;Database=Banco_TCC;Trusted_Connection=True;trustservercertificate=true"));

// Configura��o da autentica��o com cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.Cookie.HttpOnly = true;
    });

//public void Mapas(IServiceCollection services)
//{
//    var googleMapsApiKey = Configuration["GoogleMaps:ApiKey"];
//    services.AddSingleton(googleMapsApiKey);
//}
// Registro de depend�ncias para inje��o de depend�ncia
builder.Services.AddScoped<ITipoServico_Service, TipoServicoService>();
builder.Services.AddScoped<IUsuario_Service, UsuarioService>();
builder.Services.AddScoped<IRepositoryBase<AnuncioServico>, RepositoryAnuncioServico>();
builder.Services.AddScoped<IAnuncioServico_Service, AnuncioServico_Service>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AnuncioServico_Service>();
builder.Services.AddHttpClient<IGoogleMaps_Service, GoogleMaps_Service>();
builder.Services.AddSingleton<IGoogleMaps_Service, GoogleMaps_Service>();

builder.Services.AddHttpContextAccessor();

// Autentica��o
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Middleware de autentica��o e autoriza��o
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// Configura��o do pipeline de requisi��es HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Mapeamento da rota padr�o
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
