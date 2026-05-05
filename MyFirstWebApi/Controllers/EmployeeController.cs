using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Model;
using MyFirstWebApi.Services;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //[HttpGet]
        //public IActionResult GetEmployee()
        //{

        //    return Ok("Hello Abhiram! Welcome to Web API Development.");
        //}

        [HttpGet("db_allemp")]
        public async Task<IActionResult> GetAllEmployeesFromDb()
        {
            var employee = await _employeeService.GetAll();
            return Ok(employee); //200
        }

        [HttpPost("dbaddemp")]
        public async Task<IActionResult>AddEmployeeToDb(EmployeeDTO employeedto)
        {
            
            if (employeedto == null)
            {
                 return BadRequest("Employee data is null.");//204 
            }
            var addemp = await _employeeService.AddEmp(employeedto);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = addemp.Id }, addemp); //202
            
        }

        [HttpPut("updateemp/{id}")]

        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {

            // Pro Tip: Validate if ID in URL matches ID in Object
            if (id != employee.Id)
            {
                return BadRequest("ID mismatch error.");
            }
            var exist = await _employeeService.UpdateEmp(id, employee);

            if (exist != null)
            {
                return Ok(exist);
            }
            return NotFound($"Employee with ID {id} not found.");
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var exist = await _employeeService.GetEmpById(id);
            if (exist != null)
            {
                return Ok(exist);
            }
            return NotFound($"Employee with ID {id} not found.");
        }

        [Authorize]
        [HttpDelete("deleteemp/{id}")]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var exist= await _employeeService.DleteEmp(id);
            if (exist)
            {
                return Ok($"Employee with ID {id} deleted successfully.");
            }
            else
            {
                return NotFound($"Employee with ID {id} not found.");
            }
        }

        //[HttpGet]
        //public IActionResult GetallEmployee()
        //{
        //    var employee = new List<string>
        //    {
        //        "Abhiram",
        //        "John",
        //        "Alice",
        //        "Bob"
        //    };
        //    return Ok(employee);
        //}

        //[HttpGet("details/{id}")]
        //public IActionResult GetEmpdetailsById(int id)
        //{
        //    var message = $"Employee ID {id} details requested by Abhiram.";
        //    return Ok(message);
        //}




        //[HttpGet("alldetails/{Id}")]
        //public IActionResult GetAllEmpdetails(int Id)
        //{
        //    var employees = new List<Employee>
        //    {
        //        new Employee { Id = 1, Name = "Abhiram", Department = "IT", Salary = 50000 },
        //        new Employee { Id = 2, Name = "John", Department = "HR", Salary = 45000 },
        //        new Employee { Id = 3, Name = "Alice", Department = "Finance", Salary = 55000 },
        //        new Employee { Id = 4, Name = "Bob", Department = "Marketing", Salary = 48000 }
        //    };


        //    if(Id <0||Id>employees.Count)
        //    {
        //        return NotFound($"Employee with ID {Id} not found.");
        //    }
        //    else {
        //        var employee = employees.FirstOrDefault(e => e.Id == Id);
        //        return Ok(employee);
        //    }
                
        //}




        //[HttpPost("add")]

        //public IActionResult AddEmp(Employee employee)
        //{
        //    if(employee == null)
        //    {
        //        return BadRequest("Employee data is null.");
        //    }
        //    var successMessage=$"Employee {employee.Name} added successfully with ID {employee.Id}.";
        //    return Ok(successMessage);
        //}
    }
}
