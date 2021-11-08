﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="CarInventory.Admin.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>History Works</h1>
        <div id="AppointmentTitle" runat="server" class="ContentHead"><h1>Appointments</h1></div>
        <asp:GridView ID="AppointmentList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="CarInventory.Models.Purchase" SelectMethod="GetAllPurchases" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="PurchaseID" HeaderText="ID" SortExpression="AppointmentID" />        
        <asp:BoundField DataField="CarName" HeaderText="Car Name" />   
        <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" /> 
        </Columns>    
    </asp:GridView>
</asp:Content>
