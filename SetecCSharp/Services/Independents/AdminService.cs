using FirebaseAdmin.Auth;

namespace SetecCSharp.Services.Independents
{
    public class AdminService()
    {
        public async Task SetRole(string Uid, string role)
        {
            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(Uid, new Dictionary<string, object>
            {
                { "role", role }
            });
        }

        public async Task SetClaims(string Uid, long UserId, string role)
        {
            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(Uid, new Dictionary<string, object>{
                { "userId", UserId },
                { "role", role }
            });
        }
    }
}