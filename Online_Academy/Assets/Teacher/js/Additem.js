function newMenuItem() {
    if ($(".list-item").length > 0) {
        var newElem = $('tr.list-item').first().clone();
        var count = $(".list-item").length + 1;

        var a = $(".videoitem").length + 1;


        newElem.find('input').val('');
        newElem.find('input.filevideo').removeAttr('id').attr('id', 'video' + a);
        newElem.find('source').remove();
        newElem.find('.idcurri').remove();
        newElem.find('.idlec').remove();
        newElem.find('.delchap').remove();
        newElem.find('.closechap').show();
        newElem.find('video').hide();
        var c = newElem.find('#list01');
        var e = c.children().length;
        if (e >= 2) {
            for (var i = 0; i < e - 1; i++) {
                c.children()[i].remove();

            }
        }
        newElem.find('.dellec').remove();
        newElem.find('.closelec').show();
        // newElem.find('.videoitem').removeAttr('id').attr('id', 'videoitem' + a);
        newElem.find('video').removeAttr('id').attr('id', 'video' + a);
        newElem.find('.addvideo').removeAttr('id').attr('id', 'item,' + count + a);
       newElem.find('.videoitem').remove();
        newElem.find('.listvideo').removeAttr('id').attr('id', 'list' + count + a);
        newElem.appendTo('table#item-add');
    }
    else {
        $("<tr class='list-item'>" +
            " <td>" +
            "<div class='row'>" +
            "<div class='col-md-12'>" +
            "<label class='col-form-label'>Chapter Name</label>" +
            "<div>" +
            "<input class='form-control chapter' type='text' >" +
            "</div>" +
            "</div>" +
            "<div class='col-md-12'>" +
            "<label class='col-form-label'>Add Video</label>" +
            "<div class='form-group'>" +
            "<a class='btn-secondry addvideo' id='item,01' href='#' ><i class='fa fa-plus'></i></a>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "<div class='row listvideo' id='list01'>" +
            "</div>" +
            '<div class="col-md-4">'+
                '<label class="col-form-label">Close Chapter</label>'+
                '<div class="form-group">'+
                   '<a class="delete delchapter" href="#"><i class="fa fa-close"></i></a>'+
                '</div>'+


            '</div>'+
            "</td>" +
            "</tr>").appendTo('table#item-add');
              
        
    }
    
}

$(document).on("click", ".addvideo", function (e) {
    debugger
    var s = this.id.split(',');
    e.preventDefault();
    if ($(".videoitem").length > 0) {
        var newElem = $('.videoitem').first().clone();
        var count = $(".list-item").length;
        var c = $(".videoitem").length + 1;
        newElem.find('input').val('');
        // newElem.removeAttr('id').attr('id', 'videoitem' + c);
        //newElem.find('.videoitem');
        newElem.find('input.filevideo').attr('id', 'video' + c);
        newElem.find('.idlec').remove();
        newElem.find('.dellec').remove();
        newElem.find('.closelec').show();
        newElem.find('source').remove();
        newElem.find('video').hide();
        newElem.find('video').attr('id', 'video' + c);
        newElem.appendTo('#list' + s[1]);
    }
    else {
        $('<div class="row col-12 videoitem" >' +
            '<div class="col-md-1">' +

            '</div>' +
            '<div class="col-md-1">' +
            '<label class="col-form-label"></label>' +
            ' <div class="form-group">' +
            '<a class="delete delvideo" href="#"><i class="fa fa-close"></i></a>' +
            '</div>' +
            '</div>' +

            '<div class="col-md-4">' +
            '<label class="col-form-label">Name Video</label>' +
            ' <div>' +
            '<input class="form-control name" type="text" name="name" >' +
            '</div>' +

            '</div>' +
            '<div class="col-md-2">' +
            '<label class="col-form-label">Video</label>' +
            '<div>' +
            '<input type="file" name="filevideo" class="filevideo" id="video1" accept="video/*" />' +
            '</div>' +

            '</div>' +
            '<div class="col-md-4" id="contain">' +

            '<video width="300" height="300" controls class="video" id="video1" style="display:none">' +
            '</video>' +

            '</div>' +
            '</div>').appendTo('#list' + s[1]);
    }
});

if ($("table#item-add").is('*')) {
    $('.add-item').on('click', function (e) {
      debugger
        e.preventDefault();
        newMenuItem();
    });
    
    $(document).on("click", "#item-add .delchapter", function (e) {
        e.preventDefault();
        $(this).parent().parent().parent().parent().remove();
    });
    $(document).on("click", "#item-add .delvideo", function (e) {
        debugger
        e.preventDefault();
        $(this).parent().parent().parent().remove();
       
        var c = $(".videoitem").length;
        
        for (var i = 0; i < c; i++) {
           

           
                var m = i + 1;
                
               var b = $($(".videoitem")[i]);
                var d = $($(".filevideo")[i]);
            var f = $($(".video")[i]);
           // b.removeAttr('id').attr('id', 'videoitem' + m);
                d.removeAttr('id').attr('id', 'video'  + m);
               
                f.removeAttr('id').attr('id', 'video'  + m);
         
            
          
        }
    });
}