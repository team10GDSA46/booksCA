using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksCA
{
    public partial class AdminLogin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            using(Mybooks mb = new Mybooks())
            {
                int userid = Convert.ToInt32(txtUserID.Text);
                string password = Password.Value;
                if(mb.Users.Where(x => x.UserID == userid)
                    .Where(x => x.Password == password).Count() > 0)
                {
                    Session["userauth"] = "true";
                    Session["userid"] = userid;
                    Response.Redirect("~/Protected/UserPage.aspx");
                }
                else
                {
                    Response.Redirect("~/AdminLogin.aspx");
                }
            }
        }
    }
}