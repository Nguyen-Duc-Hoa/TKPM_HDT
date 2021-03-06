

$('document').ready(function () {

    function validInput(username, password) {
        if (username == "" || password == "") {
            return false
        }
    }

    $("#username").change(function () {
        $('.validation-message').text("")
    })

    $("#password").change(function () {
        $('.validation-message').text("")
    })

    $('#SubmitLogin').click(function () {
        // get data
        var username = $('#username').val();
        var password = $('#password').val();
        var rememberCheck = $('input[name=rememberCheck]:checked').val();

        if (validInput(username, password) == false) {
            $('.validation-message').text("Vui lòng nhập đầy đủ các trường")
            return
        }

        $.ajax({
            url: '/Account/SubmitLogin',
            data: { username: username, password: password, rememberCheck: rememberCheck },
            type: 'POST',
            success: function (response) {
                console.log(response)
                if (response == "Fail") {
                    $("#exampleModal").modal('show')
                }
                else {
                    // Move to main page
                    window.location.replace(response);
                }
            }
        })
    })
})