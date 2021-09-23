using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Functions;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace Data.Services
{
    //TODO: consertar autenticacao: sempre da Unauthorized
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Configuration.GetAuthentication();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (ClaimTypes.Name, user.Username),
                    new (ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(3), // USAR UTC PADRAO
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}