var authConfig = {
    apiServerBaseUrl: "http://localhost:10012/",
    profileUrl: "http://localhost:10011/connect/userinfo",
    responseTokenProp: 'Token',
    providers: {
        OAuthIdentityServer: {
            name: "OAuthIdentityServer",
            url: "Token/Exchange",
            authorizationEndpoint: "http://localhost:10011/connect/authorize",
            redirectUri: window.location.origin || window.location.protocol + '//' + window.location.host,
            scope: ['aurelia.backend.datarecords', 'openid', 'profile'],
            //responseType: 'id_token token',
            responseType: 'code',

            scopePrefix: '',
            scopeDelimiter: ' ',
            requiredUrlParams: ['scope'],
            optionalUrlParams: ['display', 'state'],
            state: function () {
                var val = ((Date.now() + Math.random()) * Math.random()).toString().replace(".", "");
                return encodeURIComponent(val);
            },
            display: 'popup',
            type: '2.0',
            clientId: 'aurelia.ui.js',

            nonce: function () {
                var val = ((Date.now() + Math.random()) * Math.random()).toString().replace(".", "");
                return encodeURIComponent(val);
            },
            popupOptions: { width: 452, height: 633 }
        }

    }
}
export default authConfig;