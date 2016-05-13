using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theo.RnD.Aurelia.OAuthIdentityServer.UI.Consent
{
    public class ConsentInputModel
    {
        public IEnumerable<string> ScopesConsented { get; set; }
        public bool RememberConsent { get; set; }
    }
}
