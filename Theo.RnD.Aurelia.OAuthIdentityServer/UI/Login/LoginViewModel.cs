using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theo.RnD.Aurelia.OAuthIdentityServer.UI.Login
{
    public class LoginViewModel : LoginInputModel
    {
        public LoginViewModel()
        {
        }

        public LoginViewModel(LoginInputModel other)
        {
            Username = other.Username;
            Password = other.Password;
            RememberLogin = other.RememberLogin;
            SignInId = other.SignInId;
        }

        public string ErrorMessage { get; set; }
    }
}
