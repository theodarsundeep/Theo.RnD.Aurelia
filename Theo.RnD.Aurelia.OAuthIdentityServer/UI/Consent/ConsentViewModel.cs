using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theo.RnD.Aurelia.OAuthIdentityServer.UI.Consent
{
    public class ConsentViewModel : ConsentInputModel
    {
        public ConsentViewModel(ConsentInputModel model, string consentId, ConsentRequest request, Client client, IEnumerable<Scope> scopes, ILocalizationService localization)
        {
            RememberConsent = model?.RememberConsent ?? true;
            ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>();

            ConsentId = consentId;

            ClientName = client.ClientName;
            ClientUrl = client.ClientUri;
            ClientLogoUrl = client.LogoUri;
            AllowRememberConsent = client.AllowRememberConsent;

            IdentityScopes = scopes.Where(x => x.Type == ScopeType.Identity).Select(x => new ScopeViewModel(localization, x, ScopesConsented.Contains(x.Name) || model == null)).ToArray();
            ResourceScopes = scopes.Where(x => x.Type == ScopeType.Resource).Select(x => new ScopeViewModel(localization, x, ScopesConsented.Contains(x.Name) || model == null)).ToArray();
        }

        public string ConsentId { get; set; }

        public string ClientName { get; set; }
        public string ClientUrl { get; set; }
        public string ClientLogoUrl { get; set; }
        public bool AllowRememberConsent { get; set; }

        public IEnumerable<ScopeViewModel> IdentityScopes { get; set; }
        public IEnumerable<ScopeViewModel> ResourceScopes { get; set; }
    }
}
