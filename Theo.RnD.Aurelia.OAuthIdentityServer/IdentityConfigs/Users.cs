using IdentityModel;
using IdentityServer4.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace Theo.RnD.Aurelia.OAuthIdentityServer.IdentityConfigs
{
    public class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "1001234",
                    Username = "theo.rnd.test1",
                    Password = "password123",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Theo.RnD.Test1"),
                        new Claim(JwtClaimTypes.GivenName, "Theodar Test1" ),
                        new Claim(JwtClaimTypes.Email, "Theo.RnD.Test1@sun.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "user"),
                        new Claim(JwtClaimTypes.Role, "aurelia.backend.datarecords"),
                    }
                },
                new InMemoryUser
                {
                    Subject = "1001235",
                    Username = "theo.rnd.test2",
                    Password = "password123",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Theo.RnD.Test2"),
                        new Claim(JwtClaimTypes.GivenName, "Theodar Test2"),
                        new Claim(JwtClaimTypes.Email, "Theo.RnD.Test2@sun.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "user"),
                        new Claim(JwtClaimTypes.Role, "aurelia.backend.datarecords"),
                    }
                },
                 new InMemoryUser
                {
                    Subject = "1001236",
                    Username = "theo.rnd.superuser",
                    Password = "password123",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Theo.RnD.SuperUser"),
                        new Claim(JwtClaimTypes.GivenName, "Theodar SuperUser"),
                        new Claim(JwtClaimTypes.Email, "Theo.RnD.SuperUser@sun.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "superuser"),
                        new Claim(JwtClaimTypes.Role, "aurelia.backend.datarecords"),
                    }
                },
                  new InMemoryUser
                {
                    Subject = "1001235",
                    Username = "theo.rnd.admin",
                    Password = "password123",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Theo.RnD.Admin"),
                        new Claim(JwtClaimTypes.GivenName, "Theodar Admin"),
                        new Claim(JwtClaimTypes.Email, "Theo.RnD.Admin@sun.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Role, "aurelia.backend.datarecords"),
                    }
                  }
            };
        }
    }
}
