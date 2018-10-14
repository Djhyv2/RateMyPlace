<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectComplexComparison.aspx.cs" Inherits="RateMyPlace.Pages.SelectComplexComparison" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Review</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
    <link rel="stylesheet" type="text/css" href="~/Pages/Styles/myStyle.css"/>
    <link rel="stylesheet" type="text/css" href="~/Pages/Styles/ReviewStyle.css"/>
    <link href="https://fonts.googleapis.com/css?family=Kalam" rel="stylesheet"/> 
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous"/>
      
 <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    
    <script src="/Pages/Scripts/myScripts.js"></script>
    <script src="/Pages/Scripts/AdditionalReviewInfo.js"></script>
	<script runat="server">
	
	</script>
</head>
<body>
    <nav id="topbar" class="navbar fixed-top navbar-expand-lg">
      <a class="navbar-brand" href="HomePage.aspx">RateMyPlace</a>
            
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNavDropdown">
        <ul class="navbar-nav">
            <li class="nav-item">
                <a class="nav-link" href="#">Add Review</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="ViewReview.aspx">View Review</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="CompareReview.aspx">Compare Reviews</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="SelectComplexComparison.aspx">Compare Housing</a>
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
        <div class="TableDiv">
            <asp:Literal id="HTMLInsert" runat="server" Text=""></asp:Literal>
        </div>
    </form>
</body>
</html>
