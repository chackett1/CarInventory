<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppointmentDetails.aspx.cs" Inherits="CarInventory.Admin.AppointmentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="appointmentDetail" runat="server" ItemType="CarInventory.Models.Appointment" SelectMethod ="GetAppointment" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1>Appointment Details</h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Customer Name:</b><br /><%#:Item.CustomerName %>
                        <br />
                        <br />
                        <b>Contact Info:</b><br /><%#:Item.CustomerEmail %>
                        <br />
                        <br />
                        <b>Interested Vehicle(s):</b><br /><%#:Item.DesiredVehicle %>
                        <br />
                        <br />
                        <span><b>Customer Message:</b><br /><%#:Item.CustomerMessage%> </span>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>