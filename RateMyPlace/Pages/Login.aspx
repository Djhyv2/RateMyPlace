﻿<%@ Page Language="C#" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Login</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="~/Pages/Styles/myStyle.css">
        
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    
        
        
   
    <script runat="server">
	
	</script>
    
</head>
<body>
    <nav class="navbar sticky-top" style="background-color: #2f3f74">
      <a class="navbar-brand" href="~/Pages/Login.aspx">Rate My Place</a>
    </nav>
        
       
        
    <div id="loginFormContainer" class="row">
        <div class="col-6 m-0 p-0">
            <h1 id="welcomeText">Welcome</h1>
            <figure >
                <img id="leftImage" src="https://understanding-home-insurance.com/wp-content/uploads/2016/12/cropped-Logo-No-Background.png" alt="">
            </figure>
            <div class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
              </ol>
              <div class="carousel-inner">
                <div class="carousel-item active">
                    <p>Where Is Your Best Fit?</p>
                </div>
                <div class="carousel-item">
                  <p>Find Your Next Home Today!</p>
                </div>
                <div class="carousel-item">
                    <p>Let's Go!</p>
                </div>
              </div>
            </div>
        </div>   
        <div class="col-6 m-0 p-0">
            <figure class="crop">
                <img id="rightImage" src="https://i.pinimg.com/236x/45/2c/f6/452cf6fa0c09c607617ea55e8c5a1362--adobe-lightroom-missouri.jpg" alt="">
            </figure>
            <form>
                
                <input type="text" name="username" placeholder="Username">
                
                <input type="password" name="password" placeholder="Password">
                
                <input type="submit" value="Login">
            </form>
        </div>
    </div>
        
</body>
</html>
