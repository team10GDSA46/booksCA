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
                    if(mb.Books.Where(x => x.BookID == bookid).Count() < 1)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    Book b = new Work().GetBook(bookid);
                    string isbn = b.ISBN;
                    Image1.ImageUrl = "images/" + isbn +".jpg";
                    Image1.Style.Add("position", "relative");
                    Image1.Style.Add("float", "right");
                    Image1.Style.Add("margin-right", "40px");
                    Image1.Style.Add("margin-top", "50px");

                    lbltitle.Text = b.Title;
                    lblcate.Text = mb.Categories
                        .Where(x => x.CategoryID == b.CategoryID)
                        .Select(x => x.Name).First();
                    lblisbn.Text = isbn;
                    lblprice.Text = String.Format("{0:c}",b.Price);
                    lblauthor.Text = b.Author;

                    if (mb.CartBooks.Where(x => (x.UserID == 1) &&
                    (x.BookID == b.BookID)).Count() > 0)
                    {
                        btnAdd.Text = "Already in cart!";
                        btnAdd.Enabled = false;
                    }
                    else if (new Work().CheckStock(b.BookID) < 1)
                    {
                        btnAdd.Text = "Out of Stock";
                        btnAdd.CssClass = "btn btn-danger";
                        btnAdd.Enabled = false;
                    }
                    else
                    {
                        btnAdd.PostBackUrl = "~/ViewCart.aspx?id=" + b.BookID;
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}