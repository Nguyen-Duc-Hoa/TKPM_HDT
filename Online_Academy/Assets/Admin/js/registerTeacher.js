﻿$(document).ready(function () {
    function validator(name, email, username, password) {
        if (!(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email))) {
            $(".validation-message").text("Vui lòng nhập email hợp lệ")
            return false
        }
        else if (name == undefined || username == undefined || password == undefined || major == undefined) {
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
        let major = $("#major").val();

        if (validator(name, email, username, password, major) == false) {
            return
        }

        $.ajax({
            url: "/Account/RegisterTeacher",
            type: "POST",
            data: { name: name, email: email, username: username, password: password, major: major },
            success: function (response) {
                if (response == "Fail") {
                    // Move to student main page
                }
                else {
                    $("#exampleModal").modal('show')
                }
            }
        })
    })
})