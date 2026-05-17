using System;
using System.Data.SqlClient;

namespace LoginFormWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=asplogin;" +
                "Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loginQuery =
                    "SELECT COUNT(*) FROM login " +
                    "WHERE username=@username AND password=@password";

                SqlCommand cmd = new SqlCommand(loginQuery, con);

                cmd.Parameters.AddWithValue("@username", TextBox1.Text);
                cmd.Parameters.AddWithValue("@password", TextBox2.Text);

                con.Open();

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    Response.Write("<script>alert('Login Successful');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Username or Password');</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}