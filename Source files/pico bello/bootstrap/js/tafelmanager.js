$(document).ready(function () {
    $(".ui-interface-identifier").css({ 'height': ($(window).height()) + 'px' });

    $(".knopjetafel").click(function () {
        $(".tafel").each(function () {
            alert("Tafel");
        });

        $(".tafel").on("dragstart", function (event, ui) {
            $(this).css("z-index", "2");
            $(this).css("background", "#C0C0C0");
        });

        $(".tafel").on("dragstop", function (event, ui) {
            $(this).css("z-index", "1");
            $(this).css("background", "#e7e7e7");
            $(this).css("padding", "1px");
        });

        $(".tafel .close").click(function (e) {
            $(this).parent().remove();
        });
    });
});