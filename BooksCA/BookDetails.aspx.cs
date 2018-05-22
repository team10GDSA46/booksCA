using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksCA
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                using (Mybooks mb = new Mybooks())
                {
                    int bookid = Convert.ToInt32(Request.QueryString["id"]);

                    Book b = new Work().GetBook(bookid);
                    string isbn = b.ISBN;
                    string title = b.Title;
                    string author = b.Author;
                    Image1.ImageUrl = "images/" + isbn +".jpg";
                    Label1.Text = title;
                    Label2.Text = author;
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}