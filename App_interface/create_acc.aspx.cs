using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace app
{
    public partial class CreateAcc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (IsPostBack)
            {
                string connectionString = database.getConnString();
                SqlConnection conn = new SqlConnection(connectionString);
                //(@"Data Source=DESKTOP-DKTHS8S\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

                try
                {
                    conn.Open();
                    string checkuser = "select count(*) from Account where User= '" + TextboxUser.Text + "'";
                    SqlCommand cmd = new SqlCommand(checkuser, conn);
                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (temp == 1)
                    {
                        Response.Write("Username is exits");
                        this.Page_Load(sender, e);
                    }
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

        protected void ButtonCreateacc_Click(object sender, EventArgs e)
        {
            string connectionString = database.getConnString();
            SqlConnection conn = new SqlConnection(connectionString);
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["loginConnectionString"].ConnectionString);
            try
            {

                conn.Open();
                string checkuser = "select count(*) from Account where User= '" + TextboxUser.Text + "'";
                SqlCommand cmd = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (temp != 1)
                {
                    cmd = new SqlCommand("insert into Account(User, Mail, Pass) values(@user,@email,@pass)", conn);
                    cmd.Parameters.AddWithValue("@user", TextboxUser.Text);
                    string pass = getmd5(TextboxPass.Text);
                    cmd.Parameters.AddWithValue("@email", TextboxMail.Text);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Maganer.aspx");
                    //Response.Write("Registation is successfull!");
                }
                else
                {
                    Response.Write("Username is existed.");
                }
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