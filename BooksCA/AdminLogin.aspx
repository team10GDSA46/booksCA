<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="BooksCA.AdminLogin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                <h1>Authentication Required</h1>
                 <div>
                     
                     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                     <br />
                     <input type="password" runat="server" id="Password" placeholder="password" required />
                     <br />
                     <asp:Button ID="Button1" runat="server" OnClick="LoginButton_Click" Text="Button" />
                     
                 </div>
</asp:Content>
