<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="BooksCA.Loginpage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link href="https://fonts.googleapis.com/css?family=Alegreya+Sans:300,400,700" rel="stylesheet"/>
    <link rel="css/styles.css" />
    <link href="StyleSheet.css" rel="stylesheet" type="text/css"/>
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet" />
    
    <title></title>
</head>
    <body>
    <form id="form1" runat="server">
        <section>
            <div class="container">
                <div class="inner1">
                     
                    <h3>Sign in</h3>
                    
                    <label for="Username" class="control-label">Username<br />
                    </label>
                    &nbsp;<asp:TextBox ID="inputusername" placeholder="Username" runat="server"></asp:TextBox>
                    <br />
                    <label for="Password" class="control-label">Password</label>
                    <br />
                    <asp:TextBox ID="inputpassword" placeholder="Password" runat="server"></asp:TextBox>

                    <asp:Button ID="btn_submit" runat="server" CssClass="btn" Text="Submit" />
               </div>
                <div class="inner2">
                    <h3>Sign up </h3>
                    <label for="Email address" class="control-label">Email address</label>
                    <asp:TextBox ID="TextBox1" placeholder="Email address" runat="server"></asp:TextBox>
                    <br />
                    <label for="Name" class="control-label">Name</label>
                    <br />
                    <asp:TextBox ID="TextBox2" placeholder="Name" runat="server"></asp:TextBox>
                    <label for="Password" class="control-label">
                    <br />
                    Password</label>
                    <br />
                    <asp:TextBox ID="TextBox3" placeholder="Password" runat="server"></asp:TextBox>                 
                    <br />
                    <label for="Verify Password" class="control-label">Verify Password</label>
                    <br />
                    <asp:TextBox ID="TextBox4" placeholder="Verify Password" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button2" runat="server" CssClass="btn" Text="Sign me up" />
            </div>
                </div>

        </section>
 
    </form>


  
</body>
</html>
