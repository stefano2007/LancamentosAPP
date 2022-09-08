using Lancamentos.Api.Data;
using Lancamentos.Api.Data.Repositorio;
using Lancamentos.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

//adicionar Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITipoLancamentoRepository, TipoLancamentoRepository>();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();

//services
builder.Services.AddTransient<ITipoLancamentoService, TipoLancamentoService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<ILancamentoService, LancamentoService>();

builder.Services.AddDbContext<LancamentoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
    if (builder.Environment.IsDevelopment())
    {
        options.LogTo((s) => Debug.Write(s), LogLevel.Information);
    }
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
