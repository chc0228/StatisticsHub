using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.IdentityServer.Config;
using IdentityServer3.Core.Configuration;
using Owin;
using System.Security.Cryptography.X509Certificates;

namespace Core.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idserverApp =>
                {
                    var idServerServiceFactory = new IdentityServerServiceFactory()
                        .UseInMemoryClients(Clients.Get())
                        .UseInMemoryScopes(Scopes.Get())
                        .UseInMemoryUsers(Users.Get());

                    var options = new IdentityServerOptions
                    {
                        Factory = idServerServiceFactory,
                        SiteName = "Statistics Hub Information Display Security Token Service",
                        IssuerUri = Core.StatisticsHub.Constants.StatisticsHubIssuerUri,
                        PublicOrigin = Core.StatisticsHub.Constants.StatisticsHubSTSOrigin,
                        SigningCertificate = LoadCertificate()
                    };

                    idserverApp.UseIdentityServer(options);
                });
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\certificates\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}