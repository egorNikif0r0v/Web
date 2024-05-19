using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StockExchange.Application.Interfaces.Auth;
using StockExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Infrastructure
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {
        private readonly JwtOptions _options = options.Value;

        

        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];
            var stringCred = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: stringCred,
                expires: DateTime.UtcNow.AddHours(_options.ExpitesHours));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
