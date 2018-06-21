using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

namespace BooksCA
{
    public partial class _Default1 : Page
    {
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || (string)Session["role"] != "user")
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                userid = (int)Session["userid"];
            }
            if (!IsPostBack)
            {
                using (Mybooks mb = new Mybooks())
                {
                    List<Book> booklist = mb.Books.ToList();
                    foreach (Book bookdetail in booklist)
                    {
                        HtmlGenericControl newDiv = new HtmlGenericControl("DIV");
                        HtmlGenericControl details = new HtmlGenericControl("DIV");
                        HtmlInputImage image = new HtmlInputImage();
                        HtmlAnchor anch = new HtmlAnchor();
                        HtmlAnchor btncart = new HtmlAnchor();

                        image.Src = "~/images/" + bookdetail.ISBN + ".jpg";
                        image.Disabled = true;
                        image.Style.Add("width", "200px");
                        image.Style.Add("height", "220px");

                        anch.InnerHtml = "<hr><strong style=\"font-size: 16px;\">"
                            + bookdetail.Title + "</strong><br />";

                        details.InnerHtml += bookdetail.Author + "<br />";
                        details.InnerHtml += bookdetail.ISBN + "<br />";
                        details.InnerHtml += "$ " + bookdetail.Price;

                        newDiv.Attributes.Add("class", "col-xs-12 col-sm-6 col-md-4 well");
                        newDiv.Style.Add("height", "500px");
                        newDiv.Style.Add("text-align", "center");
                        newDiv.Style.Add("padding", "30px");

                        btncart.InnerText = "Add to Cart";
                        btncart.Attributes.Add("class", "btn btn-primary");
                        btncart.Style.Add("position", "absolute");
                        btncart.Style.Add("top", "86%");
                        btncart.Style.Add("left", "36%");
                        btncart.ID = bookdetail.BookID.ToString();


                        anch.HRef = "~/RegisteredUsers/BookDetails.aspx?id=" + bookdetail.BookID;
                        
                        // user access
                        if(mb.CartBooks.Where(x => (x.UserID == userid) &&

                         (x.BookID == bookdetail.BookID)).Count() > 0)
                        {
                            btncart.InnerText = "Already in cart!";
                            btncart.Style["left"] = "33%";
                            btncart.Disabled = true;
                        } else if(new Work().CheckStock(bookdetail.BookID) < 1)
                        {
                            btncart.InnerText = "Out of Stock";
                            btncart.Attributes["class"] = "btn btn-danger";
                            btncart.Disabled = true;
                        }
                        else
                        {
                            btncart.HRef = "~/RegisteredUsers/ViewCart.aspx?id=" + bookdetail.BookID;
                        }

                        mainDiv.Controls.Add(newDiv);
                        newDiv.Controls.Add(image);
                        newDiv.Controls.Add(anch);
                        newDiv.Controls.Add(details);
                        newDiv.Controls.Add(btncart);
                    }
                }
            }
            else
            {
            }
        }
    }
}
