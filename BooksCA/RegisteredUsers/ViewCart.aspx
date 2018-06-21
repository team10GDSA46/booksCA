<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/RegisteredUsers/RegUsers.Master" CodeBehind="ViewCart.aspx.cs" Inherits="BooksCA.ViewCart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="cartdiv" runat="server">
        <br />
        <p id="cartstatus" runat="server" style="text-align: center;
             font-size: 150%; font-weight: 700; font-style: italic"></p>
    </div>
    <br />
    <asp:Label ID="DiscountLabel" runat="server"
        style="position:relative; float:right;
            font-size: 180%; font-weight: 700; margin-right:30px;"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LblTotal" runat="server" Text=""
        style="position:relative; float:right;
            font-size: 180%; font-weight: 700; margin-right:30px;"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btncheckout" CssClass="btn btn-primary" runat="server" Text="Check Out" OnClick="Btncheckout_Click"
        style="position:relative; float:right; margin-right:30px;"/>
    <br />
    <br />

</asp:Content>

