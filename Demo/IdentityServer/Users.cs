using System.Collections.Generic;
using System.Security.Claims;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Services.InMemory;
namespace Demo.IdentityServer
{
    public static class Users
    {
        public static IEnumerable<InMemoryUser> Get()
        {
            List<InMemoryUser> users = new List<InMemoryUser>();

            users.Add(new InMemoryUser
            {
                Username = "bob",
                Password = "secret",
                Subject = "1", //*** Must be unique for each user

                Claims = new[]
                {
                    new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                    new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                    new Claim(Constants.ClaimTypes.Name, "Bob Smith"),
                }
            });
            users.Add(new InMemoryUser
            {
                Username = "jane",
                Password = "secret",
                Subject = "2",

                Claims = new[]
                {
                    new Claim(Constants.ClaimTypes.GivenName, "Jane"),
                    new Claim(Constants.ClaimTypes.FamilyName, "Smyth"),
                    new Claim(Constants.ClaimTypes.Name, "Jane Smyth"),
                }
            });
            return users;
        }
    }
}