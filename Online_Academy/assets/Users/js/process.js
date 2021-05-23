$(document).ready(function () {
    $(".lesson123").click(function () {
        debugger;
        var stt = $(this).data("id");
        console.log(document.getElementsByClassName("videos123")[stt].getAttribute("style"));

        var them = document.getElementsByClassName("videos123")[stt].getAttribute("style");
        if (them == "display:none") {
            document.getElementsByClassName("videos123")[stt].setAttribute("style", "display:block");
            $.ajax({
                url: "/Student/MyCourse/Process",
                data: { process: stt },
                success: function (result) {
                    alert("ban dang hoc " + stt);
                }
            });
        }
        else if (them == "display:block") {
            document.getElementsByClassName("videos123")[stt].setAttribute("style", "display:none");
        }
    });
});