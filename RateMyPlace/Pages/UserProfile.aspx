<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="RateMyPlace.Pages.UserProfileResults" MasterPageFile="~/Pages/Layout.master" Title="Content Page"  %>

<asp:Content id="Content1" ContentPlaceHolderID="title" runat="server">
   Compare Housing
</asp:Content>

<asp:Content id="Content2" ContentPlaceHolderID="contentBody" runat="server">
   
    <div id="userProfileBody">
        <div id="contentContainer">
            <table id="headerTable">
                <tr>
                    <th>Complex</th>
                    <th>Overall Rating</th>
                    <th>Rent</th>
                    <th>Pets</th>
                    <th>Furnished</th>
                    <th>Parking</th>
                    <th>Study Space</th>
                    <th>Shuttle</th>
                    <th>Gym</th>
                    <th>Details</th>
                </tr>
            </table>
            <div id="innerTable">
                <table>
                    
                    
                    <asp:Literal id="userProfileText" runat="server" Text=""></asp:Literal>

                </table>
            </div>
        </div>
    </div>
    
</asp:Content>
