// Write your JavaScript code.

$(document).ready(function(){
    $(".clickToHref").click(function(){
        $(location).attr("href", $(this).attr("href"));
    });
});