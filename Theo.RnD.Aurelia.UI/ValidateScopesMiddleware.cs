using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Theo.RnD.Aurelia.UI
{
    public class ValidateScopesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<string> _validateScopes;

        public ValidateScopesMiddleware(RequestDelegate next, List<string> requiredScopes)
        {
            _next = next;
            _validateScopes = requiredScopes;
        }

        public async Task Invoke(HttpContext Cntxt)
        {
            if (Cntxt.User.Identity.IsAuthenticated)
            {
                if (!ScopeExists(Cntxt.User))
                {
                    Cntxt.Response.OnCompleted(Send403, Cntxt);
                    return;
                }
            }

            var test = Cntxt.User.Claims.ToList();
            await _next(Cntxt);
        }

        private Task Send403(object Cntxt)
        {
            var conntext = Cntxt as HttpContext;
            conntext.Response.StatusCode = 403;

            return Task.FromResult(0);
        }
        
        private bool ScopeExists(ClaimsPrincipal userPrincipal)
        {
            foreach (var scope in userPrincipal.FindAll("Scope"))
            {
                if (_validateScopes.Contains(scope.Value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
