using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksCA
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            using (Mybooks mb = new Mybooks())
            {
                int userid = Convert.ToInt32(txtUserID.Text);
                string password = Password.Value;
                if (mb.Users.Where(x => x.UserID == userid)
                    .Where(x => x.Password == password)
                    .Where(x => x.UserType == "user").Count() > 0)
                {
                    Session["role"] = "user";
                    Session["userid"] = userid;
                    Response.Redirect("~/RegisteredUsers/BookDetails.aspx");
                }
                else
                {
                    Response.Redirect("~/UserLogin.aspx");
                }
            }

        }

    }
}