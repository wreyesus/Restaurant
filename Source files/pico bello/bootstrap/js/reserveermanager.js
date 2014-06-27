$(document).ready(function () {
    $("#besteldiv").hide("fast");
    $("#bestellen").change(function () {
        if ($(this).is(":checked")) {
            $("#besteldiv").show("slow");
        } else {
            $("#besteldiv").hide("slow");
        }
    });
});