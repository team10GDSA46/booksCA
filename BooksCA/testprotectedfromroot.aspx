<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testprotectedfromroot.aspx.cs" Inherits="BooksCA.testprotectedfromroot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>root page</h1>
        
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Protected/testprotect.aspx">go to protected link</asp:HyperLink>

</asp:Content>
