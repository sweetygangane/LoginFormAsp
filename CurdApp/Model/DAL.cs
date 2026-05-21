using CURDAPP.Model;
using System.Data;
using System.Data.SqlClient;

namespace CURDAPP.Model
{
    public class DAL
    {
        // GET ALL
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT * FROM tblcurdNetCore",
                    connection);

            DataTable dt = new DataTable();

            List<Employee> ListEmployee = new List<Employee>();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();

                    employee.Id =
                        Convert.ToInt32(dt.Rows[i]["Id"]);

                    employee.Name =
                        Convert.ToString(dt.Rows[i]["Name"]);

                    employee.Email =
                        Convert.ToString(dt.Rows[i]["Email"]);

                    employee.IsActive =
      Convert.ToBoolean(dt.Rows[i]["IsActive"]);

                    employee.CreatedOn =
                        Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);

                    ListEmployee.Add(employee);
                }

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.ListEmployee = ListEmployee;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.ListEmployee = null;
            }

            return response;
        }

        // GET BY ID
        public Response GetEmployeeById(SqlConnection connection, int id)
        {
            Response response = new Response();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT * FROM tblcurdNetCore WHERE Id = @Id",
                    connection);

            da.SelectCommand.Parameters.AddWithValue("@Id", id);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Employee employee = new Employee();

                employee.Id =
                    Convert.ToInt32(dt.Rows[0]["Id"]);

                employee.Name =
                    Convert.ToString(dt.Rows[0]["Name"]);

                employee.Email =
                    Convert.ToString(dt.Rows[0]["Email"]);

                employee.IsActive =
                    Convert.ToBoolean(dt.Rows[0]["IsActive"]);

                employee.CreatedOn =
                    Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.Employee = employee;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
            }

            return response;
        }

        // ADD
        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO tblcurdNetCore " +
                "(Name, Email, IsActive, CreatedOn) " +
                "VALUES (@Name, @Email, @IsActive, @CreatedOn)",
                connection);

            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);
            cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now);

            connection.Open();

            int i = cmd.ExecuteNonQuery();

            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Added";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Employee Not Added";
            }

            return response;
        }

        // UPDATE
        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand(
                "UPDATE tblcurdNetCore SET " +
                "Name = @Name, " +
                "Email = @Email, " +
                "IsActive = @IsActive " +
                "WHERE Id = @Id",
                connection);

            cmd.Parameters.AddWithValue("@Id", employee.Id);
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);

            connection.Open();

            int i = cmd.ExecuteNonQuery();

            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Updated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Employee Not Updated";
            }

            return response;
        }

        // DELETE
        public Response DeleteEmployee(SqlConnection connection, int id)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM tblcurdNetCore WHERE Id = @Id",
                connection);

            cmd.Parameters.AddWithValue("@Id", id);

            connection.Open();

            int i = cmd.ExecuteNonQuery();

            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Employee Not Deleted";
            }

            return response;
        }
    }
}