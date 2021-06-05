$(document).ready(function () {
    $(".approveBtn").click(function () {
        let idStudent = $(this).data("id");
        $.ajax({
            url: "/Admin/Student/Approve",
            type: "POST",
            data: { idStudent: idStudent },
            success: function (response) {
                console.log(response)
                if (response == "Fail") {
                    // Do something
                }
                else {
                    window.location.href = "https://localhost:44311/Admin/Student/Index";
                }
            }
        })
    })

    $(".cancelBtn").click(function () {
        let idStudent = $(this).data("id")
        var studentCard = getParent(this)

        $.ajax({
            url: "/Admin/Student/Cancel",
            type: "POST",
            data: { idStudent: idStudent },
            success: function (response) {
                console.log(response)
                // delete teacher card
                studentCard.remove()
                if (response == "Fail") {
                    // Do something
                    alert("An error occurred while processing your request.");
                }
                else {
                    window.location.href = "https://localhost:44311/Admin/Student/Index";
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