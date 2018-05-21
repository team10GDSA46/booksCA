using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    GridView1.DataSource = b.Books.ToList<Book>();
                    GridView1.DataBind();
                }
            }

        }
    }
}