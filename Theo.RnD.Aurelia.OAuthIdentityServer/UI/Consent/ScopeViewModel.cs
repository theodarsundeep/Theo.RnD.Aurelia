using IdentityServer4.Core.Extensions;
using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;

namespace Theo.RnD.Aurelia.OAuthIdentityServer.UI.Consent
{
     public class ScopeViewModel
    {
         public ScopeViewModel(ILocalizationService localization, Scope scope, bool check)
        {
            Name = scope.Name;
            DisplayName = localization.GetScopeDisplayName(scope.Name) ?? scope.DisplayName;
            Description = localization.GetScopeDescription(scope.Name) ?? scope.Description;
            Emphasize = scope.Emphasize;
            Required = scope.Required;
            Checked = check || scope.Required;
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Emphasize { get; set; }
        public bool Required { get; set; }
        public bool Checked { get; set; }

    }
}