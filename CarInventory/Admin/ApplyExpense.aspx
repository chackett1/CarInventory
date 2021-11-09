<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplyExpense.aspx.cs" Inherits="CarInventory.Admin.ApplyExpense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Apply Expense</h3>
    <table>
        <tr>
            <td><asp:Label ID="LabelAddExpense" runat="server">Expense:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownAddExpenses" runat="server" 
                    ItemType="CarInventory.Models.Expenses" 
                    SelectMethod="GetExpenses" DataTextField="ExpenseName" 
                    DataValueField="ExpenseId" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddPrice" runat="server">Price:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Price required." ControlToValidate="AddProductPrice" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Must be a valid price without $." ControlToValidate="AddProductPrice" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelSelectProduct" runat="server">Product:</asp:Label></td>
            <td><asp:DropDownList ID="DropDownSelectProduct" runat="server" ItemType="CarInventory.Models.Product" 
                    SelectMethod="GetProducts" AppendDataBoundItems="true" 
                    DataTextField="ProductName" DataValueField="ProductID" >
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <p></p>
    <asp:Button ID="SubmitExpenseButton" runat="server" Text="Submit" OnClick="SubmitExpenseButton_Click" CausesValidation="true"/>
</asp:Content>
