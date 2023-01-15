using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EhrlichWebAPI.Contracts;
using EhrlichWebAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace EhrlichWebAPI.Services
{
    public class TokenService: ITokenService
    {
        private readonly TokenValidationParameters _validationParameters;
        private readonly string _secret;
        public TokenService(TokenValidationParameters validationParameters, string secret)
        {
            _validationParameters = validationParameters;
            _secret = secret;
        }

        public string GenererateToken(User user)
        {
            var userClaims = new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    claims: userClaims,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddDays(1)
                );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
     
        public bool IsValid(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, _validationParameters, out SecurityToken securityToken);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
