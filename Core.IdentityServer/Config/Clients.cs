using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;

namespace Core.IdentityServer.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>();
        }
    }
}