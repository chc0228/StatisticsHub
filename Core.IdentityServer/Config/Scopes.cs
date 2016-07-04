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
                    Name = "statisticsmanagement",
                    DisplayName = "Statistics Management",
                    Description = "Allow the applicationn to manage user-customized statistics on your behalf.",
                    Type = ScopeType.Resource
                }

            };
        }
    }
}