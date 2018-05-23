<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testlogin.aspx.cs" Inherits="BooksCA.testlogin" %>






<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheettestLogin.css" type="text/css" rel="stylesheet"/>
     <asp:Login ID="Login1" runat="server">
          <LayoutTemplate>
                 <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                 <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                 <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                 <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                 <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" />

                 </LayoutTemplate>
    </asp:Login>

</asp:Content>

        
            
   