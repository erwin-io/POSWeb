using Microsoft.Owin;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Jwt;
using Owin;
using POSWeb.OAuth.Providers;
using POSWeb.Data;
using POSWeb.Data.Interface;
using POSWeb.Facade;
using POSWeb.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using POSWeb.Mapping;
using POSWeb.OAuth.Helpers;

[assembly: OwinStartup(typeof(POSWeb.OAuth.Startup))]
namespace POSWeb.OAuth
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            GlobalVariables.goIssuer = GlobalVariables.GetApplicationConfig("Issuer");
            GlobalVariables.goAudienceId = GlobalVariables.GetApplicationConfig("audienceID");
            GlobalVariables.goAudienceSecret = GlobalVariables.GetApplicationConfig("audienceSecret");
            GlobalVariables.goClientId = GlobalVariables.GetApplicationConfig("ClientId");
            GlobalVariables.goRefreshTokenLifeTime = double.Parse(GlobalVariables.GetApplicationConfig("RefreshTokenLifeTime"));

            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();
            AutoMapperConfig.Configure("POSWeb.Mapping");

            // Web API routes
            //config.MapHttpAttributeRoutes();

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.MapSignalR();

            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            string connectionString = Helpers.Configuration.ConnectionString();
            IDbConnection dbConnection = new SqlConnection(connectionString);
            //DAC
            ISystemUserRepositoryDAC _systemUserRepository = new SystemUserDAC(dbConnection);
            ISystemTokenRepositoryDAC _systemTokenRepositoryDAC = new SystemTokenDAC(dbConnection);
            //Facade
            IUserAuthFacade _userAuthFacade = new UserAuthFacade(_systemUserRepository);
            ISystemTokenFacade systemTokenFacade = new SystemTokenFacade(_systemTokenRepositoryDAC);

            var issuer = GlobalVariables.goIssuer;

            var refreshTokenLifeTime = GlobalVariables.goRefreshTokenLifeTime;

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(refreshTokenLifeTime),
                Provider = new AppOAuthProvider(_userAuthFacade),
                AccessTokenFormat = new AppOAuthJWTFormat(issuer),
                RefreshTokenProvider = new AppRefreshTokenProvider(systemTokenFacade)
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}