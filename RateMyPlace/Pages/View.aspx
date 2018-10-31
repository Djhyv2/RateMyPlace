<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="RateMyPlace.Pages.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <!-- Created by: Dustin Hengel -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="stylesheet" runat="server"> 
    <link type="text/css" rel="stylesheet" href="Styles/ManageReviewViewStyle.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
        <div id="viewBody">
        <form runat="server">
            <asp:ScriptManager ID="requiredScript" runat="server"></asp:ScriptManager>
            <asp:Label runat="server" ID="lblError" CssClass="error" Visible="false"></asp:Label>
            <asp:Repeater runat="server" id="repeaterView" OnDataBinding="repeaterView_DataBinding">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-6">
                            <asp:Label class="leftColLabel" runat="server" AssociatedControlID="lblAuthor">Author:</asp:Label>
                            <asp:Label runat="server" ID="lblAuthor"><%#(DBNull.Value == Eval("FK_Username")?"Anonymous":(Eval("FK_Username")))%></asp:Label><br />
                            <asp:Label class="leftColLabel" runat="server" AssociatedControlID="lblComplex">Complex:</asp:Label>
                            <asp:Label runat="server" ID="lblComplex"><%#Eval("HousingComplex") %></asp:Label><br />
                            <div class="">
                                <asp:Label AssociatedControlID="ratingOverall" class="rating" runat="server">Overall Rating:</asp:Label>
                                <ajaxToolkit:Rating class="ratingControl" readonly="true" runat="server" id="ratingOverall" CurrentRating='<%#Eval("OverallRating") %>' MaxRating="10" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                            </div>
                            <div class="">
                                <asp:Label AssociatedControlID="ratingNoise" class="rating" runat="server">Noise Amount:</asp:Label>
                                <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingNoise" readonly="true" CurrentRating='<%#Eval("Noise") %>' MaxRating="10" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                            </div>
                            <div class="">
                                <asp:Label AssociatedControlID="ratingSafety" class="rating" runat="server">Safety Rating:</asp:Label>
                                <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingSafety" readonly="true" CurrentRating='<%#Eval("Safety") %>' MaxRating="10" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                            </div>
                            <div class="">
                                <asp:Label AssociatedControlID="ratingMaintenance" class="rating" runat="server">Maintenance Quality:</asp:Label>
                                <ajaxToolkit:Rating class="ratingControl" runat="server" id="ratingMaintenance" readonly="true" CurrentRating='<%#Eval("Maintenance") %>' MaxRating="10" EmptyStarCssClass="emptyStar" FilledStarCssClass="fullStar" StarCssClass="fullstar" WaitingStarCssClass="fullstar"></ajaxToolkit:Rating>
                            </div>
                            <asp:Label class="leftColLabel" runat="server" AssociatedControlID="lblRent">Monthly Rent:</asp:Label>
                            <asp:Label runat="server" ID="lblRent"><%#Eval("Rent","${0:0.00}") %></asp:Label><br />
                            <asp:Label class="leftColLabel" runat="server" AssociatedControlID="lblUtilities">Monthly Utilities ($):</asp:Label>
                            <asp:Label runat="server" ID="lblUtilities"><%#Eval("Utilities","${0:0.00}") %></asp:Label><br />
                            <asp:Label class="leftColLabel" runat="server" AssociatedControlID="lblSqFoot">Square Footage:</asp:Label>
                            <asp:Label runat="server" ID="lblSqFoot"><%#DBNull.Value == Eval("SquareFootage")?"Unspecified":Eval("SquareFootage","{0} sq. ft.") %></asp:Label><br />
                            <asp:Label class="leftColLabel" runat="server" AssociatedControlID="lblDistance">Distance From Campus:</asp:Label>
                            <asp:Label runat="server" ID="lblDistance"><%#DBNull.Value == Eval("CampusDistance")?"Unspecified":Eval("CampusDistance","{0} mi") %></asp:Label><br />
                        </div>
                        <div class="col-6">
                            <asp:CheckBox class="checkbox" runat="server" Text="Study Space" ID="chkStudySpace" onclick="return false" checked='<%#(DBNull.Value == Eval("StudySpace")?false:Convert.ToBoolean(Eval("StudySpace")))%>'/><br />
                            <asp:CheckBox class="checkbox" runat="server" Text="Shuttle" ID="chkShuttle" onclick="return false" checked='<%#(DBNull.Value == Eval("Shuttle")?false:Convert.ToBoolean(Eval("Shuttle")))%>'/><br />
                            <asp:CheckBox class="checkbox" runat="server" Text="Wifi" ID="chkWiFi" onclick="return false" checked='<%#(DBNull.Value == Eval("Wifi")?false:Convert.ToBoolean(Eval("Wifi")))%>'/><br />
                            <asp:CheckBox class="checkbox" runat="server" Text="Furnished" ID="chkFurnished" onclick="return false" checked='<%#(DBNull.Value == Eval("Furnished")?false:Convert.ToBoolean(Eval("Furnished")))%>'/><br />
                            <asp:CheckBox class="checkbox" runat="server" Text="TV" ID="chkTV" onclick="return false" checked='<%#(DBNull.Value == Eval("TV")?false:Convert.ToBoolean(Eval("TV")))%>'/><br />
                            <asp:CheckBox class="checkbox" runat="server" Text="Trash Service" ID="chkTrashService" onclick="return false" checked='<%#(DBNull.Value == Eval("TrashService")?false:Convert.ToBoolean(Eval("TrashService")))%>'/><br />
                            <asp:CheckBox class="checkbox" runat="server" Text="Gym" ID="chkGym" onclick="return false" checked='<%#(DBNull.Value == Eval("Gym")?false:Convert.ToBoolean(Eval("Gym")))%>'/><br />
                            <asp:CheckBox class="checkbox" runat="server" Text="Parking" ID="chkParking" onclick="return false" checked='<%#(DBNull.Value == Eval("Parking")?false:Convert.ToBoolean(Eval("Parking")))%>'/>
                            <asp:Label class="fee" runat="server" AssociatedControlID="lblParkingFee">Parking Fee:</asp:Label>
                            <asp:Label runat="server" ID="lblParkingFee"><%#(DBNull.Value == Eval("ParkingFee")?"$0.00":(Eval("ParkingFee","${0:0.00}")))%></asp:Label><br />
                            <asp:CheckBox class="checkbox" runat="server" Text="Pets" ID="chkPets" onclick="return false" checked='<%#(DBNull.Value == Eval("Pets")?false:Convert.ToBoolean(Eval("Pets")))%>'/>
                            <asp:Label class="fee" runat="server" AssociatedControlID="lblPetsFee">Pets Fee:</asp:Label>
                            <asp:Label runat="server" ID="lblPetsFee"><%#(DBNull.Value == Eval("PetsFee")?"$0.00":(Eval("PetsFee","${0:0.00}")))%></asp:Label><br />
                            <asp:Label class="rightColAlign" runat="server" AssociatedControlID="lblMiscFees">Misc Fees:</asp:Label>
                            <asp:Label runat="server" ID="lblMiscFees"><%#(DBNull.Value == Eval("MiscFee")?"$0.00":(Eval("MiscFee","${0:0.00}")))%></asp:Label><br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <asp:Label class="" type="date" runat="server" AssociatedControlID="paraPros">Pros:</asp:Label><br />
                            <p class="viewParagraph" runat="server" id="paraPros"><%#Eval("Pros") %></p>
                            <asp:Label class="leftColLabel" runat="server" AssociatedControlID="lblLeaseStart">Lease Start Date:</asp:Label>
                            <asp:Label runat="server" ID="lblLeaseStart"><%#(DBNull.Value == Eval("LeaseStartDate")?"Unspecified":((DateTime)Eval("LeaseStartDate")).ToString("MM/dd/yyyy"))%></asp:Label>
                        </div>
                        <div class="col-6">
                            <asp:Label class="" type="date" runat="server" AssociatedControlID="paraCons">Cons:</asp:Label><br />
                            <p class="viewParagraph" runat="server" id="paraCons"><%#Eval("Cons") %></p>
                            <asp:Label class="rightColAlign" runat="server" AssociatedControlID="lblLeaseEnd">Lease End Date:</asp:Label>
                            <asp:Label runat="server" ID="lblLeaseEnd"><%#(DBNull.Value == Eval("LeaseEndDate")?"Unspecified":((DateTime)Eval("LeaseEndDate")).ToString("MM/dd/yyyy"))%></asp:Label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            
            
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
