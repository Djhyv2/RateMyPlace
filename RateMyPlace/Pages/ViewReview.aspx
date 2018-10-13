<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReview.aspx.cs" Inherits="RateMyPlace.Pages.SearchResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Review</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
    <link rel="stylesheet" type="text/css" href="~/Pages/Styles/myStyle.css"/>
    <link href="https://fonts.googleapis.com/css?family=Kalam" rel="stylesheet"/> 
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous"/>
      
</head>
<body>
    <nav id="topbar" class="navbar fixed-top navbar-expand-lg">
      <a class="navbar-brand" href="#">RateMyPlace</a>
            
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNavDropdown">
        <ul class="navbar-nav">
            <li class="nav-item">
                <a class="nav-link" href="HomePage.aspx">Home</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#">Add Review</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="CompareReview.aspx">Compare Reviews</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="CompareHousing.aspx">Compare Housing</a>
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
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
