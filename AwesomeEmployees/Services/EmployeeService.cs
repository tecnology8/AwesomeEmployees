using AwesomeEmployees.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AwesomeEmployees.Services
{
    public class EmployeeService
    {
        private readonly string _connectionString;
        public EmployeeService(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("Database");
        }
        public List<Employee> GetEmployees()
        {
            var lista = new List<Employee>();

            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();
                var query = "SELECT * FROM Employees";
                var cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                var reader =  cmd.ExecuteReader();
                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Designation = reader["Designation"].ToString(),
                        Department = reader["Department"].ToString(),
                        Company = reader["Company"].ToString(),
                        CityId = Convert.ToInt32(reader["CityId"])
                    };

                    lista.Add(employee);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }
    }
}