using System.Threading.Tasks;
using SharedServices.ObjectStorage.V1;
using Unity.Plastic.Newtonsoft.Json.Serialization;

namespace SharedServices.Authentication.V1
{
    public class TestUserAuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated { get; private set; }
        public string UserId { get; private set; } = "00000000-test-user-id-000000000000";
        public string Username { get; private set; } = "test-user";
        public string Token { get; private set; } = "00000000-test-user-token-000000000000";

        public void Authenticate(string username, string password, Action callback)
        {
            IsAuthenticated = true;
            UserId = $"00000000-{username}-id-000000000000";
            Username = username;
            Token = $"00000000-{username}-token-000000000000";
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