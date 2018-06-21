<%@ Page Title="" Language="C#" MasterPageFile="~/Protected/Protected.Master" AutoEventWireup="true" CodeBehind="AddBooks.aspx.cs" Inherits="BooksCA.AddBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div>
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
		<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
		
	</div>
	<div class="container">
		<h2>Adding New Book</h2>
		<p>Please fill up the following details</p>

		<div class="form-group">
			<label for="inputlg">Title</label>
			<asp:TextBox ID="TextBox1" runat="server" class="form-control input-lg" ></asp:TextBox>
		</div>
		<div class="form-group">
			<label for="inputlg">Author</label>
			<asp:TextBox ID="TextBox2" runat="server" class="form-control input-lg" ></asp:TextBox>
		</div>
		<div class="form-group">
			<label for="inputlg">ISBN</label>
			<asp:TextBox ID="TextBox3" runat="server" class="form-control input-lg" ></asp:TextBox>
		</div>
		<div class="form-group">
			<label for="inputlg">Stock</label>
			<asp:TextBox ID="TextBox4" runat="server" class="form-control input-lg" ></asp:TextBox>
		</div>
		<div class="form-group">
			<label for="inputlg">Price</label>
			<asp:TextBox ID="TextBox5" runat="server" class="form-control input-lg" ></asp:TextBox>
		</div>
		<div>
			<asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
		</div>

		<div>
				<asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="Inset" Height="36px" />
		</div>
		<div>
			<asp:Button ID="Button2" runat="server"  class="btn btn-primary btn-file" Text="Sumbit" OnClick="Button2_Click2" />
		</div>

		<div>
			<asp:Label ID="StatusLabel" runat="server" Text="Label" ></asp:Label>
		</div>
	</div>


	
</asp:Content>



