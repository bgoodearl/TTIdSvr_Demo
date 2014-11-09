using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thinktecture.IdentityServer.Core.Models;

namespace Demo.IdentityServer
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
#if true
            var scopes = new List<Scope>(
            new[]
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    StandardScopes.OfflineAccess,

                    new Scope
                    {
                        Name = "read",
                        DisplayName = "Read data",
                        Type = ScopeType.Resource,
                        Emphasize = false,
                    },
                    new Scope
                    {
                        Name = "write",
                        DisplayName = "Write data",
                        Type = ScopeType.Resource,
                        Emphasize = true,
                    }
                });
            var scope = new Scope
            {
                Enabled = true,
                Name = "roles",
                Type = ScopeType.Identity,
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim("role")
                }
            };
            scopes.Add(scope);
            return scopes;

#else
            var scopes = new List<Scope>
            {
            };

            var scope = new Scope
            {
                Enabled = true,
                Name = "roles",
                Type = ScopeType.Identity,
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim("role")
                }
            };
            scopes.Add(scope);

            scopes.AddRange(StandardScopes.All);

            return scopes;
#endif
        }
    }
}