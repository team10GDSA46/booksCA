using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksCA
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {


            GridView2.DataSource = UserBusinessLogic.Listbook();
            GridView2.DataBind();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int BookId = (int)GridView2.SelectedDataKey.Value;
            using (Mybooks entities = new Mybooks())
            {
                Book book = entities.Books.Where(p => p.BookID == BookId).First<Book>();
                DetailsView1.DataSource = new Book[] { book };
                DetailsView1.DataBind();
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView2.Rows[e.RowIndex];

            int BookId = Convert.ToInt32((row.FindControl("TextBox5") as TextBox).Text);

            string Title = (row.FindControl("TextBox7") as TextBox).Text;

            int CategoryID = Convert.ToInt32((row.FindControl("TextBox6") as TextBox).Text);

            string ISBN = (row.FindControl("TextBox1") as TextBox).Text;

            string Author = (row.FindControl("TextBox2") as TextBox).Text;

            int Stock = Convert.ToInt32((row.FindControl("TextBox3") as TextBox).Text);

            decimal Price = Convert.ToDecimal((row.FindControl("TextBox4") as TextBox).Text);

            UserBusinessLogic.UpdateBooks(BookId, Title, CategoryID, Author, ISBN, Stock, Price);
            GridView2.EditIndex = -1;
            BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView2.EditIndex = -1;
            BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int BookId = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
            UserBusinessLogic.DeleteBooks(BookId);
            BindGrid();
        }
    }
}
