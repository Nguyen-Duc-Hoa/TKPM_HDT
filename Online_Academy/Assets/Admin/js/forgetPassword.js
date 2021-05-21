$('document').ready(function () {
    $("#submitBtn").click(function (e) {
        const email = $("#email").val();
        if (!(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email))) {
            $(".validation-message").text("Email không hợp lệ")
            e.preventDefault()
        }
    })

    $("#email").click(function () {
        $(".validation-message").text("")
    })
})