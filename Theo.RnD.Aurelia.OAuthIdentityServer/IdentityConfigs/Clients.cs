using IdentityServer4.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theo.RnD.Aurelia.OAuthIdentityServer.IdentityConfigs
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "aurelia.ui",
                    ClientId = "aurelia.ui",
                    Flow = Flows.Hybrid,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:10012"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:10011/unauthorized.html"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:10012"
                    },
                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                       StandardScopes.Roles.Name,
                       StandardScopes.Email.Name,
                       StandardScopes.Profile.Name,
                        "aurelia.backend.datarecords"
                    }
                },

                new Client
                {
                    ClientName = "aurelia.ui.js",
                    ClientId = "aurelia.ui.js",
                    Flow = Flows.AuthorizationCode,
                     RequireConsent = true,
                    AllowAccessToAllScopes=false,
                    AllowRememberConsent = true,
                    ClientSecrets = new List<Secret> {
                         new Secret("SuperSecret".Sha256())
                    },
                    RedirectUris = new List<string>
                    {
                        "http://localhost:10012"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:10011/unauthorized.html"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:10012"
                    },
                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                       StandardScopes.Roles.Name,
                       StandardScopes.Email.Name,
                       StandardScopes.Profile.Name,
                        "aurelia.backend.datarecords"
                    }
                }
            };
        }
    }
}
