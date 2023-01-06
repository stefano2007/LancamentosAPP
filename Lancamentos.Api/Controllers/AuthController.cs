using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Essenciais;
using Lancamentos.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lancamentos.Api.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUsuarioService _service;

        public AuthController(IConfiguration config, IUsuarioService service)
        {
            _configuration = config;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioLogin _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Senha != null)
            {
                UsuarioLoginDTO user = await GetUsuarioLogin(_userData);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ConfiguracoesGerais.claimUsuarioId, user.UsuarioId.ToString()),
                        new Claim(ConfiguracoesGerais.claimNome, user.Nome),
                        new Claim(ConfiguracoesGerais.claimEmail, user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    double tempoExpiracaoMinutos = 120;

                    var dateExpires = DateTime.UtcNow.AddMinutes(tempoExpiracaoMinutos);

                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: dateExpires,
                        signingCredentials: signIn);

                    user.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    user.Expires = dateExpires;

                    return Ok(user);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        private async Task<UsuarioLoginDTO> GetUsuarioLogin(UsuarioLogin _user)
        {
            return await _service.GetUsuarioLogin(_user);
        }
    }
}
