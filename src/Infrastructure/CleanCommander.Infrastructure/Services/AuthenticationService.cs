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
using CleanCommander.Application.Contracts.Persistence;

namespace CleanCommander.Infrastructure.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepo;

        public AuthenticationService(IConfiguration configuration, IUserRepository userRepo)
        {
            _configuration = configuration;
            _userRepo = userRepo;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest request)
        {
            var response = new AuthenticationResponse();
            if (VerifyPassword(request.Password, request.UserName))
                response.Token = GenerateJwtToken(request.UserName);

            return response;
        }

        private string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(20));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: new List<Claim>(),
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string pass, string userName)
        {
            //Get user by username from database.
            var user = _userRepo.GetUserByUserName(userName);
            if (user is not null)
            {
                //For some reason, \r\n is appended to the returned password hash json string. Remove this...
                user.PassWordHash = user.PassWordHash.Replace(System.Environment.NewLine, string.Empty);
                return BC.Verify(pass, user.PassWordHash);
            }
            return false;
        }
    }
}
