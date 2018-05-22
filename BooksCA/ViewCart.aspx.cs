using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksCA
{
    public partial class ViewCart : System.Web.UI.Page
    {

        Mybooks mb;
        int userid = 1;
        int bid;
        protected void Page_Load(object sender, EventArgs e)
        {
            mb = new Mybooks();
            if (Request.QueryString["id"] != null)
            {
                if(mb.Books.Where(x => x.BookID == bid).Count() > 0)
                {
                    bid = Convert.ToInt32(Request.QueryString["id"]);
                    cartBook newitem = new cartBook();
                    newitem.UserID = 1;
                    newitem.BookID = bid;
                    mb.cartBooks.Add(newitem);
                    mb.SaveChanges();
                }
                Response.Redirect("~/ViewCart.aspx");
            }
            using (mb)
            {
                int count = mb.cartBooks.Where(x => x.UserID == userid).Count();
                List<Book> cart = mb.cartBooks.Where(x => x.UserID == userid)
                    .Select(x => x.Book).ToList();
                if ( count > 0)
                {
                    cartstatus.InnerText = count + " book(s) in cart.";
                    foreach (Book b in cart)
                    {
                        Image image = new Image();
                        Button btn = new Button();

                        image.ImageUrl = "~/images/" + b.ISBN + ".jpg";
                        btn.Text = "Remove";
                        btn.ID = b.BookID.ToString();
                        btn.Attributes.Add("class", "btn btn-danger");
                        btn.Click += BtnClick;

                        cartdiv.Controls.Add(image);
                        cartdiv.Controls.Add(btn);
                    }
                }
                else
                {
                    cartstatus.InnerText = "There is no book in cart.";
                    btncheckout.Enabled = false;
                }
                Session["cartitems"] = cart;
            }
        }
        protected void BtnClick(object sender, EventArgs e)
        {
            mb = new Mybooks();
            Button b = (Button)sender;
            int bid = Convert.ToInt32(b.ID);
            cartBook toDel = mb.cartBooks.Where(x =>
            (x.UserID == userid) && (x.BookID == bid)).First();
            mb.cartBooks.Remove(toDel);
            mb.SaveChanges();
            Response.Redirect("~/ViewCart.aspx");
        }

        protected void btncheckout_Click(object sender, EventArgs e)
        {
            mb = new Mybooks();
            Tran t = new Tran();
            t.UserID = userid;
            t.transDate = DateTime.Today.Date;
            List<Book> cartitem = (List<Book>)Session["cartitems"];
            foreach (Book b in cartitem)
            {
                Transdetail td = new Transdetail();
                td.transID = t.transID;
                //td.BookID
            }
        }
    }
}