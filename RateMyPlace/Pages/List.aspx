<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="RateMyPlace.Pages.List" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="stylesheet" runat="server">
    <link type="text/css" rel="stylesheet" href="Styles/ListStyle.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="listBody">
        <h1 id="heading"></h1>
        <form runat="server">
            <div class="errorContainer">
                <asp:Label runat="server" ID="lblError" CssClass="error" Visible="false"></asp:Label>
            </div>
            <asp:Repeater runat="server" ID="repeaterListComplexes" Visible="false" OnItemDataBound="repeaterListOverallRating_ItemDataBound" >
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th class="centered">Housing Complex</th>
                            <th class="centered">Average Rating</th>
                            <th class="centered">Average Rent</th>
                            <th class="centered">Average Utilities</th>
                            <th class="centered">Select for Comparison</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td ><%#Eval("HousingComplex")%></td>
                        <td class="centered"><asp:Label runat="server" ID="lblOverallRating"></asp:Label></td>
                        <td><%#Eval("AverageRent","${0:0.00}")%></td>
                        <td><%#Eval("AverageUtilities","${0:0.00}")%></td>
                        <td class="centered"><input type="checkbox" class="checkbox" name="Complexes" value='<%#Eval("HousingComplex")%>'></input></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                    <div class="form-group form-inline">
                        <asp:Button runat="server" Text="Compare Selected" id="btnSubmit" class="button" OnClick="btnSubmit_Click" />
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater runat="server" ID="repeaterListAll" Visible="false" OnItemDataBound="repeaterListOverallRating_ItemDataBound">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th class="centered">Housing Complex:</th>
                        <th>Author:</th>
                        <td><%# ((DBNull.Value == Eval("FK_Username")) || ("" == (String)Eval("FK_Username"))?"Anonymous":Eval("FK_Username")) %></td>
                        <th class="right">Rating:</th>
                        <td>
                            <asp:Label runat="server" ID="lblOverallRating"></asp:Label>
                        </td>
                        <th class="right">Parking:</th>
                        <td class="centered">
                            <asp:CheckBox runat="server" onclick="return false" checked='<%#(DBNull.Value == Eval("Parking")?false:Convert.ToBoolean(Eval("Parking")))%>'/>
                        </td>
                        <th class="right">Pets Allowed:</th>
                        <td class="centered">
                            <asp:CheckBox runat="server" onclick="return false" checked='<%#(DBNull.Value == Eval("Pets")?false:Convert.ToBoolean(Eval("Pets")))%>'/>
                        </td>
                        <th rowspan="2"><asp:Button runat="server" id="btnView" Text="View" UseSubmitBehavior="false" CommandArgument='<%#Eval("PK_ReviewID")%>'  OnCommand="btnView_Command" /></th>
                    </tr>
                    <tr>
                        <td ><%#Eval("HousingComplex")%></td>
                        <th class="right">Rent:</th>
                        <td><%#Eval("Rent","${0:0.00}")%></td>
                        <th class="right">Utilities:</th>
                        <td><%#Eval("Utilities","${0:0.00}")%></td>
                        <th class="right">Furnished:</th>
                        <td class="centered">
                            <asp:CheckBox runat="server" onclick="return false" checked='<%#(DBNull.Value == Eval("Furnished")?false:Convert.ToBoolean(Eval("Furnished")))%>'/>
                        </td>
                        <th class="right">Shuttle:</th>
                        <td class="centered">
                            <asp:CheckBox runat="server" onclick="return false" checked='<%#(DBNull.Value == Eval("Shuttle")?false:Convert.ToBoolean(Eval("Shuttle")))%>'/>
                        </td>
                    </tr>
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
