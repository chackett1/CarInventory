<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="CarInventory.Appointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <label asp-for="Name">Please enter your name:</label>
        <input type="text" asp-for="Name" />
    </div>
    <div>
        <label asp-for="Email">Please enter your email:</label>
        <input type="text" asp-for="Email" />
    </div>
     <div>
        <label asp-for="Vehicle">Please enter vehicle:</label>
        <textarea asp-for="Vehicle"></textarea>
    </div>
    <div>
        <label asp-for="Message">Please enter your message:</label>
        <textarea asp-for="Message"></textarea>
    </div>
    <input type="submit" value="Submit Form" />
</asp:Content>