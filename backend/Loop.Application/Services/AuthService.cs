using Loop.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Loop.Application.Services
{
    public class AuthService 
    {

        private readonly IConfiguration _configuration;
        

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
