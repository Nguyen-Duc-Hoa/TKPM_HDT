
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

        
    });
