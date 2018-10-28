<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="RateMyPlace.Pages.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="stylesheet" runat="server">
    <link type="text/css" rel="stylesheet" href="Styles/ListStyle.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="listBody">
        <h1 id="heading"></h1>
        <form runat="server">
            <asp:Repeater runat="server" ID="repeaterList" OnItemDataBound="repeaterList_ItemDataBound">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr><td RowSpan="2"><%#Eval("HousingComplex")%></td><td><asp:Label runat="server" ID="lblOverallRating">Rating: </asp:Label></td></tr>
                    <tr><td><%#Eval("Rent","Rent: ${0:0.00}")%></td></tr>
                    <tr class="bottomRow"></tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
