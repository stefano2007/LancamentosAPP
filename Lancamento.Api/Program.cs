using Lancamento.Api.Data;
using Lancamento.Api.Data.Entidades.Profiles;
using Lancamento.Api.Data.Repositorio;
using Lancamento.Api.Services;
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

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITipoLancamentoRepository, TipoLancamentoRepository>();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();

//services
builder.Services.AddTransient<TipoLancamentoService>();

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
