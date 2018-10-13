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