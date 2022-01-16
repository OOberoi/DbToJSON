using DbToJSON.Application.Models;

namespace DbToJSON.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationRequest> AuthenticateAsync(AuthenticationRequest request); 
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
