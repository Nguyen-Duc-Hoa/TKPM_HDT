$(document).ready(function () {
    $("#submitBtn").click(function (e) {
        var email = $("#email").val()
        var confEmail = $("#confirm").val()
        if (email == "" || confEmail == "") {
            e.preventDefault()
            $(".validation-message").text("Nhập đẩy đủ thông tin")
        }
        else if (email !== confEmail) {
            e.preventDefault()
            $(".validation-message").text("Mật khẩu không trùng khớp")
        }
    })
    $("#confirm").click(function () {
        $(".validation-message").text("")
    })
})