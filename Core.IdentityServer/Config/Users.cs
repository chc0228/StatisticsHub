using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Services.InMemory;

namespace Core.IdentityServer.Config
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>()
            {
                new InMemoryUser
                {
                    Username = "Joe",
                    Password = "secret",
                    Subject = "83145569-6253-456F-8A31-170793F54032"
                },
                new InMemoryUser
                {
                    Username = "Sven",
                    Password = "secret",
                    Subject = "9AB94711-5BD9-4F23-B4BD-9F5F2240EBB5"
                }
            };
        
        }

    }
}