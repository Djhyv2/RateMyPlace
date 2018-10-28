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
            <asp:ListView runat="server" ID="listViewList" OnItemDataBound="listViewList_ItemDataBound">
                <ItemTemplate>
                    <asp:Table runat="server">
                        <asp:TableRow><asp:TableHeaderCell ColumnSpan="2"><%#Eval("HousingComplex")%></asp:TableHeaderCell><asp:TableCell><asp:Label runat="server" ID="lblOverallRating"></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell></asp:TableCell></asp:TableRow>
                    </asp:Table>
                    <br />
                </ItemTemplate>
            </asp:ListView>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
