// Write your JavaScript code.

$(".clickToHref").click(function(){
    $(location).attr("href", $(this).attr("href"));
});x