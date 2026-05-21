using CURDAPP.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;

namespace CURDAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET ALL
        [HttpGet]
        [Route("GetAllEmployees")]
        public Response GetAllEmployees()
        {
            SqlConnection connection =
                new SqlConnection(
                    _configuration.GetConnectionString("CrudCONNECTION"));

            Response response = new Response();

            DAL dal = new DAL();

            response = dal.GetAllEmployees(connection);

            return response;
        }

        // GET BY ID
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public Response GetEmployeeById(int id)
        {
            SqlConnection connection =
                new SqlConnection(
                    _configuration.GetConnectionString("CrudCONNECTION"));

            Response response = new Response();

            DAL dal = new DAL();

            response = dal.GetEmployeeById(connection, id);

            return response;
        }

        // ADD
        [HttpPost]
        [Route("AddEmployee")]
        public Response AddEmployee(Employee employee)
        {
            SqlConnection connection =
                new SqlConnection(
                    _configuration.GetConnectionString("CrudCONNECTION"));

            Response response = new Response();

            DAL dal = new DAL();

            response = dal.AddEmployee(connection, employee);

            return response;
        }

        // UPDATE
        [HttpPut]
        [Route("UpdateEmployee")]
        public Response UpdateEmployee(Employee employee)
        {
            SqlConnection connection =
                new SqlConnection(
                    _configuration.GetConnectionString("CrudCONNECTION"));

            Response response = new Response();

            DAL dal = new DAL();

            response = dal.UpdateEmployee(connection, employee);

            return response;
        }

        // DELETE
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public Response DeleteEmployee(int id)
        {
            SqlConnection connection =
                new SqlConnection(
                    _configuration.GetConnectionString("CrudCONNECTION"));

            Response response = new Response();

            DAL dal = new DAL();

            response = dal.DeleteEmployee(connection, id);

            return response;
        }
    }
}