<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BooksCA.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID="Login1" class="form-group"
        runat="server" DestinationPageUrl="~/Protected/UserPage.aspx">
    </asp:Login>
</asp:Content>
