using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BooksCA
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void FromButton_Click(object sender, EventArgs e)
        {
                datepicker.Visible = true;
                datepicker2.Visible = false;
        }

        protected void ToButton_Click(object sender, EventArgs e)
        {
            if(FromTextBox.Text == "")
            {
                Response.Write("Pick a FromDate First");
            }
            else
            {
                datepicker2.Visible = true;
                datepicker.Visible = false;
            }
           
        }

        protected void datepicker_SelectionChanged(object sender, EventArgs e)
        {
              FromTextBox.Text = datepicker.SelectedDate.ToLongDateString();         
              datepicker.Visible = false;
        }

        protected void datepicker2_SelectionChanged(object sender,EventArgs e)
        {
            ToTextBox.Text = datepicker2.SelectedDate.ToLongDateString();
            datepicker2.Visible = false;
        }

        protected void ApplyButton_Click(object sender, EventArgs e)
        {
            bool ExceptionFound = false;
            try
            {
                DateTime fd = datepicker.SelectedDate;
                DateTime td = datepicker2.SelectedDate;
                Decimal d = Convert.ToDecimal(DiscountTextBox.Text);

                string conString = "Data Source=(local);Initial Catalog=Bookshop;Integrated Security=SSPI";
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();

                string sql = "insert into Discount values(@fd,@td,@d);";
                SqlCommand cm = new SqlCommand(sql, cn);
                cm.Parameters.AddWithValue("@fd", fd);
                cm.Parameters.AddWithValue("@td", td);
                cm.Parameters.AddWithValue("@d", d);
                cm.ExecuteNonQuery();
                cn.Close();
            }

            catch(System.FormatException)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please ensure all boxes are properly filled');", true);
                ExceptionFound = true;
            }

            if(ExceptionFound == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('New Discount has been added !');", true);
            }
                
        }

        protected void datepicker2_DayRender(object sender, DayRenderEventArgs e)
        {
            //This disables the calendar dates in the past. (beginning of time - yesterday)
            if (e.Day.Date < System.DateTime.Today)
            {
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Day.IsSelectable = false;
            }

            //This disables the calendar dates upto FromDate Selected
            //if(e.Day.Date < datepicker.SelectedDate)
            //{
            //    e.Cell.BackColor = System.Drawing.Color.LightGray;
            //    e.Day.IsSelectable = false;
            //}

            if(e.Day.Date < datepicker.SelectedDate)
            {
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Day.IsSelectable = false;
            }

            //---------------------------------------------------------------------------------------------------------------------------------------
            //This disables those dates to which discounts have already been applied.
            //Eg. If admin has applied a discount from 5th May to 10th May,
            // those dates will be DISABLED as it would not make sense for him to apply discount again on the same date.
            String cns = "Data Source=(local);Initial Catalog=Bookshop;Integrated Security=SSPI";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();

            SqlCommand cm = new SqlCommand("select FromDate,ToDate from Discount", cn);
            SqlDataReader rd = cm.ExecuteReader();

            DateTime[] FD = new DateTime[30];
            DateTime[] TD = new DateTime[30];
            int i = 0;

            while (rd.Read())
            {
                FD[i] = Convert.ToDateTime(rd["FromDate"]);
                TD[i] = Convert.ToDateTime(rd["ToDate"]);
                i++;
            }

            cn.Close();
            for (int j = 0; j < i; j++)
            {
                if (e.Day.Date.CompareTo(FD[j]) >= 0 && e.Day.Date.CompareTo(TD[j]) <= 0)
                {
                    e.Cell.BackColor = System.Drawing.Color.LightGray;
                    e.Day.IsSelectable = false;
                }
            }
            //---------------------------------------------------------------------------------------------------------------------------------------
        }

        protected void datepicker_DayRender(object sender,DayRenderEventArgs e)
        {

            //This disables the calendar dates in the past. (beginning of time - yesterday)
            if (e.Day.Date < System.DateTime.Today)
            {
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Day.IsSelectable = false;
            }

            //---------------------------------------------------------------------------------------------------------------------------------------
            //This disables those dates to which discounts have already been applied.
            //Eg. If admin has applied a discount from 5th May to 10th May,
            // those dates will be DISABLED as it would not make sense for him to apply discount again on the same date.
            String cns = "Data Source=(local);Initial Catalog=Bookshop;Integrated Security=SSPI";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();

            SqlCommand cm = new SqlCommand("select FromDate,ToDate from Discount",cn);
            SqlDataReader rd = cm.ExecuteReader();

            DateTime[] FD = new DateTime[30];
            DateTime[] TD = new DateTime[30];
            int i = 0;

            while(rd.Read())
            {
                FD[i] =Convert.ToDateTime(rd["FromDate"]);
                TD[i] = Convert.ToDateTime(rd["ToDate"]);
                i++;
            }

            cn.Close();
            for(int j=0;j<i;j++)
            {
                if(e.Day.Date.CompareTo(FD[j])>=0  && e.Day.Date.CompareTo(TD[j])<=0)
                {
                    e.Cell.BackColor = System.Drawing.Color.LightGray;
                    e.Day.IsSelectable = false;
                }
            }
            //---------------------------------------------------------------------------------------------------------------------------------------
        }

       



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "ID";
                e.Row.Cells[1].Text = "FromDate";
                e.Row.Cells[2].Text = "ToDate";
                e.Row.Cells[3].Text = "Discount";
            }
        }


        //This is actually the ViewDiscountHistory LinkButton Event Handler.
        protected void BookHistoryButton_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            string s = "Data Source=(local);Initial Catalog=Bookshop;Integrated Security=SSPI";
            using (SqlConnection con = new SqlConnection(s))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select ID,FromDate,ToDate,DiscountPercent from Discount",con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                con.Close();
            }
        }


        //This function allows admins to delete any discounts applied from the DiscountGrid itself
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ToBeDeleted = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string conString = "Data Source=(local);Initial Catalog=Bookshop;Integrated Security=SSPI";
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string sql = "delete from Discount where ID = @ToBeDeleted";
            SqlCommand cm = new SqlCommand(sql, cn);
            cm.Parameters.AddWithValue("@ToBeDeleted", ToBeDeleted);
            cm.ExecuteNonQuery();
            cn.Close();
            ClientScript.RegisterStartupScript(this.GetType(),"myalert","alert('Record has been deleted');",true);
        }



        //This function can be used to check if there are any discounts for the day.
        //The function accepts a DateTime and returns a boolean to indicate if discount is available for the day or not
        //This has been covered in Yan's function();
        public bool IsThereADiscountToday(DateTime d)
        {
            DateTime dd = d;
            String cns = "Data Source=(local);Initial Catalog=Bookshop;Integrated Security=SSPI";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();

            SqlCommand cm = new SqlCommand("select FromDate,ToDate from Discount", cn);
            SqlDataReader rd = cm.ExecuteReader();

            DateTime[] FD = new DateTime[30];
            DateTime[] TD = new DateTime[30];
            int i = 0;

            while (rd.Read())
            {
                FD[i] = Convert.ToDateTime(rd["FromDate"]);
                TD[i] = Convert.ToDateTime(rd["ToDate"]);
                i++;
            }

            cn.Close();

            for(int j=0;j<i;j++)
            {
                if(dd.Date.CompareTo(FD[j]) >= 0 && dd.Date.CompareTo(TD[j]) <= 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}