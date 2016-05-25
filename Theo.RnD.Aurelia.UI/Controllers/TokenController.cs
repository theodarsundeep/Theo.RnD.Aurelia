using IdentityModel.Client;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theo.RnD.Aurelia.UI.Controllers
{
    public class TokenController : Controller
    {
        public TokenController()
        {

        }

        public class TokenExchangeInput
        {
            public string Code { get; set; }
            public string RedirectUri { get; set; }
            public string ClientId { get; set; }
        }

        public class TokenResponse
        {
            public string Token { get; set; }
        }

        [HttpPost()]
        public async Task<ActionResult> Exchange([FromBody]TokenExchangeInput tokenInput)
        {
            var client = new TokenClient("http://localhost:10011/connect/token", "aurelia.ui.js", "SuperSecret");
            var tokenResponse = await client.RequestAuthorizationCodeAsync(tokenInput.Code, tokenInput.RedirectUri);
            return Json(new TokenResponse { Token = tokenResponse.AccessToken });
        }

    }
}
