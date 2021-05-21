


$(function () {
    $(document).ready(function () {
        
        $('.headerVideoLink').magnificPopup({
            type: 'inline',
            midClick: true // Allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source in href.
        });   
        $(document).on("change", ".filevideo", function (evt) {
            debugger
            var s = this.id;
            const files = this.files || [];

            if (!files.length) return;
           


        const reader = new FileReader();

            reader.onload = function (e) {
                //var count = $(".list-item");
               
         
                //for (var i = 0; i < count.length; i++) {
                //    var c = $($(".videoitem")[i]);
                   
                //    for (var j = 0; j < c.length; j++) {
                //        if ($(this) == $($(".filevideo")[i][j])) {
                //            const video = $($(".video")[i][j]);
                //            const videoSource = document.createElement('source');
                //            videoSource.setAttribute('src', e.target.result);

                //            video.append(videoSource);

                //            video.load();
                //            $('.video').show();
                //        }
                //    }

                //}
                if ($('video#' + s).children().length == 0) {
                    const videoSource = document.createElement('source');
                    videoSource.setAttribute('src', e.target.result);

                    $('video#' + s).append(videoSource);

                    $('video#' + s).load();
                    $('video#' + s).show();
                }
                else {
                    $('video#' + s).find('source').attr('src', e.target.result);
                    $('video#' + s).load();
                    $('video#' + s).show();
                }
            
           
        };


        reader.readAsDataURL(files[0]);
    });

        $(document).on("change", "#preview", function () {
            debugger
        const files = this.files || [];

        if (!files.length) return;

        const reader = new FileReader();

            reader.onload = function (e) {
                if ($('#videopreview').children().length == 0) {
                    const videoSource = document.createElement('source');
                    videoSource.setAttribute('src', e.target.result);
                    $('#videopreview').append(videoSource);

                    $('#videopreview').load();
                    $('#videopreview').show();
                }
                else {
                    $('#videopreview').find('source').attr('src', e.target.result);
                    $('#videopreview').load();
                    $('#videopreview').show();
                }
        };


        reader.readAsDataURL(files[0]);
    });
    });

}); 
