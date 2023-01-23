using Contas.Api.Services;
using Hangfire;
using Lancamentos.Api.Configuracoes;
using Lancamentos.Api.Data;
using Lancamentos.Api.Data.Repositorio;
using Lancamentos.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//adicionar Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();

//Adicionar auntenticação JWT fonte: https://www.c-sharpcorner.com/article/how-to-implement-jwt-authentication-in-web-api-using-net-6-0-asp-net-core/
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITipoLancamentoRepository, TipoLancamentoRepository>();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<ITipoContaRepository, TipoContaRepository>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();

//services
builder.Services.AddTransient<ITipoLancamentoService, TipoLancamentoService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<ILancamentoService, LancamentoService>();
builder.Services.AddTransient<ITipoContaService, TipoContaService>();
builder.Services.AddTransient<IContaService, ContaService>();

builder.Services.AddDbContext<LancamentoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
    if (builder.Environment.IsDevelopment())
    {   //mostar querys no debug
        options.LogTo((s) => Debug.Write(s), LogLevel.Information);
    }
});

builder.Services.RegisterSwagger();
builder.Services.RegisterHangfire(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHangfireDashboard();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(options => options.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

app.MapControllers();
/*
BackgroundJob.Schedule(
    () => Console.WriteLine("Job Delayed: 5 segundos após o início da aplicação"),
    TimeSpan.FromSeconds(5));   
*/
app.Run();