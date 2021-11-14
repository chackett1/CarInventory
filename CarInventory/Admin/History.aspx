<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="CarInventory.Admin.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>History Of Sales, Expenses, and Purchases</h1>
        <div id="Div1" runat="server" class="ContentHead"><h1>Cars Sold</h1></div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
            ItemType="CarInventory.Models.Sale" SelectMethod="GetAllSales" 
            CssClass="table table-striped table-bordered" >   
            <Columns>
            <asp:BoundField DataField="PurchaseID" HeaderText="ID" SortExpression="AppointmentID" />        
            <asp:BoundField DataField="CarName" HeaderText="Car Name" />   
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" /> 
            </Columns>    
        </asp:GridView>
        <div id="AppointmentTitle" runat="server" class="ContentHead"><h1>Cars Purchased</h1></div>
        <asp:GridView ID="AppointmentList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
            ItemType="CarInventory.Models.Purchase" SelectMethod="GetAllPurchases" 
            CssClass="table table-striped table-bordered" >   
            <Columns>
            <asp:BoundField DataField="PurchaseID" HeaderText="ID" SortExpression="AppointmentID" />        
            <asp:BoundField DataField="CarName" HeaderText="Car Name" />   
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" /> 
            </Columns>    
        </asp:GridView>
     <div id="ExpensesTitle" runat="server" class="ContentHead"><h1>Expenses</h1></div>
        <asp:GridView ID="ExpenseList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
            ItemType="CarInventory.Models.CarExpense" SelectMethod="GetAllExpenses" 
            CssClass="table table-striped table-bordered" >   
            <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="Car Name" SortExpression="ProductName" />        
            <asp:BoundField DataField="ExpenseName" HeaderText="Expense" />   
            <asp:BoundField DataField="Price" HeaderText="Price" /> 
            </Columns>    
        </asp:GridView>
</asp:Content>
