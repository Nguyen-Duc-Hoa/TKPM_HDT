$(document).ready(function () {
    $(".approveBtn").click(function () {
        let idCourse = $(this).data("id");
        $.ajax({
            url: "/Admin/Course/Approve",
            type: "POST",
            data: { idCourse: idCourse },
            success: function (response) {
                console.log(response)
                if (response == "Fail") {
                    // Do something
                }
                else {
                    window.location.href = "https://localhost:44311/Admin/Course/Index";
                }
            }
        })
    })

    $(".cancelBtn").click(function () {
        let idCourse = $(this).data("id")
        var courseCard = getParent(this)

        $.ajax({
            url: "/Admin/Course/Cancel",
            type: "POST",
            data: { idCourse: idCourse },
            success: function (response) {
                console.log(response)
                // delete teacher card
                courseCard.remove()
                if (response == "Fail") {
                    // Do something
                }
                else {
                    window.location.href = "https://localhost:44311/Admin/Course/Index";
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