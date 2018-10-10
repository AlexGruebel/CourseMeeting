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

    $(".UpdateCourse").unbind("click").click(function(){
        console.log("UpdateCourse...");
        let CID = $(this).attr("cid");
        let cCID = "#" + CID
        let cName = $(cCID + "Name").val().trim();

        $.ajax({
            dataType: "text",
            url: "/Course/UpdateCourse",
            type: "PUT",
            data: {
                CID: CID,
                CName: cName,
                CDescription: $(cCID + "Description").val().trim()
                },
            
            success: function(){
                $("#" + CID + "AName").text(cName);
            },
        });
    });

});