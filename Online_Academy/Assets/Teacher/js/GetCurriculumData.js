

$(function () {
    $(".btn-savedraft").click(function () {
        $("#divLoading").show();
        var namecourse = $("#namecourse").val();
        var sub = parseInt($("#id_subcat").val())
        var price = $("#price").val();
        var discount = $("#discount").val();
        if (parseInt(price) < 0 ) {
            $("#divLoading").hide();
            alert("Please enter price bigger 0");
            return;
        }
        if (parseInt(discount) < 0 || parseInt(discount)>100) {
            $("#divLoading").hide();
            alert("Please enter discount less 100 and bigger 0");
            return;
        }
        // var fileimg = $("#fileimg").prop("files")[0];
        var fileimg = $("#fileimg")[0].files[0];
        
        var preview = $("#preview")[0].files[0];
        
       //var preview= multer({ storage: storage }).single('preview');
        var shortdes = $("#shortdes").val();
        var description = $("#description").val();
       
        var formdata = new FormData();
        debugger
        var count = $(".list-item");
        var chaptername = new Array();
       
        for (var i = 0; i < count.length; i++) {
            console.log($($('.chapter')[i]).val());
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
                formdata.append("linkvideo[" + i + "]" + "[" + j + "]", linkvideo);
                formdata.append("videoname[" + i + "]" + "[" + j + "]", videoname);
                //videoname[i][j] = $($('.name')[j]).val();
                // linkvideo[i][j]= $($('.filevideo')[j])[0].files[0];
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
        formdata.append("statesave", 0);
     
       for (var p of formdata) {
            console.log(p);
        }
        
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/TeacherCourses/Create');
        xhr.onreadystatechange = function () { // listen for state changes
            if (xhr.readyState == 4 && xhr.status == 200) {
                // when completed we can move away
                $("#divLoading").hide();
                alert("Success")
               
            }
        }
      
        xhr.send(formdata);
     
    })
    $(".btn-post").click(function () {
          $("#divLoading").show();
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

        var formdata = new FormData();
        debugger
        var count = $(".list-item");
        var chaptername = new Array();

        for (var i = 0; i < count.length; i++) {
            console.log($($('.chapter')[i]).val());
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
                formdata.append("linkvideo[" + i + "]" + "[" + j + "]", linkvideo);
                formdata.append("videoname[" + i + "]" + "[" + j + "]", videoname);
                //videoname[i][j] = $($('.name')[j]).val();
                // linkvideo[i][j]= $($('.filevideo')[j])[0].files[0];
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
        formdata.append("statesave", 1);
        // formdata.append("videoname", videoname);
        //  formdata.append("linkvideo", linkvideo);

        for (var p of formdata) {
            console.log(p);
        }
      
        var xhr = new XMLHttpRequest();
        
        xhr.open('POST', '/TeacherCourses/Create');
        xhr.onreadystatechange = function () { // listen for state changes
            if (xhr.readyState == 4 && xhr.status == 200) {
                // when completed we can move away
                $("#divLoading").hide();
                alert("Success")
               
                
            }
        }
       
        xhr.send(formdata);
        

    })
});