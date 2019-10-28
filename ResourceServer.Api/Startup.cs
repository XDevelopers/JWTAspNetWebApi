using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Threading.Tasks;
using System.Web.Http;

namespace ResourceServer.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureOAuth(app);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            //// FUNCIONANDOOOOOOO
            ////var currentProvider = new AuthorizationServerProvider();

            ////app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            ////{
            ////    AllowInsecureHttp = true,
            ////    TokenEndpointPath = new PathString("/OAuth/Token"),
            ////    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            ////    Provider = currentProvider
            ////});
            ////app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            var issuer = "http://jwtauthzsrv.azurewebsites.net";
            var audience = "099153c2625149bc8ecb3e85e03f0022";
            var secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    },
                    Provider = new OAuthBearerAuthenticationProvider
                    {
                        OnValidateIdentity = context =>
                        {
                            context.Ticket.Identity.AddClaim(new System.Security.Claims.Claim("newCustomClaim", "newValue"));
                            return Task.FromResult<object>(null);
                        },
                        
                    }
                });

        }
    }
}