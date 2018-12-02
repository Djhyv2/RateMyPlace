<%@ Page Language="C#" MasterPageFile="~/Pages/Layout.master" Title="Content Page" CodeBehind="Homepage.aspx.cs" Inherits="RateMyPlace.Pages.HomePage"%>

<asp:Content id="Content1" ContentPlaceHolderID="title" runat="server">
   <title>Home Page</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="javascript" runat="server">
    <script src="/Pages/Scripts/Homepage.js"></script>
</asp:Content>

<asp:Content id="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <form runat="server"></form>
    <div id="homeBody">    
        
        <div id="homePageCarousel" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div id="item1" class="carousel-item active">
                    <figure class="crop">
                        <img class="d-block w-100" src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" alt="First slide">
                        <div class="overlay"></div>
                    </figure>
                    <div class="carousel-caption d-none d-md-block">
                        <h1>Brookside Apt</h1>
                        <p>Brookside Apartments have three different locations throughout Columbia, including downtown, midtown, and townhouses</p>
                        <a href="#"><span class="badge badge-pill">Learn More!</span></a>
                    </div>
                </div>
                <div id="item2" class="carousel-item">
                    <figure class="crop">
                        <img class="d-block w-100" src="https://www.opus-group.com/Media/ProjectImages/District-Flats-Student-Housing_3235_1000x667.jpg" alt="First slide">
                        <div class="overlay"></div>
                    </figure>  
                    <div class="carousel-caption d-none d-md-block">
                        <h1>District Flats Apt</h1>
                        <p>The District Flats are located on Stadium, a short drive to the University of Missouri campus</p>
                        <a href=""><span class="badge badge-pill">Learn More!</span></a>
                    </div>
                </div>
                <div id="item3" class="carousel-item">
                    <figure class="crop">
                        <img class="d-block w-100" src="https://www.americancampus.com/assets/653-ucentreonturner/gallery/galleryslider/02-Hot-Tub.jpg" alt="First slide">
                        <div class="overlay"></div>
                    </figure>
                    <div class="carousel-caption d-none d-md-block">
                        <h1>UCentre On Turner Apt</h1>
                        <p>UCentre on Turner Apartments are located conveniently right by campus</p>
                        <a href=""><span class="badge badge-pill">Learn More!</span></a>
                    </div>
                </div>
            </div>
            <a class="carousel-control-prev" href="#homePageCarousel" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#homePageCarousel" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
            <img id="homePageCarouselSubImage1" src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" alt="">
            <img id="homePageCarouselSubImage2" src="https://www.opus-group.com/Media/ProjectImages/District-Flats-Student-Housing_3235_1000x667.jpg" alt="">
            <img id="homePageCarouselSubImage3" src="https://www.americancampus.com/assets/653-ucentreonturner/gallery/galleryslider/02-Hot-Tub.jpg" alt="">
           
        </div>
        
        <div id="homePageBox">

            <div class="row">
                
                <div class="col-4">
                    <div class="item">
                        <img src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>Brookside</p>
                    
                </div>
                <div class="col-4">
                    <div class="item">
                        <img src="https://images1.forrent.com/i2/Z4KVZzdDObT72uJCx1GnOBnV5c06CiLl9vB7nfBp3bo/110/image.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>The Lyfe at Missouri</p>
                    
                </div>
                <div class="col-4">
                    <div class="item">
                        <img src="https://s3.amazonaws.com/cdn.ucribs.com/images/listings/110972/1438873279-The%20Reserve%20at%20Columbia%201.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>The Reserve</p>
                    
                </div>
            </div> 
            
            <div id="row2" class="row">
                
                <div class="col-4">
                    <div class="item">
                        <img src="http://themaneater.com/media/2015/0506/photos/Domain030.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>The Domain</p>
                    
                </div>
                <div class="col-4">
                    <div class="item">
                        <img src="https://mizzoumag.missouri.edu/wp-content/uploads/2012/10/20120904_sigma-sigma-sigma003.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>Sorority Housing</p>
                    
                </div>
                <div class="col-4">
                    <div class="item">
                        <img src="http://themaneater.com/media/2016/0410/longread/galena.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>Galena</p>
                    
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>