<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminAppointment.aspx.cs" Inherits="CarInventory.Admin.AdminAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="AppointmentTitle" runat="server" class="ContentHead"><h1>Appointments</h1></div>
        <asp:GridView ID="AppointmentList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="CarInventory.Models.Appointment" SelectMethod="GetAllAppointments" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="AppointmentID" HeaderText="ID" SortExpression="AppointmentID" />        
        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />   
        <asp:BoundField DataField="CustomerEmail" HeaderText="Email" /> 
        <asp:BoundField DataField="DesiredVehicle" HeaderText="Desired Vehicle(s)" />  
        <asp:BoundField DataField="CustomerMessage" HeaderText="Message)" />   
        </Columns>    
    </asp:GridView>
    <br />
    <table> 
    </table>
</asp:Content>
