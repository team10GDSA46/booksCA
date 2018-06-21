using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace BooksCA
{
    public partial class ViewCart : System.Web.UI.Page
    {

        Mybooks mb;
        int userid;
        int bid;
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
            mb = new Mybooks();
            if (Request.QueryString["id"] != null)
            {

                bid = Convert.ToInt32(Request.QueryString["id"]);
                if ((mb.Books.Where(x => x.BookID == bid).Count() > 0) &&

                    (new Work().CheckStock(bid) > 0) &&

                    (mb.CartBooks.Where(x => x.BookID == bid)
                    .Where(x => x.UserID == userid)
                    .Count() < 1))
                {
                    CartBook newitem = new CartBook();
                    newitem.UserID = userid;
                    newitem.BookID = bid;
                    mb.CartBooks.Add(newitem);
                    mb.SaveChanges();
                }
                Response.Redirect("~/RegisteredUsers/ViewCart.aspx");
            }
            using (mb)
            {
                int count = mb.CartBooks.Where(x => x.UserID == userid).Count();
                List<Book> cart = mb.CartBooks.Where(x => x.UserID == userid)
                    .Select(x => x.Book).ToList();
                if ( count > 0)
                {
                    Session["cartitems"] = cart;

                    Work o = new Work();
                    double checkDiscountValue = o.GetDiscountRate(DateTime.Today.Date);
                    if (checkDiscountValue > 0)
                    {
                        DiscountLabel.Visible = true;
                        DiscountLabel.Text = "You have a discount of " + (checkDiscountValue*100) + "%";
                    }
                    else
                    {
                        DiscountLabel.Visible = false;
                    }

                    cartstatus.InnerText = count + " book(s) in cart.";
                    double discount = new Work().GetDiscountRate(DateTime.Today.Date);
                    foreach (Book b in cart)
                    {
                        double price = (double)b.Price;
                        double amount = price - (price * discount);

                        HtmlGenericControl newDiv = new HtmlGenericControl("DIV");
                        HtmlGenericControl details = new HtmlGenericControl("DIV");
                        HtmlGenericControl imagediv = new HtmlGenericControl("DIV");
                        HtmlGenericControl third = new HtmlGenericControl("DIV");
                        Image img = new Image();
                        Button btn = new Button();

                        newDiv.Attributes["class"] = "row well";

                        img.ImageUrl = "~/images/" + b.ISBN + ".jpg";
                        img.Style.Add("position", "relative");
                        img.Style.Add("float", "right");
                        img.Style.Add("margin-right", "40px");

                        imagediv.Attributes["class"] = "col-xs-4 col-sm-4 col-md-4";

                        details.InnerHtml = "<br /><br /><br />" +
                            "<strong>" + b.Title + "</strong>" +
                            "<br /><br />" + b.Author +
                            "<br /><br />" + price.ToString();
                        details.Attributes["class"] = "col-xs-6 col-sm-6 col-md-6";

                        third.InnerHtml = "<br /><br />" +
                            "<p class=\"text-center\" style=\"font-size: 200%\"><strong>" +
                            String.Format("{0:c}", amount) +
                            "</strong></p>";
                        third.InnerHtml += "<br /><br /><br />";
                        third.Attributes["class"] = "col-xs-2 col-sm-2 col-md-2";

                        btn.Text = "Remove";
                        btn.ID = b.BookID.ToString();
                        btn.Attributes.Add("class", "btn btn-danger");
                        btn.Click += BtnClick;


                        cartdiv.Controls.Add(newDiv);
                        newDiv.Controls.Add(imagediv);
                        imagediv.Controls.Add(img);
                        newDiv.Controls.Add(details);
                        newDiv.Controls.Add(third);
                        third.Controls.Add(btn);
                    }
                    LblTotal.Text = "Total ~ " + String.Format("{0:c}",
                        new Work().CalculateTotal(cart));

                }
                else
                {
                    cartstatus.InnerText = "There is no book in cart.";
                    btncheckout.Enabled = false;
                }

            }
        }
        protected void BtnClick(object sender, EventArgs e)
        {
            mb = new Mybooks();
            Button b = (Button)sender;
            int bid = Convert.ToInt32(b.ID);

            CartBook toDel = mb.CartBooks.Where(x =>
            (x.UserID == userid) && (x.BookID == bid)).First();
            mb.CartBooks.Remove(toDel);

            mb.SaveChanges();
            Response.Redirect("~/RegisteredUsers/ViewCart.aspx/");
        }


        protected void Btncheckout_Click(object sender, EventArgs e)
        {
            List<Book> cartitems = (List<Book>)Session["cartitems"];
            Work w = new Work();
            w.Transaction(userid, cartitems);
            w.RemoveItems(userid);
            Response.Redirect("~/RegisteredUsers/ViewCart.aspx");

        }
    }
}