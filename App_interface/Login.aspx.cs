using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using System.Windows;
namespace app
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void user_TextChanged(object sender, EventArgs e)
        {

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                SqlConnection conn = new SqlConnection(database.getConnString());
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) from Account where Users='" + TextboxUser.Text + "'",conn);
                   
                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (temp == 1)
                    {
                        var passQuery = new SqlCommand("select Pass from Account where Users= '" + TextboxUser.Text + "'", conn);
                        var IdQuery = new SqlCommand("select Id from Account where Users= '" + TextboxUser.Text + "'", conn);
                        string pass = passQuery.ExecuteScalar().ToString();
                        string Id = IdQuery.ExecuteScalar().ToString();
                        {
                        if (pass == getmd5(TextboxPass.Text))
                        {
                            Session["Username"] = TextboxUser.Text;
                            Session["Id"] = Id;
                            Response.Write("Login successful.");
                            Response.Redirect("Home.aspx");
                        }
                        else
                            Response.Write("Your password is wrong.");
                        }
                    }
                    else
                        Response.Write("Your account is not existed.");
                }


                catch (Exception ex)
                {
                    Response.Write("Error:" + ex.ToString());
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public string getmd5(string str)
        {
            string str_md5 = "";
            byte[] md5 = System.Text.Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            foreach (byte b in md5)
            {
                str_md5 += b.ToString("x2");
            }
            return str_md5;
        }
    }
}