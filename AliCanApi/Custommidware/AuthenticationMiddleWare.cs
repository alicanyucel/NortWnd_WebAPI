using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AliCanApi.Custommidware
{
    public class AuthenticationMiddleWare
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext contex)
        {
            //basic alican:12345
            string authHeader = contex.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring(6).Trim();
                var credentionalstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var creditonals = credentionalstring.Split(':');
                if (creditonals[0] == "alican" && creditonals[1] == "12345")
                {
                    var claims = new[] {
                        new Claim("name", creditonals[0]),
                        new Claim(ClaimTypes.Role, "admin")


                    };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    contex.User = new ClaimsPrincipal(identity);
                }
                else
                {
                    contex.Response.StatusCode = 401;
                }
                await _next(contex);
            }
        }
    }
}