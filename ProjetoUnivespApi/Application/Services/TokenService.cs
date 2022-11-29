using Microsoft.IdentityModel.Tokens;
using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoUnivespApi.Application.Services
{
    public class TokenService : ITokenService
    {
        IConfiguration _configuration = null;

        public TokenService(IConfiguration config)
        {
            _configuration = config ??
                throw new ArgumentNullException(nameof(config));
        }

        public async Task<string> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretKey"]));

            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsInfo = new List<Claim>();
            claimsInfo.Add(new Claim(ClaimTypes.GivenName, user.Usuario));
            claimsInfo.Add(new Claim(ClaimTypes.Email, user.Email));
            claimsInfo.Add(new Claim(ClaimTypes.Role, "funcionario"));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsInfo,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(1),
                signingCredentials);
             
            
            var userToken = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return userToken;
        }

        public async Task<string> GenerateTokenForExternalUsers(User user)
        {
            var securityKey = new SymmetricSecurityKey(
               Encoding.ASCII.GetBytes(_configuration["Authentication:SecretKey"]));

            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsInfo = new List<Claim>();
            claimsInfo.Add(new Claim(ClaimTypes.GivenName, user.Usuario));
            claimsInfo.Add(new Claim(ClaimTypes.Email, user.Email));
            claimsInfo.Add(new Claim(ClaimTypes.Role, "externo"));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsInfo,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(1),
                signingCredentials);


            var userToken = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return userToken;
        }
    }
}
