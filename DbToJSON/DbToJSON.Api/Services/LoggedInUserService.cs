using DbToJSON.Application.Contracts;
using System.Security.Claims;

namespace DbToJSON.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public string? UserId { get; }
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        string ILoggedInUserService.UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ILoggedInUserService.UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
