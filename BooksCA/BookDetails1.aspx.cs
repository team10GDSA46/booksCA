using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksCA
{
    public partial class BookDetails1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Mybooks mb;
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                using (mb = new Mybooks())
                {
                    int bookid = Convert.ToInt32(Request.QueryString["id"]);
                    if(mb.Books.Where(x => x.BookID == bookid).Count() < 1)
                    {
                        Response.Redirect("~/RegisteredUsers/Default1.aspx");
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

                    btnAdd.Text = "Log In";
                    btnAdd.PostBackUrl = "~/UserLogin.aspx";
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}