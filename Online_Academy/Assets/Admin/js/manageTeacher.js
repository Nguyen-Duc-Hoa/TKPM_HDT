$(document).ready(function () {
    $(".approveBtn").click(function () {
        let idTeacher = $(this).data("id");
        $.ajax({
            url: "/Admin/Teacher/Approve",
            type: "POST",
            data: { idTeacher: idTeacher },
            success: function (response) {
                console.log(response)
                if (response == "Fail") {
                    // Do something
                }
                else {
                    window.location.href = "https://localhost:44311/Admin/Teacher/Index";
                }
            }
        })
    })

    $(".cancelBtn").click(function () {
        let idTeacher = $(this).data("id")
        var teacherCard = getParent(this)

        $.ajax({
            url: "/Admin/Teacher/Cancel",
            type: "POST",
            data: { idTeacher: idTeacher },
            success: function (response) {
                console.log(response)
                // delete teacher card
                teacherCard.remove()
                if (response == "Fail") {
                    // Do something
                    alert("An error occurred while processing your request.");
                }
                else {
                    window.location.href = "https://localhost:44311/Admin/Teacher/Index";
                }
            }
        })
    })
    function getParent(element) {
        while (true) {
            if (element.parentElement.className.indexOf("post action-card col-lg-4 col-md-6 col-sm-12 col-xs-12 m-b40") !== -1) {
                return element.parentElement;
            }
            else {
                element = element.parentElement;
            }
        }
    }

})