<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBooks2.aspx.cs" Inherits="BooksCA.AddBooks2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:FileUpload ID="FileUpload1" runat="server" />
	<asp:FileUpload ID="FileUpload2" width="300px" runat="server" />
	<asp:Button ID="Button1" runat="server" Text="Upload File" OnClick="btnUpload_Click" ValidationGroup ="vg" style ="width:99px" />
	<br />
	<asp:GridView ID="GridView1" runat="server" EmptyDataText="No record found!" height="25">





	</asp:GridView>
</asp:Content>
