

$(function () {
    $(".btn-draft").click(function () {

        var namecourse = $.trim($("#namecourse").val());
        var sub = parseInt($("#id_subcat").val())
        var price = $("#price").val();
        var discount = $("#discount").val();

        // var fileimg = $("#fileimg").prop("files")[0];
        var fileimg = $("#fileimg")[0].files[0];

        var preview = $("#preview")[0].files[0];
        //var preview= multer({ storage: storage }).single('preview');
        var shortdes = $.trim($("#shortdes").val());
        var description = $.trim($("#description").val());
        var id = $("#id").val();
        var formdata = new FormData();
        debugger
        var count = $(".list-item");
        var chaptername = new Array();
        var idcurri = new Array();
        for (var i = 0; i < count.length; i++) {
            idcurri[i] = $($('.idcurri')[i]).text();
            chaptername[i] = $.trim($($('.chapter')[i]).val());
            var c = $($(".listvideo")[i]).children();
            formdata.append("lengthvideo[" + i + "]", c.length);

            for (var j = 0; j < c.length; j++) {
                // var d = c[i].find('.videoitem')[j];
                // var d = $($(".videoitem")[j]);
                var d = c[j];

                //  var d = e.children();
                var videoname = $.trim($(d).find('.name').val());
                var linkvideo = $(d).find('.filevideo')[0].files[0];
                var idlec = $(d).find('.idlec').text();
                formdata.append("linkvideo[" + i + "]" + "[" + j + "]", linkvideo);
                formdata.append("videoname[" + i + "]" + "[" + j + "]", videoname);
                formdata.append("idlec[" + i + "]" + "[" + j + "]", idlec);
               
            }

        }
        debugger
       
        formdata.append("fileimg", fileimg);
        formdata.append("preview", preview);
        formdata.append("namecourse", namecourse);
        formdata.append("sub", sub);
        formdata.append("discount", discount);
        formdata.append("price", price);
        formdata.append("description", description);
        formdata.append("shortdes", shortdes);

        formdata.append("chaptername", chaptername);
        formdata.append("idcurri", idcurri);
        formdata.append("idcourse", id);
        formdata.append("state", 0);
      
        for (var p of formdata) {
            console.log(p);
        }

        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/TeacherCourses/Edit');
        xhr.onreadystatechange = function () { // listen for state changes
            if (xhr.readyState == 4 && xhr.status == 200) {
                // when completed we can move away
                alert("Success")
               
            }
        }
        xhr.send(formdata);
      
    })
    $(".btn-postcourse").click(function () {

        var namecourse = $("#namecourse").val();
        var sub = parseInt($("#id_subcat").val())
        var price = $("#price").val();
        var discount = $("#discount").val();

        // var fileimg = $("#fileimg").prop("files")[0];
        var fileimg = $("#fileimg")[0].files[0];

        var preview = $("#preview")[0].files[0];
        //var preview= multer({ storage: storage }).single('preview');
        var shortdes = $("#shortdes").val();
        var description = $("#description").val();
        var id = $("#id").val();
        var formdata = new FormData();
        debugger
        var count = $(".list-item");
        var chaptername = new Array();
        var idcurri = new Array();
        for (var i = 0; i < count.length; i++) {
            idcurri[i] = $($('.idcurri')[i]).val();
            chaptername[i] = $($('.chapter')[i]).val();
            var c = $($(".listvideo")[i]).children();
            formdata.append("lengthvideo[" + i + "]", c.length);

            for (var j = 0; j < c.length; j++) {
                // var d = c[i].find('.videoitem')[j];
                // var d = $($(".videoitem")[j]);
                var d = c[j];

                //  var d = e.children();
                var videoname = $(d).find('.name').val();
                var linkvideo = $(d).find('.filevideo')[0].files[0];
                var idlec = $(d).find('.idlec').val();
                formdata.append("linkvideo[" + i + "]" + "[" + j + "]", linkvideo);
                formdata.append("videoname[" + i + "]" + "[" + j + "]", videoname);
                formdata.append("idlec[" + i + "]" + "[" + j + "]", idlec);
               
            }

        }
        debugger
      
        formdata.append("fileimg", fileimg);
        formdata.append("preview", preview);
        formdata.append("namecourse", namecourse);
        formdata.append("sub", sub);
        formdata.append("discount", discount);
        formdata.append("price", price);
        formdata.append("description", description);
        formdata.append("shortdes", shortdes);

        formdata.append("chaptername", chaptername);
        formdata.append("idcurri", idcurri);
        formdata.append("idcourse", id);
        formdata.append("state", 1);
       

        for (var p of formdata) {
            console.log(p);
        }

        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/TeacherCourses/Edit');
        xhr.onreadystatechange = function () { // listen for state changes
            if (xhr.readyState == 4 && xhr.status == 200) {
                // when completed we can move away
                alert("Success")
                
            }
        }
        xhr.send(formdata);
     
    })
});