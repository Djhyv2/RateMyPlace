<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="ManageReview.aspx.cs" Inherits="RateMyPlace.Pages.ManageReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <!-- Created by: Dustin Hengel -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="stylesheet" runat="server">
    <link type="text/css" rel="stylesheet" href="Styles/ManageReviewStyle.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    
    <div id="manageReviewBody">
        <form runat="server">
            <asp:ScriptManager ID="requiredScript" runat="server"></asp:ScriptManager>
            <asp:Label runat="server" ID="lblError" CssClass="error" Visible="false"></asp:Label>
            <div class="row">
                <div class="col-6">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Label class="leftColLabel" runat="server" AssociatedControlID="ddlComplex">Complex:</asp:Label>
                            <asp:DropDownList class="textInput" runat="server" ID="ddlComplex" AutoPostBack="true" OnSelectedIndexChanged="ddlComplex_SelectedIndexChanged"></asp:DropDownList><br />
                            <div id="divComplex" runat="server" visible="false">
                                <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtComplex">New Complex:</asp:Label>
                                <asp:TextBox class="textInput" runat="server" ID="txtComplex"></asp:TextBox><br />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlComplex" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="">
                        <asp:Label AssociatedControlID="ratingOverall" class="rating" runat="server">Overall Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingOverall" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="ratingNoise" class="rating" runat="server">Noise Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingNoise" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="ratingSafety" class="rating" runat="server">Safety Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingSafety" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="ratingMaintenance" class="rating" runat="server">Maintenance Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingMaintenance" CurrentRating="0" MaxRating="5" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtRent">Monthly Rent:</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtRent"></asp:TextBox><br />
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtUtilities">Monthly Utilities:</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtUtilities"></asp:TextBox><br />
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtDistance">Distance From Campus (Mi):</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtDistance"></asp:TextBox><br />
                </div>
                <div class="col-6">
                    <asp:CheckBox class="checkbox" runat="server" Text="Study Space" ID="chkStudySpace"/><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Shuttle" ID="chkShuttle" /><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Wifi" ID="chkWiFi" /><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Furnished" ID="chkFurnished" /><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="TV" ID="chkTV" /><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Trash Service" ID="chkTrashService" /><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Gym" ID="chkGym" /><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Parking" ID="chkParking" />
                    <asp:Label class="fee" runat="server" AssociatedControlID="txtParking">Parking Fee:</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtParking"></asp:TextBox><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Pets" ID="chkPets" />
                    <asp:Label class="fee" runat="server" AssociatedControlID="txtPets">Pets Fee:</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtPets"></asp:TextBox><br />
                    <asp:Label class="miscFees" id="lblMiscFees" runat="server" AssociatedControlID="txtMiscFees">Misc Fees:</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtMiscFees"></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Label class="" type="date" runat="server" AssociatedControlID="txtPros">Pros:</asp:Label><br />
                    <asp:TextBox class="textArea" textMode="MultiLine" Rows="5" Columns="40" runat="server" ID="txtPros"></asp:TextBox><br />
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtLeaseStart">Lease Start Date:</asp:Label>
                    <asp:TextBox class="textInput" type="date" runat="server" ID="txtLeaseStart"></asp:TextBox><br />
                </div>
                <div class="col-6">
                    <asp:Label class="" type="date" runat="server" AssociatedControlID="txtPros">Cons:</asp:Label><br />
                    <asp:TextBox class="textArea" textMode="MultiLine" Rows="5" Columns="160" runat="server" ID="txtCons"></asp:TextBox><br />
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtLeaseEnd">Lease End Date:</asp:Label>
                    <asp:TextBox class="textInput" runat="server" type="date" ID="txtLeaseEnd"></asp:TextBox><br />
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
