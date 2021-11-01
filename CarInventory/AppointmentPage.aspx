<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppointmentPage.aspx.cs" Inherits="CarInventory.AppointmentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LabelSubmitStatus" Runat="server" Text=""></asp:Label>
    <body>
        <br />
        <br />
            <div>
                <asp:Label ID="NameText" runat="server" Text="Please enter your name:"></asp:Label>
                <asp:TextBox ID="Name" runat="server" asp-for="Name"/>
                <br />
                <br />
            </div>
            <div>
                <asp:Label ID="EmailText" runat="server" Text="Please enter your email:"></asp:Label>
                <asp:TextBox ID="Email" runat="server" asp-for="Email" />
                &nbsp;
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Email Required" ForeColor="Red" SetFocusOnError="True" ControlToValidate="Email">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Email" ErrorMessage="Not a Valid Email Address" ForeColor="Red" SetFocusOnError="True" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="CreateUserWizard1">
                </asp:RegularExpressionValidator>
                <br />
                <br />
            </div>
            <div>
                <asp:Label ID="VehicleText" runat="server" Text="Vehicle(s) interested in:"></asp:Label>
                <asp:TextBox ID="Vehicle" runat="server" asp-for="Vehicle" />
                <br />
                <br />
            </div>
            <div>
                <asp:Label ID="MessageText" runat="server" Text="Please enter your message:"></asp:Label>
                <asp:TextBox ID="Message" runat="server" TextMode="MultiLine" asp-for="Message" />
                <br />
                <br />
            </div>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit Form" OnClick=" SubmitButton_Click"/>
    </body>
</asp:Content>