using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lancamentos.Api.Essenciais
{
    public static class TokenEssencial
    {
        //https://www.c-sharpcorner.com/article/jwt-authentication-with-refresh-tokens-in-net-6-0/
        //private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        //{
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateAudience = false,
        //        ValidateIssuer = false,
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
        //        ValidateLifetime = false
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        //    if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        //        throw new SecurityTokenException("Invalid token");

        //    return principal;
        //}
        /// <summary>
        /// Recuperar informações de claims do token enviado pelo client
        /// </summary>
        /// <param name="User">Objeto ClaimsPrincipal da requisição</param>
        /// <returns>Retorna objeto deserializado</returns>
        public static UsuarioToken? ConvertToken(this ClaimsPrincipal User)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }

            int usuarioId = Convert.ToInt32(User.FindFirst(ConfiguracoesGerais.claimUsuarioId)?.Value ?? "0");
            var nome = User.FindFirst(ConfiguracoesGerais.claimNome)?.Value ?? "";
            var email = User.FindFirst(ConfiguracoesGerais.claimEmail)?.Value ?? "";

            return new UsuarioToken
            {
                UsuarioId = usuarioId,
                Nome = nome,
                Email = email
            };
        }
    }
}
