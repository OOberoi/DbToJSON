using DbToJSON.Application.Contracts;

namespace DbToJSON.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        string ILoggedInUserService.UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ILoggedInUserService.UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
