<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="CarInventory.Admin.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView ID="reportDetails" runat="server" ItemType="CarInventory.Models.ReportDetails" SelectMethod ="GetAllReports" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1>Reports Works</h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Total gained from selling cars: </b>$<%#:Item.totalSales %>
                        <br />
                        <br />
                        <b>Total spent on cars in inventory: </b>$<%#:Item.totalPurchase %>
                        <br />
                        <br />
                        <b>Total expenses on cars in inventory: </b>$<%#:Item.totalExpenses %>
                        <br />
                        <br />
                        <br />
                        <span><b>Total profit from selling cars: </b>$<%#:Item.totalProfit%></span>
                        <br />
                        <span>(Profits = total gained - total spent - total expenses)</span>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
