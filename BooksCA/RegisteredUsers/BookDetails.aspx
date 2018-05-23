<%@ Page Title="Details" Language="C#" MasterPageFile="~/RegisteredUsers/RegUsers.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="BooksCA.BookDetails" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="row panel panel-body">
        <div class ="col-xs-6 col-sm-6 col-md-6">
            <asp:Image ID="Image1" runat="server" />
        </div>
            <div class ="col-xs-6 col-sm-6 col-md-6">
                <br />
                <br />
                <br />
            <asp:Label ID="lbltitle" runat="server" Text="Label"
                style="font-size: 150%; font-weight: 200"></asp:Label>
                <br />
                <br />
            <asp:Label ID="lblcate" runat="server" Text="Label"></asp:Label>
            <br />
                <br />
            <asp:Label ID="lblisbn" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
            <asp:Label ID="lblauthor" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
            <asp:Label ID="lblprice" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <br />
            <asp:Button ID="btnAdd" CssClass="btn btn-primary" runat="server" Text="Add to Cart" UseSubmitBehavior="False" />
            <br />
        </div>

    </div>
</asp:Content>
