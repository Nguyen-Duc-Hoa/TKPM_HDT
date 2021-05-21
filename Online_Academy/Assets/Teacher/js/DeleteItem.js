

$(function () {
    $(".btn-delchap").click(function () {
        debugger
        var r = confirm("Do you want to delete?");
        var idcurri = $(this).data('idchap');
        var idcourse = $(this).data('idcourse');
        if (r == true) {
            $.ajax({
                type: "GET",
                url: "/TeacherCourses/DeleteCurriculum",
                data: { idcourse: idcourse, idcurri: idcurri },
                success: function (response) {
                    alert("Success");
                    $("#curriculum").html(response);
                    
                },
                error: function () {
                    alert("Error");
                }
            });
        }
       
    })
    $(".btn-dellec").click(function () {
        debugger
        var r = confirm("Do you want to delete?");
       
        var idlec = $(this).data('idlec');
        var idcourse = $(this).data('idcourse');
        if (r == true) {
            $.ajax({
                type: "GET",
                url: "/TeacherCourses/DeleteLecture",
                data: { idcourse: idcourse, idlec: idlec },
                success: function (response) {
                    alert("Success");
                    $("#curriculum").html(response);
                    
                },
                error: function () {
                    alert("Error");
                }
            });
        }

    })
    $(".btn-delcourse").click(function () {

        var r = confirm("Do you want to delete?");

        var idcourse = $(this).data('idcourse');
        if (r == true) {
            $.ajax({
                type: "GET",
                url: "/TeacherCourses/Delete",
                data: { id: idcourse},
                success: function (response) {
                    alert("Success");
                    $("#course").html(response);
                   
                },
                error: function () {
                    alert("Error");
                }
            });
        }

    })
    $(".btn-delcoursedraft").click(function () {
       
        var r = confirm("Do you want to delete?");

        var idcourse = $(this).data('idcourse');
        if (r == true) {
            $.ajax({
                type: "GET",
                url: "/TeacherCourses/DeleteDraft",
                data: { id: idcourse },
                success: function (response) {
                    alert("Success");
                    $("#course").html(response);
                    
                },
                error: function () {
                    alert("Error");
                }
            });
        }

    })
});