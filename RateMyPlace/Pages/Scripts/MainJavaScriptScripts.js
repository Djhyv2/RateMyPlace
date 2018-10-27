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

    $("img#homePageCarouselSubImage1").css({"transform": "scale(1.1)"});

    function goToSlide(number) {
        $("#carousel").carousel(number);
    }

    $("img#homePageCarouselSubImage1").click(function(){
        $("#homePageCarousel").carousel(0);
    });
    $("img#homePageCarouselSubImage2").click(function(){
        $("#homePageCarousel").carousel(1);
    });
    $("img#homePageCarouselSubImage3").click(function(){
        $("#homePageCarousel").carousel(2);
    });

    
    $('#homePageCarousel').bind('slide.bs.carousel', function (e) {
        setTimeout(function(){ 
            $( ".carousel-item" ).each(function( index ) {
                    if($(this).hasClass("active")){
                        if($(this).is("#item1")){
                            $("img#homePageCarouselSubImage1").css({"transform": "scale(1.1)"});
                        }
                        else if($(this).is("#item2")){
                            $("img#homePageCarouselSubImage2").css({"transform": "scale(1.1)"});
                        }
                        else if($(this).is("#item3")){
                            $("img#homePageCarouselSubImage3").css({"transform": "scale(1.1)"});
                        }
                        console.dir($(this));
                    }
                    else {
                        if($(this).is("#item1")){
                            $("img#homePageCarouselSubImage1").css({"transform": "scale(1.0)"});
                        }
                        else if($(this).is("#item2")){
                            $("img#homePageCarouselSubImage2").css({"transform": "scale(1.0)"});
                        }
                        else if($(this).is("#item3")){
                            $("img#homePageCarouselSubImage3").css({"transform": "scale(1.0)"});
                        }
                    }
            });
        }, 1000);
        
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