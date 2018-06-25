var checkAuth;
var $navBar = $("nav #auth-item");
var $navBarOut = $("nav #reg-item");
var $navBarOrders = $("nav #orders");

$(document).ready(function () {

    checkAuth = function (_login, _password) {

        var dataJSON = {
            actionType: "AUTH"
            , login: _login
            , password: _password
        };

        $.ajax({
            type: 'POST',
            url: '/api/auth',
            data: JSON.stringify(dataJSON),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            cache: false
        }).done(function (responseText, textStatus, jqXHR) {
            //if got code 200
            if (responseText !== '' && responseText !== 'error') {

                if (responseText.signed != 'sign-out') {

                    if (responseText.signed == 'no_user') {

                        alert("Неверное имя и/или пароль");
                    } else {

                        console.log(responseText.signed);
                        $navBar.find('#sign-in').css("display", "none");;
                        $navBarOut.css("display", "none");
                        $navBar.find('#sign-out').text('SignOut (' + responseText.signed.login + ')');
                        $navBar.find('#sign-out').css("display", "block");


                        document.location = "/#orders";
                        //$navBarOrders.click();
                    }
                } else {
                    //console.log("dfhg");
                    $navBar.find('#sign-in').css("display", "block");
                    $navBarOut.css("display", "block");
                    $navBar.find('#sign-out').text('');
                    $navBar.find('#sign-out').css("display", "none");
                }

            } else {

                //
                alert("Произошла ошибка. Обратитесь к разработчику сайта");
            }
            //stopLoadingAnimation();
            $(".loader").css("display", "none");
        }).fail(function (jqXHR, textStatus, errorThrown) {

            //if got code 404 or 500, etc.
            //stopLoadingAnimation();
            $(".loader").css("display", "none");
            // alert("Произошла ошибка. Обратитесь к разработчику сайта");
        });
    }

    $navBar.find('#sign-out').click(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'GET',
            url: '/api/auth',
            data: { '_action': 'sign-out' },
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            cache: false
        }).done(function (responseText, textStatus, jqXHR) {
            //if got code 200
            if (responseText !== '' && responseText !== 'error') {

                //
                //console.log(responseText);
                //console.log($navBar.find('#sign-out'));
                $navBar.find('#sign-in').css("display", "block");
                $navBarOut.css("display", "block");
                $navBar.find('#sign-out').text('');
                $navBar.find('#sign-out').css("display", "none");

            } else {

                //
                alert("Произошла ошибка. Обратитесь к разработчику сайта");
            }
            //stopLoadingAnimation();
            $(".loader").css("display", "none");
        }).fail(function (jqXHR, textStatus, errorThrown) {

            //if got code 404 or 500, etc.
            //stopLoadingAnimation();
            $(".loader").css("display", "none");
            // alert("Произошла ошибка. Обратитесь к разработчику сайта");
            });
       
    });
    ///////
    $navBar.find('#sign-up').click(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'GET',
            url: '/api/auth',
            data: { '_action': 'sign-up' },
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            cache: false
        }).done(function (responseText, textStatus, jqXHR) {
            //if got code 200
            if (responseText !== '' && responseText !== 'error') {

                //
                //console.log(responseText);
                //console.log($navBar.find('#sign-out'));
                $navBar.find('#sign-in').css("display", "block");
                $navBarOut.css("display", "block");
                //$navBar.find('#sign-out').text('');
                //$navBar.find('#sign-out').css("display", "none");
            } else {

                //
                alert("Произошла ошибка. Обратитесь к разработчику сайта");
            }
            //stopLoadingAnimation();
            $(".loader").css("display", "none");
        }).fail(function (jqXHR, textStatus, errorThrown) {

            //if got code 404 or 500, etc.
            //stopLoadingAnimation();
            $(".loader").css("display", "none");
            // alert("Произошла ошибка. Обратитесь к разработчику сайта");
        });

    });
    ///////
    checkAuth("", "");
    
});