<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="Compare.aspx.cs" Inherits="RateMyPlace.Pages.Compare" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <!-- Created by: Dustin Hengel -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="stylesheet" runat="server">
    <link type="text/css" rel="stylesheet" href="Styles/CompareStyle.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="CompareBody">
        <asp:DataList id="dataListComplex" RepeatDirection="Horizontal" RepeatLayout="Table" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Housing Complex</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
