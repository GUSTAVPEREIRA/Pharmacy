using Microsoft.IdentityModel.Tokens;
using Pharmacy.Cryptographic;
using Pharmacy.DTO.Users;
using Pharmacy.Extensions.Exceptions;
using Pharmacy.Services.IServices.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Pharmacy.Services.Services.Tokens
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(NewUserDTO user)
        {

            if (user == null)
            {
                throw new APIException("Usuário não pode ser nulo!", HttpStatusCode.BadRequest);
            }

            var tokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SettingsSecret.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandle.CreateToken(tokenDescriptor);
            return tokenHandle.WriteToken(token);
        }
    }
}