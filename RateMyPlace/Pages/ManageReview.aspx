<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="ManageReview.aspx.cs" Inherits="RateMyPlace.Pages.ManageReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <!-- Created by: Dustin Hengel -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="stylesheet" runat="server">
    <link type="text/css" rel="stylesheet" href="Styles/ManageReviewViewStyle.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    
    <div id="manageReviewBody">
        <form runat="server" id="formReview">
            <asp:ScriptManager ID="requiredScript" runat="server"></asp:ScriptManager>
            <asp:Label runat="server" ID="lblError" CssClass="error" Visible="false"></asp:Label>
            <div class="row">
                <div class="col-6">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Label class="leftColLabel" runat="server" AssociatedControlID="ddlComplex">Complex:</asp:Label>
                            <asp:DropDownList class="textInput" runat="server" ID="ddlComplex" AutoPostBack="true" OnSelectedIndexChanged="ddlComplex_SelectedIndexChanged" ></asp:DropDownList><br />
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
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingOverall" CurrentRating='<%# true == edited.Table.Columns.Contains("OverallRating")?edited["OverallRating"]:0 %>' MaxRating="10" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="ratingNoise" class="rating" runat="server">Noise Amount:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingNoise" CurrentRating='<%# true == edited.Table.Columns.Contains("Noise") && DBNull.Value != edited["Noise"]?edited["Noise"]:0 %>' MaxRating="10" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="ratingSafety" class="rating" runat="server">Safety Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingSafety" CurrentRating='<%# true == edited.Table.Columns.Contains("Safety") && DBNull.Value != edited["Safety"]?edited["Safety"]:0 %>' MaxRating="10" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="ratingMaintenance" class="rating" runat="server">Maintenance Quality:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingMaintenance" CurrentRating='<%# true == edited.Table.Columns.Contains("Maintenance") && DBNull.Value != edited["Maintenance"]?edited["Maintenance"]:0 %>' MaxRating="10" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <div class="">
                        <asp:Label AssociatedControlID="ratingLocation" class="rating" runat="server">Location Rating:</asp:Label>
                        <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingLocation" CurrentRating='<%# true == edited.Table.Columns.Contains("Location") && DBNull.Value != edited["Location"]?edited["Location"]:0 %>' MaxRating="10" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                    </div>
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtRent">Monthly Rent ($):</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtRent" Text='<%# true == edited.Table.Columns.Contains("Rent") && DBNull.Value != edited["Rent"]?edited["Rent"]:"" %>'></asp:TextBox><br />
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtUtilities">Monthly Utilities ($):</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtUtilities" Text='<%# true == edited.Table.Columns.Contains("Utilities") && DBNull.Value != edited["Utilities"]?edited["Utilities"]:"" %>'></asp:TextBox><br />
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtSqFoot">Square Footage:</asp:Label>
                    <asp:TextBox Class="textInput" type="number" min="0" step=".01" runat="server" ID="txtSqFoot" Text='<%# true == edited.Table.Columns.Contains("SquareFootage") && DBNull.Value != edited["SquareFootage"]?edited["SquareFootage"]:"" %>'></asp:TextBox><br />
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtDistance">Distance From Campus (mi):</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtDistance" Text='<%# true == edited.Table.Columns.Contains("CampusDistance") && DBNull.Value != edited["CampusDistance"]?edited["CampusDistance"]:"" %>'></asp:TextBox><br />
                </div>
                <div class="col-6">
                    <asp:CheckBox class="checkbox" runat="server" Text="Study Space" ID="chkStudySpace" Checked='<%# true == edited.Table.Columns.Contains("StudySpace") && DBNull.Value != edited["StudySpace"]?Convert.ToBoolean(edited["StudySpace"]):false %>'/><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Shuttle" ID="chkShuttle" Checked='<%# true == edited.Table.Columns.Contains("Shuttle") && DBNull.Value != edited["Shuttle"]?Convert.ToBoolean(edited["Shuttle"]):false %>'/><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Wifi" ID="chkWiFi" Checked='<%# true == edited.Table.Columns.Contains("Wifi") && DBNull.Value != edited["Wifi"]?Convert.ToBoolean(edited["Wifi"]):false %>'/><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Furnished" ID="chkFurnished" Checked='<%# true == edited.Table.Columns.Contains("Furnished") && DBNull.Value != edited["Furnished"]?Convert.ToBoolean(edited["Furnished"]):false %>'/><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="TV" ID="chkTV" Checked='<%# true == edited.Table.Columns.Contains("TV") && DBNull.Value != edited["TV"]?Convert.ToBoolean(edited["TV"]):false %>'/><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Trash Service" ID="chkTrashService" Checked='<%# true == edited.Table.Columns.Contains("TrashService") && DBNull.Value != edited["TrashService"]?Convert.ToBoolean(edited["TrashService"]):false %>'/><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Gym" ID="chkGym" Checked='<%# true == edited.Table.Columns.Contains("Gym") && DBNull.Value != edited["Gym"]?Convert.ToBoolean(edited["Gym"]):false %>'/><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Parking" ID="chkParking" Checked='<%# true == edited.Table.Columns.Contains("Parking") && DBNull.Value != edited["Parking"]?Convert.ToBoolean(edited["Parking"]):false %>'/>
                    <asp:Label class="fee" runat="server" AssociatedControlID="txtParking">Parking Fee ($):</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtParking" Text='<%# true == edited.Table.Columns.Contains("ParkingFee") && DBNull.Value != edited["ParkingFee"]?edited["ParkingFee"]:"" %>'></asp:TextBox><br />
                    <asp:CheckBox class="checkbox" runat="server" Text="Pets" ID="chkPets" Checked='<%# true == edited.Table.Columns.Contains("Pets") && DBNull.Value != edited["Pets"]?Convert.ToBoolean(edited["Pets"]):false %>'/>
                    <asp:Label class="fee" runat="server" AssociatedControlID="txtPets">Pets Fee ($):</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtPets" Text='<%# true == edited.Table.Columns.Contains("PetsFee") && DBNull.Value != edited["PetsFee"]?edited["PetsFee"]:"" %>'></asp:TextBox><br />
                    <asp:Label class="rightColAlign" id="lblMiscFees" runat="server" AssociatedControlID="txtMiscFees">Misc Fees ($):</asp:Label>
                    <asp:TextBox class="textInput" type="number" min=0 step=".01" runat="server" ID="txtMiscFees" Text='<%# true == edited.Table.Columns.Contains("MiscFee") && DBNull.Value != edited["MiscFee"]?edited["MiscFee"]:"" %>'></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Label class="" type="date" runat="server" AssociatedControlID="txtPros">Pros:</asp:Label><br />
                    <asp:TextBox class="textArea" textMode="MultiLine" Rows="5" Columns="40" runat="server" ID="txtPros" Text='<%# true == edited.Table.Columns.Contains("Pros") && DBNull.Value != edited["Pros"]?edited["Pros"]:"" %>'></asp:TextBox><br />
                    <asp:Label class="leftColLabel" runat="server" AssociatedControlID="txtLeaseStart">Lease Start Date:</asp:Label>
                    <asp:TextBox class="textInput" type="date" runat="server" ID="txtLeaseStart" Text='<%# true == edited.Table.Columns.Contains("LeaseEndDate") && DBNull.Value != edited["LeaseEndDate"]?DateTime.Parse(edited["LeaseEndDate"].ToString()).Date.ToString("yyyy-MM-dd"):"" %>'></asp:TextBox><br />
                </div>
                <div class="col-6">
                    <asp:Label class="" type="date" runat="server" AssociatedControlID="txtCons">Cons:</asp:Label><br />
                    <asp:TextBox class="textArea" textMode="MultiLine" Rows="5" Columns="160" runat="server" ID="txtCons" Text='<%# true == edited.Table.Columns.Contains("Cons") && DBNull.Value != edited["Cons"]?edited["Cons"]:"" %>'></asp:TextBox><br />
                    <asp:Label class="rightColAlign" runat="server" AssociatedControlID="txtLeaseEnd">Lease End Date:</asp:Label>
                    <asp:TextBox class="textInput" runat="server" type="date" ID="txtLeaseEnd"  Text='<%# true == edited.Table.Columns.Contains("LeaseEndDate") && DBNull.Value != edited["LeaseEndDate"]?DateTime.Parse(edited["LeaseEndDate"].ToString()).Date.ToString("yyyy-MM-dd"):"" %>'></asp:TextBox><br />
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
