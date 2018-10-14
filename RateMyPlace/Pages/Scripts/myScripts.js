$(function () {
    if($(window).width() < 992){
        $("ul.navbar-nav").addClass("navBackground");
        $("a#logout").css({"top": "0px"});
        $("i#userIcon").css({"top": "0px"});
    }
    else {
        $("ul.navbar-nav").removeClass("navBackground");
        $("a#logout").css({"top": "20px"});
        $("i#userIcon").css({"top": "20px"});
    }

    $("#compareReviewBody th.complexName button").click(function () {
        let color = $(this).css("background-color");
        $("#compareReviewBody .modal-header").css({"background-color": color});
        let tmpString = $(this)[0].innerText;
        let complex = tmpString.split("\n");
        $("#compareReviewBody h5.modal-title").text(complex[0]);
    });
   
});

$(window).resize(function(){
    if($(window).width() < 992){
        $("ul.navbar-nav").addClass("navBackground");
        $("a#logout").css({"top": "0px"});
        $("i#userIcon").css({"top": "0px"});
    }
    else {
        $("ul.navbar-nav").removeClass("navBackground");
        $("a#logout").css({"top": "20px"});
        $("i#userIcon").css({"top": "20px"});
    }
});