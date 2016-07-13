using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace Core.IdentityServer.Config
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "dashboardmanagement",
                    DisplayName = "Dashboard Management",
                    Description = "Allow the application to manage user-customized dashboard.",
                    Type = ScopeType.Resource
                }

            };
        }
    }
}