using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BooksCA
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (Mybooks b = new Mybooks())
                {
                    List<Book> booklist = b.Books.ToList();
                    foreach (Book bookdetail in booklist)
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
                          new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl details =
                            new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlInputImage image =
                            new System.Web.UI.HtmlControls.HtmlInputImage();

                        image.Src = "images/" + bookdetail.ISBN +".jpg";
                        details.InnerHtml = "<hr><strong style=\"font-size: 16px;\">" 
                            + bookdetail.Title + "</strong><br />";
                        details.InnerHtml += bookdetail.Author + "<br />";
                        details.InnerHtml += bookdetail.ISBN + "<br />";
                        details.InnerHtml += "$ " + bookdetail.Price;
                        newDiv.Attributes.Add("class", "col-xs-12 col-sm-6 col-md-4 well");
                        newDiv.Style.Add("height", "430px");
                        newDiv.Style.Add("text-align", "center");
                        mainDiv.Controls.Add(newDiv);
                        newDiv.Controls.Add(image);
                        newDiv.Controls.Add(details);
                    }
                }
            }

        }
    }
}