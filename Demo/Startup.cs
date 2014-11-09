using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Logging;
using Demo.IdentityServer;

[assembly: OwinStartup(typeof(Demo.Startup))]
namespace Demo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DiagnosticsTraceLogProvider logProvider = new DiagnosticsTraceLogProvider();
            LogProvider.SetCurrentLogProvider(logProvider);
            ILog logger = logProvider.GetLogger("");
            logger.Debug("*** Start Configuration ***");
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            string issuerUri = "https://localhost/embedded";

            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Demo Identity Server",
                    IssuerUri = issuerUri,
                    SigningCertificate = LoadCertificate(),

                    Factory = InMemoryFactory.Create(
                        users: Users.Get(),
                        clients: Clients.Get(),
                        scopes: Scopes.Get())
                });
            });
            logger.Debug("*** End Configuration ***");
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\identityServer\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}