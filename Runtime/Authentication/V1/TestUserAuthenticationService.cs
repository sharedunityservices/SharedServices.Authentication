using System;
using System.Threading.Tasks;
using SharedServices.ObjectStorage.V1;

namespace SharedServices.Authentication.V1
{
    [UnityEngine.Scripting.Preserve]
    public class TestUserAuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated { get; private set; }
        public string UserId { get; private set; } = "----test-user-id----";
        public string Username { get; private set; } = "test-user";
        public string Token { get; private set; } = "----test-user-id----";

        public void Authenticate(string username, string password, Action callback)
        {
            IsAuthenticated = true;
            UserId = $"----{username.ToLower()}----";
            Username = username;
            Token = $"----{username.ToLower()}----";
        }

        public async Task AuthenticateAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            Authenticate(username, password, () => tcs.SetResult(true));
            await tcs.Task;
        }

        public WaitUntilCallback AuthenticateRoutine(string username, string password)
        {
            return new WaitUntilCallback(callback => Authenticate(username, password, () => callback()));
        }

        public void Logout()
        {
            IsAuthenticated = false;
        }
    }
}