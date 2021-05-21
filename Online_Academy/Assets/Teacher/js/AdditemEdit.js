function newMenuItem() {

    var newElem = $('tr.list-item').first().clone();
    var count = $(".list-item").length + 1;

    var a = $(".videoitem").length + 1;


    newElem.find('input').val('');
    newElem.find('input.filevideo').removeAttr('id').attr('id', 'video' + a);
    newElem.find('source').remove();
    newElem.find('video').hide();
    var c = newElem.find('#list01');
    var e = c.children().length;
    if (e >= 2) {
        for (var i = 0; i < e - 1; i++) {
            c.children()[i].remove();
        }
    }
    // newElem.find('.videoitem').removeAttr('id').attr('id', 'videoitem' + a);
    newElem.find('video').removeAttr('id').attr('id', 'video' + a);
    newElem.find('.addvideo').removeAttr('id').attr('id', 'item,' + count + a);
    newElem.find('.listvideo').removeAttr('id').attr('id', 'list' + count + a);
    newElem.appendTo('table#item-add');

}
function newMenuVideo() {
    var newElem = $('.videoitem').first().clone();
    var count = $(".list-item").length;
    var c = $(".videoitem").length;
    newElem.find('input').val('');
    newElem.find('input.filevideo').attr('id', 'video' + c + 1);
    newElem.find('source').remove();
    newElem.find('video').hide();
    newElem.find('video').attr('id', 'video' + count + c + 1);
    newElem.appendTo('.listvideo');
}
$(document).on("click", ".addvideo", function (e) {
    debugger
    var s = this.id.split(',');
    e.preventDefault();
    var newElem = $('.videoitem').first().clone();
    var count = $(".list-item").length;
    var c = $(".videoitem").length + 1;
    newElem.find('input').val('');
    // newElem.removeAttr('id').attr('id', 'videoitem' + c);
    //newElem.find('.videoitem');
    newElem.find('input.filevideo').attr('id', 'video' + c);
    newElem.find('source').remove();
    newElem.find('video').hide();
    newElem.find('video').attr('id', 'video' + c);
    newElem.appendTo('#list' + s[1]);

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
            d.removeAttr('id').attr('id', 'video' + m);

            f.removeAttr('id').attr('id', 'video' + m);



        }
    });
}