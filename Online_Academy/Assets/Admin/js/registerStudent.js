$(document).ready(function () {
    function validator(name, email, username, password) {
        if (!(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email))) {
            $(".validation-message").text("Vui lòng nhập email hợp lệ")
            return false
        }
        else if (name == undefined || username == undefined || password == undefined) {
            $(".validation-message").text("Vui lòng nhập đầy đủ thông tin")
            return false
        }
        return true
    }

    $("#name").click(function () {
        $(".validation-message").text("")
    })
    $("#email").click(function () {
        $(".validation-message").text("")
    })
    $("#username").click(function () {
        $(".validation-message").text("")
    })
    $("#password").click(function () {
        $(".validation-message").text("")
    })

    $("#SubmitRegister").click(function () {
        let name = $("#name").val();
        let email = $("#email").val();
        let username = $("#username").val();
        let password = $("#password").val();

        if (validator(name, email, username, password) == false) {
            return
        }

        $.ajax({
            url: "/Account/RegisterStudent",
            type: "POST",
            data: { name: name, email: email, username: username, password: password },
            success: function (response) {
                if (response == "Fail") {
                    $(".modal-body").html('<p>Đăng ký thành công</p>')
                    $("#exampleModal").modal('show')
                }
                else {
                    $(".modal-body").html('<p>Đăng ký không thành công</p>' + '<p>Tài khoản hoặc email đã tồn tại</p>')
                    $("#exampleModal").modal('show')
                }
            }
        })
    })
})