using System;
using System.Threading.Tasks;
using SharedServices.ObjectStorage.V1;
using SharedServices.V1;

namespace SharedServices.Authentication.V1
{
    public interface IAuthenticationService : IService
    {
        bool IsAuthenticated { get; }
        string UserId { get; }
        string Username { get; }
        string Token { get; }
        
        void Authenticate(string username, string password, Action callback);
        Task AuthenticateAsync(string username, string password);
        WaitUntilCallback AuthenticateRoutine(string username, string password);
        void Logout();
    }
}