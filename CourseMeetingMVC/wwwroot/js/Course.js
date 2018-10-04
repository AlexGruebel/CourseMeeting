//Course

//ToDo put Course.js in separeted Views
$(document).ready(function(){
    function unsubsribeByMID(MID ){
        $.post("/Course/Unsubscribe/", {id: MID});
    }

    $(".UnsubsribeAndRemoveRowByMID").click(function(){
        let mid = $(this).attr("MID"); 
        unsubsribeByMID(mid);
        $("#" + mid).remove();
    });

    $(".Unsubsribe").click(function(){
        let mid = $(this).attr("MID");
        unsubsribeByMID(mid);
    });

    $(".ShowCID").unbind("click").click(function(evt){
        let CID = ("#" + $(this).attr("CID"));
        if($(this).attr("value") === "+"){
            $(CID).removeClass(" Collapse ").addClass("Show");
            $(this).attr("value",  "-");
        }else{
            $(CID).removeClass("Show").addClass("Collapse");
            $(this).attr("value", "+");
        }
    });

    function createCourse(){
        $.post("/Course/CreateCourse/", {test: "HEY"});
    }
});