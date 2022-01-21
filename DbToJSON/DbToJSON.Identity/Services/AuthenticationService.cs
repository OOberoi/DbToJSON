using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using DbToJSON.Application.Contracts.Identity;
using DbToJSON.Application.Models;
using DbToJSON.Identity.Models;


namespace DbToJSON.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser>? _userManager;
        Task<AuthenticationRequest> IAuthenticationService.AuthenticateAsync(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        Task<RegistrationResponse> IAuthenticationService.RegisterAsync(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
