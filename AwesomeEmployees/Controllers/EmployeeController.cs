using AwesomeEmployees.Models;
using AwesomeEmployees.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Newtonsoft.Json;


namespace AwesomeEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employee;
        public EmployeeController(EmployeeService employee)
        {
            _employee = employee;
        }

        [HttpGet(Name = "GetEmployees")]
        public ActionResult Get()
        {
            var lista = _employee.GetEmployees().ToList();
            return Ok(lista);
        }
    }
}