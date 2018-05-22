<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testlogin.aspx.cs" Inherits="BooksCA.testlogin" %>






<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheettestLogin.css" type="text/css" rel="stylesheet"/>
     <asp:Login ID="Login1" runat="server">
          <LayoutTemplate>
         <div class="box">
             <div class="content">
                 <h1>Authentication Required</h1>
                <form>
                 <div>

                 <asp:Label ID="Label2" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                 <asp:TextBox class="field" placeholder="Operative ID" ID="UserName" runat="server"></asp:TextBox>

                 <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                 <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                 <asp:TextBox class="field" placeholder="Access Code" ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                 <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                 <asp:Button class="btn" ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" />
         
                 </div>
                     <form>
                    </form>
                 </LayoutTemplate>
    </asp:Login>

</asp:Content>

        
            
   