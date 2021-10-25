using CleanCommander.Application.Contracts.Authentication;
using CleanCommander.Application.Models.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;
using System.Threading.Tasks;

namespace CleanCommander.Infrastructure.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest request)
        {
            var response = new AuthenticationResponse();
            string token;
            //If match, call GenerateJwtToken.
            if (VerifyPassword(request.Password))
                response.Token = GenerateJwtToken(request.UserName);

            return response;
            //If not, return
        }

        private string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(20));

            var token = new JwtSecurityToken(
                _configuration["Issuer"],
                _configuration["Audience"],
                claims: new List<Claim>(),
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string pass)
        {
            var list = File.ReadLines("models/data.txt").ToList();
            return BC.Verify(pass, list[1]);

        }
    }
}
