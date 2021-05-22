

$(function () {
    $(".btn-savedraft").click(function () {

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
        var lecture = {};
        
        lecture.chapname = chaptername;
        lecture.link = linkvideo;
        lecture.videoname = videoname;
       // lecture.fileimg = fileInput.files[0];
        //lecture.append("file", fileimg);
        //for (var p of lecture) {
        //    console.log(p);
        //}

        //var lectures = JSON.stringify(lecture);
        //var courses = JSON.stringify(course);
      
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
                alert("Success")
               
            }
        }
        //xhr.setRequestHeader('Content-type', 'multipart/form-data');
        //Appending file information in Http headers
        //xhr.setRequestHeader('X-File-Name', fileInput.files[0].name);
      
        //Sending file in XMLHttpRequest
        xhr.send(formdata);
       // var request = new XMLHttpRequest();
       // request.setRequestHeader('X-File-Name', fileImg[0].name);
       // request.open("POST", "/Teacher/TeacherCourses/Create");
       // request.send(lecture);
        //$.ajax({
        //    type: "POST",
        //    url: "/TeacherCourses/Upload",
        //    // data: '{course: ' + JSON.stringify(course) + ','+'lecture: ' + JSON.stringify(lecture) +'}',
        //    //dataType: "JSON",
        //    data: { lecture },
        //    //contentType: "application/json; charset=utf-8",
        //    cache: false,
        //    processData: false,
        //    contentType: false,
        //    success: function (data) {
        //        alert("Success");
        //    },
        //    error: function () {
        //        alert("Error");
        //    }
        //}); 
    })
    $(".btn-post").click(function () {

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
        var lecture = {};

        lecture.chapname = chaptername;
        lecture.link = linkvideo;
        lecture.videoname = videoname;
        // lecture.fileimg = fileInput.files[0];
        //lecture.append("file", fileimg);
        //for (var p of lecture) {
        //    console.log(p);
        //}

        //var lectures = JSON.stringify(lecture);
        //var courses = JSON.stringify(course);

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
                alert("Success")
                
            }
        }
       
        xhr.send(formdata);
        

    })
});