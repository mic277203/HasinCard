var config = {
    authority: "http://localhost:5680",
    client_id: "js",
    redirect_uri: 'http://localhost:7762/SignCallBack',
    response_type: "id_token token",
    scope: "openid profile apihost",
    post_logout_redirect_uri: 'http://localhost:7762/Home'
};
var mgr = new Oidc.UserManager(config);