//EXTERNAL LOGIN JS
function onSignIn(googleUser) {
  
    var profile = googleUser.getBasicProfile();
    var id_token = googleUser.getAuthResponse().id_token;
    Checkrecord(profile);

};

function assignData(profile) {

    var inst = $('[data-remodal-id=modal]').remodal();
    $('#firstname').val(profile.getGivenName());
    $('#lastname').val(profile.getFamilyName());
    $('#email').val(profile.getEmail());
    $('#tokenid').val(profile.getId());
    inst.open();

}

function Checkrecord(profile) {

    var obj = new Object();
    obj.EmailAddress = profile.getEmail();
    obj.TokenId = profile.getId();

    $.ajax({
        url: '/Account/ExternalSignin',
        type: 'POST',
        cache: false,
        data: JSON.stringify(obj),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.result == "Redirect")
                window.location.href = data.url;
            else if (data == 0)
                assignData(profile);

        }
    });

}

function facebookLogin() {

    var inst = $('[data-remodal-id=modalfacebook]').remodal();
    inst.open();
    if (!$("input:radio[name='UserType']:checked").val()) {
        $('#errorMessage').fadeIn('slow');
        return false;
    }
    var value = $("input:radio[name='UserType']:checked").val();
    $.ajax({
        url: '/Account/FacebookLogin',
        type: 'POST',
        cache: false,
        data: "{ 'user': '" + value + "' }",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.result == "Redirect") {
                window.location.href = data.url;
            }
        }
    });

}

function signUp() {

    if (!$("input:radio[name='UserType']:checked").val()) {
        $('#errorMessage').fadeIn('slow');
        return false;
    }
    var obj = new Object();
    obj.UserType = $("input:radio[name='UserType']:checked").val();
    obj.FirstName = $('#firstname').val();
    obj.LastName = $('#lastname').val();
    obj.LoginEmail = $('#email').val();
    obj.ExternalLoginId = $('#tokenid').val();

    $.ajax({
        url: '/Tutoring/Account/ExternalSignUp',
        type: 'POST',
        cache: false,
        data: JSON.stringify(obj),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.result == "Redirect")
                window.location.href = data.url;
            else
                message(data);
        }
    });

}


var OAUTHURL = 'https://accounts.google.com/o/oauth2/auth?';
var VALIDURL = 'https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=';
var SCOPE = 'https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email';
var CLIENTID = '390823460617-guk4eav5mduuermtadnkt5e8hqb29305.apps.googleusercontent.com';
var REDIRECT = 'http://localhost:8090/Account/Login';
var LOGOUT = 'http://localhost:8090';
var TYPE = 'token';
var _url = OAUTHURL + 'scope=' + SCOPE + '&client_id=' + CLIENTID + '&redirect_uri=' + REDIRECT + '&response_type=' + TYPE;
var acToken;
var tokenType;
var expiresIn;
var user;
var loggedIn = false;
var userValue;
function login() {
	debugger;
    var inst = $('[data-remodal-id=modalgoogle]').remodal();
    inst.open();
    if (!$("input:radio[name='UserType']:checked").val()) {
        $('#errorMessage').fadeIn('slow');
        return false;
    }
    userValue = $("input:radio[name='UserType']:checked").val();



    var win = window.open(_url, "windowname1", 'width=800, height=600');
    var pollTimer = window.setInterval(function () {
        try {
            console.log(win.document.URL);
            if (win.document.URL.indexOf(REDIRECT) != -1) {
                window.clearInterval(pollTimer);
                var url = win.document.URL;
                acToken = gup(url, 'access_token');
                tokenType = gup(url, 'token_type');
                expiresIn = gup(url, 'expires_in');

                win.close();
                debugger;
                validateToken(acToken);
            }
        }
        catch (e) {

        }
    }, 500);
}
function gup(url, name) {
    namename = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\#&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(url);
    if (results == null)
        return "";
    else
        return results[1];
}

function validateToken(token) {

    getUserInfo();
    $.ajax(

        {

            url: VALIDURL + token,
            data: null,
            success: function (responseText) {


            },

        });

}

function getUserInfo() {



    $.ajax({

        url: 'https://www.googleapis.com/oauth2/v1/userinfo?access_token=' + acToken,
        data: null,
        success: function (resp) {
            user = resp;
            console.log(user);
            $.ajax({
                url: '/Account/GoogleLogin/',
                type: 'POST',
                data: {
                    usertype:userValue,
                    email: user.email,
                    fname: user.given_name,
                    lname: user.family_name,
                    token:user.id
                },
                success: function (result) {
                    if (result.url) {
                        // if the server returned a JSON object containing an url 
                        // property we redirect the browser to that url
                        window.location.href = result.url;
                    }
                    else
                        {
                        window.location.href = "/Home/Index/";
                    }

                }

              

            });
        },


    });

}




