<%@ Page Language="C#" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
	<title>HomePage</title>
        
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="~/Pages/Styles/myStyle.css">
    <link href="https://fonts.googleapis.com/css?family=Kalam" rel="stylesheet"> 
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous">
        
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    
    <script src="/Pages/Scripts/myScripts.js"></script>
	<script runat="server">
	
	</script>
</head>
<body id="homeBody">
	<nav id="topbar" class="navbar fixed-top navbar-expand-lg">
      <a class="navbar-brand" href="#">RateMyPlace</a>
            
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav">
            <li class="nav-item">
                <a class="nav-link" href="#">Add Review</a>
            </li>
            <li class="nav-item">
            <a class="nav-link" href="#">View Review</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#">Compare Reviews</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#">Compare Housing</a>
            </li>
            <li class="nav-item">
                <a id="logout" class="nav-link" href="#">Logout</a>
            </li>
                  
            <li class="nav-item">
                <i id="userIcon" class="fas fa-user"></i>
            </li>     
        </ul>
      </div>
    </nav>
       
        
        <div id="homePageCarousel" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <figure class="crop">
                        <img class="d-block w-100" src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" alt="First slide">
                        <div class="overlay"></div>
                    </figure>
                    <div class="carousel-caption d-none d-md-block">
                        <h1>Brookside Apt</h1>
                        <p>This is a description</p>
                        <a href="#"><span class="badge badge-pill">Learn More!</span></a>
                    </div>
                </div>
                <div class="carousel-item">
                    <figure class="crop">
                        <img class="d-block w-100" src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" alt="First slide">
                        <div class="overlay"></div>
                    </figure>  
                    <div class="carousel-caption d-none d-md-block">
                        <h1>Brookside Apt</h1>
                        <p>This is a description</p>
                        <a href=""><span class="badge badge-pill">Learn More!</span></a>
                    </div>
                </div>
                <div class="carousel-item">
                    <figure class="crop">
                        <img class="d-block w-100" src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" alt="First slide">
                        <div class="overlay"></div>
                    </figure>
                    <div class="carousel-caption d-none d-md-block">
                        <h1>Brookside Apt</h1>
                        <p>This is a description</p>
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
            <img id="homePageCarouselSubImage2" src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" alt="">
            <img id="homePageCarouselSubImage3" src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" alt="">
           
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
                        <img src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>Brookside</p>
                    
                </div>
                <div class="col-4">
                    <div class="item">
                        <img src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>Brookside</p>
                    
                </div>
            </div> 
            
            <div id="row2" class="row">
                
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
                        <img src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>Brookside</p>
                    
                </div>
                <div class="col-4">
                    <div class="item">
                        <img src="https://image4.apartmentfinder.com/i2/lACuFrTj0gHzz6O3Puo3LaWcpyCjs7QgPeSjidBohDc/110/midtown-by-brookside-columbia-mo-building-photo.jpg" class="image" alt="">
                        <div class="overlay">
                            
                        </div>
                    </div>
                    <p>Brookside</p>
                    
                </div>
            </div>
        </div>
</body>
</html>
