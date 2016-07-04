using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.IdentityServer.Config;
using IdentityServer3.Core.Configuration;
using Owin;

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
                        IssuerUri = ""
                    };

                    idserverApp.UseIdentityServer(options);
                });


        }
    }
}