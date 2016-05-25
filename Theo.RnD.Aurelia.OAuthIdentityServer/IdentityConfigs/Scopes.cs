using IdentityServer4.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theo.RnD.Aurelia.OAuthIdentityServer.IdentityConfigs
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.ProfileAlwaysInclude,
                StandardScopes.EmailAlwaysInclude,
                StandardScopes.OfflineAccess,
                StandardScopes.RolesAlwaysInclude,
                new Scope
                {
                    Name = "aurelia.backend.datarecords",
                    DisplayName = "Scope for the backend API for UI",
                    Type = ScopeType.Resource,
                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("aurelia.backend.datarecords".Sha256())
                    },
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim(StandardScopes.Roles.Name),
                        new ScopeClaim("aurelia.backend.datarecords")
                    }
                }
        };
            scopes.AddRange(StandardScopes.All);
            return scopes;
        }

    }
}
