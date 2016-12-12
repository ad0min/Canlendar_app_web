using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

namespace app
{
    public partial class Home : System.Web.UI.Page
    {
        DateTime day;
        database db = new database();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["Username"].ToString();
            if (!IsPostBack)
            {
                DropDownList1.SelectedValue= Calendar1.TodaysDate.Year.ToString();
                Session["year"] = DropDownList1.SelectedValue;
                day = Calendar1.TodaysDate;
                TextBox1.Text = db.getTodo(day);

                //  db.delete_emty();
            }

        }


        protected override void OnUnload(EventArgs e)
        {
            //db.storeData();   
            base.OnUnload(e);
            // TextBox1.Text = "Page unload";
        }

        protected void ValidateUser(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 1, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 2, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 3, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 4, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 5, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 6, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 7, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 8, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 9, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 10, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 11, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Convert.ToInt32(Session["year"]), 12, Calendar1.SelectedDate.Day);
            TextBox1.Text = String.Empty;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            day = Calendar1.SelectedDate;
            TextBox1.Text = db.getTodo(day);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate != new DateTime())
                day = Calendar1.SelectedDate;
            else
                day = Calendar1.TodaysDate;
            db.setTodo(day, TextBox1.Text);
            db.storeData();
            db.delete_emty();
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            // db.delete_emty();
            Style BusyDays = new Style();
            //BusyDays.BackColor = Color.Transparent;
            BusyDays.BorderStyle = BorderStyle.Solid;
            BusyDays.BorderColor = Color.Red;
            BusyDays.BorderWidth = 1;

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var conn = new SqlConnection(connectionString);
            conn.Open();
            string @days = "select Date from Todo where accID='" + Session["Id"] + "'";
            SqlCommand cmd = new SqlCommand(@days, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    if (e.Day.Date == (DateTime)rdr[0])
                        e.Cell.ApplyStyle(BusyDays);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
            finally
            {
                // db.delete_emty();
                if (rdr != null)
                {
                    rdr.Close();
                }
                conn.Close();
                conn.Dispose();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Int32.Parse(DropDownList1.SelectedValue);
            Calendar1.VisibleDate = new DateTime(a, 1, Calendar1.SelectedDate.Day);
            Session["year"] = a;
        }
    }
}