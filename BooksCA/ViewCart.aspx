<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ViewCart.aspx.cs" Inherits="BooksCA.ViewCart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="cartdiv" runat="server">
        <p id="cartstatus" runat="server"></p>
    </div>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
    <asp:Button ID="btncheckout" CssClass="btn btn-primary" runat="server" Text="Check Out" OnClick="btncheckout_Click" />
</asp:Content>

