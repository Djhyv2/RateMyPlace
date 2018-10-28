<%@ Page Language="C#" MasterPageFile="~/Pages/Layout.master" Title="Content Page" CodeBehind="Login.aspx.cs" Inherits="RateMyPlace.Pages.Login"%>
<asp:Content id="Content1" ContentPlaceHolderID="title" runat="server">
   Login
</asp:Content>

<asp:Content id="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <!-- Created by: Dustin Hengel -->

    <div id="loginBody">
        <hr>
        <div id="loginFormContainer" class="row">
            <div class="col-6 m-0 p-0">
                <h1 id="welcomeText">Welcome</h1>
                <div class="carousel slide" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img id="leftImage" src="https://understanding-home-insurance.com/wp-content/uploads/2016/12/cropped-Logo-No-Background.png" alt="">
                            <p>Where Is Your Best Fit?</p>
                        </div>
                        <div class="carousel-item">
                            <img id="leftImage" src="https://openclipart.org/image/2400px/svg_to_png/296598/StackOfBooks2.png">
                            <p>Find Your Next Home Today!</p>
                        </div>
                        <div class="carousel-item">
                            <img id="leftImage" src="https://openclipart.org/download/244447/Originuum---Chapeu-de-Formatura---1.0.0.svg">    
                            <p>Get Started Today!</p>    
                        </div>
                    </div>
                </div>
            </div>
         
            <div class="col-6 m-0 p-0">
                <figure class="crop">
                    <img id="rightImage" src="https://i.pinimg.com/236x/45/2c/f6/452cf6fa0c09c607617ea55e8c5a1362--adobe-lightroom-missouri.jpg" alt="">
                </figure>
                <form runat="server" defaultbutton="btnLogin">
                
                    <asp:TextBox runat="server" id="txtUsername" placeholder="Username"></asp:TextBox>
                    
                    <asp:TextBox runat="server" id="txtPassword" TextMode="password" placeholder="Password"></asp:TextBox>

                    <asp:TextBox runat="server" id="txtPasswordRepeat" TextMode="password" placeholder="Repeat Password" Visible="false"></asp:TextBox>

                    <asp:Label runat="server" ID="lblError" CssClass="error" Visible="false"></asp:Label>

                    <div class="row">
                        <div class="col-6">
                            <asp:button runat="server" id="btnRegister" text="Register"  OnClick="handleRegister_click"/>
                        </div>
                        <div class="col-6">
                            <asp:button runat="server" id="btnLogin" Text="Login" OnClick="handleLogin_click" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>