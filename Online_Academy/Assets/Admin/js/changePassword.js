$(document).ready(function () {
    $("#submitBtn").click(function (e) {
        var email = $("#email").val()
        var confEmail = $("#confirm").val()
        if (email !== confEMail) {
            e.preventDefault()
            $(".validation-message").text("Mật khẩu không trùng khớp")
        }
    })
    $("#confirm").click(function () {
        $(".validation-message").text("")
    })
})