using System;
using System.Data.SqlClient;

namespace WebRegistration
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string gender = "";

            if (RadioButton1.Checked)
            {
                gender = "Male";
            }
            else if (RadioButton2.Checked)
            {
                gender = "Female";
            }

            string connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=RegistrationDB;" +
                "Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query =
                    "INSERT INTO Registration " +
                    "(FullName, Address, Gender, Phone, Email, Username, Password) " +
                    "VALUES " +
                    "(@FullName, @Address, @Gender, @Phone, @Email, @Username, @Password)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FullName", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Address", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Phone", TextBox3.Text);
                cmd.Parameters.AddWithValue("@Email", TextBox4.Text);
                cmd.Parameters.AddWithValue("@Username", TextBox5.Text);
                cmd.Parameters.AddWithValue("@Password", TextBox6.Text);

                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    Response.Write("<script>alert('Registration Successful');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Registration Failed');</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";

            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
        }
    }
}