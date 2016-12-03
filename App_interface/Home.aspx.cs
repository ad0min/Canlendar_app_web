using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace app
{
    public partial class Home : System.Web.UI.Page
    {
        DateTime day;
        string User;
        database db = new database();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) ;           
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

        protected void Jan_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 1, Calendar1.SelectedDate.Day);
                      
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 2, Calendar1.SelectedDate.Day);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 3, Calendar1.SelectedDate.Day);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 4, Calendar1.SelectedDate.Day);

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 5, Calendar1.SelectedDate.Day);

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 6, Calendar1.SelectedDate.Day);

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 7, Calendar1.SelectedDate.Day);

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 8, Calendar1.SelectedDate.Day);

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 9, Calendar1.SelectedDate.Day);

        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 10, Calendar1.SelectedDate.Day);

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 11, Calendar1.SelectedDate.Day);

        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Calendar1.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, 12, Calendar1.SelectedDate.Day);

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
       

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            day = Calendar1.SelectedDate;
            TextBox1.Text = db.getTodo(day);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                if (Calendar1.SelectedDate != new DateTime(0001, 1, 1))
                    day = Calendar1.SelectedDate;
                else
                    day = Calendar1.TodaysDate;
                db.setTodo(day, TextBox1.Text);
                db.storeData();
            }
        }
    }
}