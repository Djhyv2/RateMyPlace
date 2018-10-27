<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="ManageReview.aspx.cs" Inherits="RateMyPlace.Pages.ManageReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Review
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="stylesheet" runat="server">
    <link type="text/css" rel="stylesheet" href="Styles/ManageReviewStyle.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="manageReviewBody">
        <form runat="server">
            <asp:ScriptManager ID="requiredScript" runat="server"></asp:ScriptManager>
            <asp:Label runat="server" ID="lblError" CssClass="error" Visible="true"></asp:Label>
            <div class="row">
                <div class="col-6">
                    <div class="">
                        <asp:Label AssociatedControlID="overallRating" class="rating" runat="server">Overall Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="overallRating" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="noiseRating" class="rating" runat="server">Noise Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="noiseRating" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="safetyRating" class="rating" runat="server">Safety Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="safetyRating" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="maintenanceRating" class="rating" runat="server">Maintenance Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="maintenanceRating" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                </div>
                <div class="col-6">
                    <asp:CheckBox runat="server" Text=""/>
                </div>
            </div>
            <div class="form-group form-inline">
                <asp:Button runat="server" Text="Submit Review" id="btnSubmit" class="button" OnClick="btnSubmit_Click" />
            </div>
        </form>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
