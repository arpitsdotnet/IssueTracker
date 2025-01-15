

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