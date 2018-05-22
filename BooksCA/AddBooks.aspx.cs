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
            
            if (!IsPostBack)
            {                
                RadioButtonList1.DataSource = bizlogic.ListCategory();
                RadioButtonList1.DataTextField = "Name";
                RadioButtonList1.DataValueField = "CategoryID";
                RadioButtonList1.DataBind();
            }

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            

        }

        protected void Button2_Click1(object sender, EventArgs ex)
        {
            

                
         }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //try
                {
                    string filename = FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath("~/images/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    Image1.ImageUrl = String.Format("~/images/{0}", filename);
                    Image1.Visible = true;
                    string Title = TextBox3.Text;
                    string ISBN = TextBox1.Text;
                    string Author = TextBox4.Text;
                    int stock = Convert.ToInt32(TextBox5.Text);
                    decimal price = Convert.ToDecimal(TextBox6.Text);
                    int Cat = Convert.ToInt32(RadioButtonList1.SelectedValue.ToString());
                    bizlogic.AddBook(Title, ISBN, Author, Cat, stock, price);
                }
                //catch (Exception ex)
                //{
                //    StatusLabel.Text =
                //        "Upload status: The file could not be uploaded." +
                //        "The following error occurred: " + ex.Message;
                //}

            }
        }
    }

    
}