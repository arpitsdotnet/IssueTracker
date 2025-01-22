$(document).ready(function () {
    var modelHeight = $('.issue-model').height();
    var modelWidth = $('.issue-model').width();
    $('.imhri__expand').click(function () {
        $('.imhri__expand').hide();
        $('.imhri__compress').show();
        $('.issue-model')
            .width($(window).width())
            .height($(window).height());
    });
    $('.imhri__compress').click(function () {
        $('.imhri__expand').show();
        $('.imhri__compress').hide();
        $('.issue-model')
            .width(modelWidth)
            .height(modelHeight);
    });

    $('#options').on('click', 'li', function (e) {
        $('#dropdown').click();

        var element = $(this).html();
        //var svg = $('i', element).html();
        var svg = $('svg', element).parent().html();

        //console.log(svg);

        //var val = "<i class='" + i + "'></i> &nbsp;";

        //console.log(svg)
        //console.log(svg + $(this).data('innerHtml'))

        $('#options-display').html(svg);
    });
});



function hidePage() {
    document.getElementById("idLoader").style.display = "block";
}
function showPage() {
    document.getElementById("idLoader").style.display = "none";
    document.getElementById("content").style.display = "block";
}


function ViewContainerInPopup(filePath, title) {
    try {

        if (filePath == "")
            return;

        var $width = 600;
        if ($(window).width() < 600)
            $width = $(window).width() - ($(window).width() * 10 / 100);

        $("#divViewContainer").dialog({
            modal: true,
            title: title,
            width: $width,
            height: 650,
            closeOnEscape: true,
            open: function (event, ui) {
                $(".ui-dialog").addClass("ui-dialog-shadow");
            },
            close: function () {
                $("#ifrViewContainer").attr("src", "");
            }
        });

        $("#ifrViewContainer").attr("src", filePath);
    }
    catch (err) {
        ShowMessage(err);
    }
}

function goFullScreen(element) {

    var elem = document.getElementById(element);

    var imhri__expand = document.getElementsByClassName('imhri__expand')[0];
    var imhri__compress = document.getElementsByClassName('imhri__compress')[0];

    imhri__expand.style.display = "none";
    imhri__compress.style.display = "block";

    if (elem.requestFullscreen) {
        elem.requestFullscreen();
    }
    else if (elem.mozRequestFullScreen) {
        elem.mozRequestFullScreen();
    }
    else if (elem.webkitRequestFullscreen) {
        elem.webkitRequestFullscreen();
    }
    else if (elem.msRequestFullscreen) {
        elem.msRequestFullscreen();
    }
}
function exitFullScreen() {

    var imhri__expand = document.getElementsByClassName('imhri__expand')[0];
    var imhri__compress = document.getElementsByClassName('imhri__compress')[0];

    imhri__expand.style.display = "block";
    imhri__compress.style.display = "none";

    if (document.exitFullscreen) {
        document.exitFullscreen();
    }
    else if (document.mozCancelFullScreen) {
        document.mozCancelFullScreen();
    }
    else if (document.webkitExitFullscreen) {
        document.webkitExitFullscreen();
    }
    else if (document.msExitFullscreen) {
        document.msExitFullscreen();
    }

}