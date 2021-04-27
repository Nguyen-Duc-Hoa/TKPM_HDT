

$(document).ready(function () {

    //script click type => load view
    $(".btn-info-icon").click(function () {

        console.log("click");

        var idcate = $(this).data("id_cate");

            
        var var1 = $(this).data("list1");
        var var2 = $(this).data("list2");

        console.log(idcate);
        $.ajax({
            url: "/Student/Courses/CourseByType",
            data: { id: idcate },
            success: function (result) {
                $(".upCourse").html(result);
            }
        });

        $.ajax({
            url: "/Student/Courses/UpdateList_inline",
            data: { var1: var1, var2: var2 },
            success: function (result) {
                $(".loadList").html(result);
            }
        });
    });

    $(".general").click(function () {
        console.log("click");

        $.ajax({
            url: "/Student/Courses/General",
            success: function (result) {
                $(".upCourse").html(result);
            }
        });

        $.ajax({
            url: "/Student/Courses/UpdateList_inline",
            data: { var1: "All Course", var2: null },
            success: function (result) {
                $(".loadList").html(result);
            }
        });
    });


    //add favorite course
    $(".heart").click(function () {
        debugger;

        var stt = parseInt($(this).data("stt"));
        var id = $(this).data("id");
        var currentColor = document.getElementsByTagName("path")[stt].getAttribute("fill");
        
        // click like the course
        if (currentColor == "#AAB8C2") {

            document.getElementsByTagName("path")[stt].setAttribute("fill", "#F00000");
            $.ajax({
                url: "/Student/Courses/Like",
                data: { idCourse: id },
                success: function (result) {
                    
                    alert('Like');
                }
            });
            

        }
        // remove like the course
        else if (currentColor == "#F00000") {
            document.getElementsByTagName("path")[stt].setAttribute("fill", "#AAB8C2");
        }
        alert('You clicked me');
    });

    $(document).on('click', 'path', function () {

    });

});

