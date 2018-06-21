using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace BooksCA
{
    public partial class AddBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RadioButtonList1.DataSource = bizlogic.ListCategory();
                RadioButtonList1.DataTextField = "Name";
                RadioButtonList1.DataValueField = "CategoryID";
                RadioButtonList1.DataBind();
                StatusLabel.Text = " ";
     
            }


        }

        protected void Button2_Click2(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string Title = TextBox1.Text;
                    string ISBN = TextBox3.Text;
                    string Author = TextBox2.Text;
                    int stock = Convert.ToInt32(TextBox4.Text);
                    decimal price = Convert.ToDecimal(TextBox5.Text);
                    string filename = FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath("~/images/") + filename);
                    int Cat = Convert.ToInt32(RadioButtonList1.SelectedValue.ToString());
                    bizlogic.AddBook(Title, ISBN, Author, Cat, stock, price);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    Response.Redirect("~/Protected/UserPage.aspx");
                }
                catch (Exception ex)
                {
                    StatusLabel.Visible = true;
                    StatusLabel.Text =
                        "Upload status: The file could not be uploaded." +
                        "The following error occurred: " + ex.Message;
                }

            }

        }
    }
}

       
    

    
