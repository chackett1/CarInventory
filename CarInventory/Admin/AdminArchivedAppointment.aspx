<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminArchivedAppointment.aspx.cs" Inherits="CarInventory.Admin.AdminArchivedAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ArchivedAppointmentTitle" runat="server" class="ContentHead"><h1>Archived Appointments</h1></div>
    <asp:GridView ID="ArchivedAppointmentList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
                  ItemType="CarInventory.Models.ArchivedAppointment" SelectMethod="GetAllArchivedAppointments"
                  CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="ArchivedAppointmentID" HeaderText="ID" SortExpression="ArchivedAppointmentID" />
            <asp:BoundField DataField="ArchivedCustomerName" HeaderText="Customer Name" />
            <asp:BoundField DataField="ArchivedCustomerEmail" HeaderText="Email" />
            <asp:BoundField DataField="ArchivedDesiredVehicle" HeaderText="Desired Vehicle(s)" />
            <asp:BoundField DataField="ArchivedCustomerMessage" HeaderText="Customer Message" />
        </Columns>
    </asp:GridView>
</asp:Content>