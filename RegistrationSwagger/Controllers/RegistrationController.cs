using LoginRegistrationApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LoginRegistrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // INSERT
        [HttpPost]
        [Route("registration")]
        public string registration(Registration registration)
        {
            SqlConnection con = new SqlConnection(
                _configuration.GetConnectionString("ToysCon").ToString());

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Registration(UserName, Password, Email, IsActive) " +
                "VALUES('" + registration.UserName + "','" + registration.Password + "','" + registration.Email + "','" + registration.IsActive + "')",
                con);

            con.Open();

            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i > 0)
            {
                return "Data inserted";
            }
            else
            {
                return "Error";
            }
        }

        // LOGIN / SELECT
        [HttpPost]
        [Route("login")]
        public string login(Registration registration)
        {
            SqlConnection con = new SqlConnection(
                _configuration.GetConnectionString("ToysCon").ToString());

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Registration WHERE Email='" + registration.Email +
                "' AND Password='" + registration.Password +
                "' AND IsActive=1", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return "DATA FOUND";
            }
            else
            {
                return "Invalid User";
            }
        }

        // UPDATE
        [HttpPut]
        [Route("update")]
        public string update(Registration registration)
        {
            SqlConnection con = new SqlConnection(
                _configuration.GetConnectionString("ToysCon").ToString());

            SqlCommand cmd = new SqlCommand(
                "UPDATE Registration SET " +
                "UserName='" + registration.UserName + "', " +
                "Password='" + registration.Password + "', " +
                "Email='" + registration.Email + "', " +
                "IsActive='" + registration.IsActive + "' " +
                "WHERE Id='" + registration.Id + "'",
                con);

            con.Open();

            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i > 0)
            {
                return "Data Updated";
            }
            else
            {
                return "Update Failed";
            }
        }

        // DELETE
        [HttpDelete]
        [Route("delete/{id}")]
        public string delete(int id)
        {
            SqlConnection con = new SqlConnection(
                _configuration.GetConnectionString("ToysCon").ToString());

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Registration WHERE Id='" + id + "'",
                con);

            con.Open();

            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i > 0)
            {
                return "Data Deleted";
            }
            else
            {
                return "Delete Failed";
            }
        }
    }
}