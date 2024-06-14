using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;


public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
            ) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Response.Headers.Add("WWW-Authenticate", "Basic");

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header missing."));
            }

            // Get authorization key
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var authHeaderRegex = new Regex(@"Basic (.*)");

            if (!authHeaderRegex.IsMatch(authorizationHeader))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization code not formatted properly."));
            }

            var authBase64 = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderRegex.Replace(authorizationHeader, "$1")));
            var authSplit = authBase64.Split(Convert.ToChar(":"), 2);
            var authUsername = authSplit[0];
            var authPassword = authSplit.Length > 1 ? authSplit[1] : throw new Exception("Unable to get password");

            if ((authUsername == "admin" && authPassword == "admin") || (authUsername == "test" && authPassword == "test"))
            {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, authUsername));

            if (authUsername == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
            }
            return Task.FromResult(AuthenticateResult.Fail("The username or password is not correct."));


            /*if (authUsername != "test" || authPassword != "test")
            {
                return Task.FromResult(AuthenticateResult.Fail("The username or password is not correct."));
            }

            var claims = new[] {                
                new Claim(ClaimTypes.Name, authUsername),
                new Claim(ClaimTypes.Role, "admin")
            };

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name))); */
        }
    }