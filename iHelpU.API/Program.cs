using iHelpU.MODEL.Models;
using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'Identity_ContextConnection' not found.");
builder.Services.AddDbContext<BancoTccContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ajuste a string de conexão conforme necessário

// Registrar os serviços no contêiner de dependência

// CompetenciaService e RepositoryCompetencia
builder.Services.AddScoped<CompetenciaService>();
builder.Services.AddScoped<RepositoryCompetencia>();

// UsuarioService e RepositoryUsuario
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<RepositoryUsuario>();

// AnuncioServicoService e RepositoryAnuncioServico
builder.Services.AddScoped<AnuncioServico_Service>();
builder.Services.AddScoped<RepositoryAnuncioServico>();

// ContratacaoServicoService e RepositoryContratacaoServico
builder.Services.AddScoped<ContratacaoServicoService>();
builder.Services.AddScoped<RepositoryContratacaoServico>();

// AvaliacaoService e RepositoryAvaliacao
builder.Services.AddScoped<Avaliacao_Service>();
builder.Services.AddScoped<RepositoryAvaliacao>();

// Adicionar os serviços padrão do ASP.NET Core (controladores, etc.)
builder.Services.AddControllers();

// Outras configurações padrão (CORS, autenticação, etc.)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Constrói e executa o aplicativo
var app = builder.Build();

// Outras configurações (configuração de middleware, etc.)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
// Add services to the container.
builder.Services.AddDbContext<BancoTccContext>(opt => opt.UseSqlServer(connectionString));
//builder.Services.AddDbContext<Identity_Context>(opt => opt.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
