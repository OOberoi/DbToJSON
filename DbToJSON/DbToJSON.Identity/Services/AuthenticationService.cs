using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using DbToJSON.Application.Contracts.Identity;
using DbToJSON.Application.Models;
using DbToJSON.Identity.Models;
using Microsoft.Extensions;
using DbToJSON.Application.Models.Authentication;
using Microsoft.Extensions.Options;

namespace DbToJSON.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwSettings.Value;
        }
        async Task<AuthenticationRequest> IAuthenticationService.AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found!!");
            }

            var retVal = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!retVal.Succeeded)
            {
                throw new Exception($"Credentials for {request.Email} are invalid!");
            }

            JwtSecurityToken token = await GenerateToken(user);

            AuthenticationResponse response = new()
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        private Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task<RegistrationResponse> IAuthenticationService.RegisterAsync(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
