using IdentityServer4.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theo.RnD.Aurelia.OAuthIdentityServer.Extensions
{
    public class CustomGrantValidator : ICustomGrantValidator
    {
        public Task<CustomGrantValidationResult> ValidateAsync(ValidatedTokenRequest request)
        {
            var credential = request.Raw.Get("custom_credential");

            if (credential != null)
            {
                // valid credential
                return Task.FromResult(new CustomGrantValidationResult("818727", "custom"));
            }
            else
            {
                // custom error message
                return Task.FromResult(new CustomGrantValidationResult("invalid custom credential"));
            }
        }

        public string GrantType
        {
            get { return "custom"; }
        }
    }
}
