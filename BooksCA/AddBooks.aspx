<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBooks.aspx.cs" Inherits="BooksCA.AddBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
    <div>
        <br />
		<h3><strong>
        	<asp:Image ID="Image1" runat="server" Height="192px" Width="203px" />
		</strong>
        </h3>
		<h3><strong>
        <asp:Label ID="Label7" runat="server" Text="Image: "></asp:Label>
			<asp:FileUpload ID="FileUpload1" runat="server" Width="574px" />
		</strong>
        </h3>
		<br />
		<h3><strong>
        <asp:Label ID="Label2" runat="server" Text="Title: "></asp:Label>
		</strong>
		<asp:TextBox ID="TextBox3" runat="server" Height="32px" Width="513px"></asp:TextBox>
        </h3>
        <br />
		<h3><strong>
        <asp:Label ID="Label3" runat="server" Text="ISBN: "></asp:Label>
		</strong>
		<asp:TextBox ID="TextBox1" runat="server" Height="32px" Width="512px"></asp:TextBox>
        </h3>
        <br />
		<h3><strong>
        <asp:Label ID="Label4" runat="server" Text="Author: "></asp:Label>
		</strong>
		<asp:TextBox ID="TextBox4" runat="server" Height="32px" Width="486px"></asp:TextBox>
        </h3>
        <br />

		<h3><strong>
		<asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
		</strong></h3>
		<asp:RadioButtonList ID="RadioButtonList1" runat="server">
		</asp:RadioButtonList>
		<br />
		<h3><strong>
        <asp:Label ID="Label5" runat="server" Text="Stock: "></asp:Label>
		</strong>
		<asp:TextBox ID="TextBox5" runat="server" Height="32px"></asp:TextBox>
        </h3>
		<h3><strong>
        <asp:Label ID="Label6" runat="server" Text="Price: "></asp:Label>
		</strong>
		<asp:TextBox ID="TextBox6" runat="server" Height="32px"></asp:TextBox>
        </h3>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
        <br />
		
        <asp:Label ID="StatusLabel" runat="server" Text="Label"></asp:Label>
		
    </div>
 
</asp:Content>



