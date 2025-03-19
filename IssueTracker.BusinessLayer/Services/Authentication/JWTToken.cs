using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IssueTracker.ModelLayer.Users.Objects;
using Microsoft.IdentityModel.Tokens;

namespace IssueTracker.BusinessLayer.Services.Authentication
{
    public sealed class JWTToken
    {
        private readonly string _jwtKey;

        public JWTToken(string jwtKey)
        {
            _jwtKey = jwtKey;
        }

        public string GenerateJSONWebToken(string username, string userType, User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, userType),
                    new Claim(ClaimTypes.SerialNumber, user.UserId.ToString()),
                    new Claim(ClaimTypes.Rsa, user.UserRoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
