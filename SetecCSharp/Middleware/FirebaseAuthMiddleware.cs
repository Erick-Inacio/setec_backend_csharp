using System.Security.Claims;
using FirebaseAdmin.Auth;

namespace SetecCSharp.Middleware
{
    public class FirebaseAuthMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var authHeader = context.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token de autenticação não fornecido.");
                return;
            }

            var token = authHeader.Replace("Bearer ", "");

            try
            {
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
                var uid = decodedToken.Uid;

                //Extrai a Custom clain (role) do token
                decodedToken.Claims.TryGetValue("role", out var roleObj);
                var role = roleObj?.ToString() ?? "";

                //Cria um ClaimsPrincipal
                var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, uid),
                };

                if (!string.IsNullOrEmpty(role))
                    claims.Add(new Claim(ClaimTypes.Role, role));

                var identity = new ClaimsIdentity(claims, "Firebase");
                context.User = new ClaimsPrincipal(identity);


            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Exception capturada: " + ex.Message);
            }

            await _next(context);
        }
    }
}