<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="ManageReview.aspx.cs" Inherits="RateMyPlace.Pages.ManageReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Review
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="stylesheet" runat="server">
    <link type="text/css" rel="stylesheet" href="Styles/ManageReviewStyle.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="manageReviewBody">
        <form class="form" runat="server"> <!-- Bootstrap Horizontal Form -->
            <asp:ScriptManager ID="requiredScript" runat="server"></asp:ScriptManager>
            <div class="form-group form-inline">
                <asp:Label AssociatedControlID="overallRating" class="col-form-label-md mr-3" runat="server">Overall Rating:</asp:Label>
                <ajaxToolkit:Rating class="" runat="server" id="overallRating" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
            </div>
            <div class="form-group form-inline">
                <asp:Label AssociatedControlID="noiseRating" class="col-form-label-md mr-3" runat="server">Noise Rating:</asp:Label>
                <ajaxToolkit:Rating class="" runat="server" id="noiseRating" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
            </div>
            <div class="form-group form-inline">
                <asp:Label AssociatedControlID="safetyRating" class="col-form-label-md mr-3" runat="server">Safety Rating:</asp:Label>
                <ajaxToolkit:Rating class="" runat="server" id="safetyRating" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
            </div>
            <div class="form-group form-inline">
                <asp:Label AssociatedControlID="maintenanceRating" class="col-form-label-md mr-3" runat="server">Maintenance Rating:</asp:Label>
                <ajaxToolkit:Rating class="" runat="server" id="maintenanceRating" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
            </div>

            <div class="form-group form-inline">
                <asp:Button runat="server" Text="Submit Review" id="btnSubmit" class="button" OnClick="btnSubmit_Click" />
            </div>
        </form>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
