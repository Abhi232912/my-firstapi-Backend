using Microsoft.EntityFrameworkCore;
using MyFirstWebApi.Model;
using MyFirstWebApi.Repository;

namespace MyFirstWebApi.Services
{
    public class EmployeeService : IEmployeeService, IAuthService
    {
        //public readonly AppDbContext _context;
        public readonly IEmployeeRepository _repo;
        public readonly IAuthService _authService;  
        public EmployeeService(/*AppDbContext appDbContext,*/IEmployeeRepository repo, IAuthService authService)
        {
            //_context = appDbContext;
            _repo = repo;
            _authService = authService;
        }
        public string Login(LoginDto loginDto)
        {
            // Real - time lo ikkada Database check chestham
            // Example: var user = _repo.GetUser(loginDto.Username, loginDto.Password);

            if(loginDto.Username=="Abhiram" && loginDto.Password == "Admin@123")
            {
                return _authService.GenerateJWTToken(loginDto.Username);
            }

            return null; // Login fail ayithe null
        }


        public async Task<List<EmployeeDTO>> GetAll()
        {
            var allemp = await _repo.GetAll();


            var employeesdtos= allemp.Select(e =>new EmployeeDTO
            {
                Id=e.Id,
                Name=e.Name,
                Department=e.Department
            }).ToList();

            return employeesdtos;
        }

        public async Task<EmployeeDTO> AddEmp(EmployeeDTO employeedto)
        {

            var employee = new Employee
            {

                Name = employeedto.Name,
                Department = employeedto.Department,
                Salary = 0
            };

            var addEmployee = await _repo.AddEmp(employee);
            employeedto.Id = addEmployee.Id;
            return employeedto;
        }

        public async Task<Employee> UpdateEmp(int id, Employee updatedData)
        {
            var empexisting = await _repo.GetById(id);
            if (empexisting == null)
            {
                return null;
            }

            empexisting.Name = updatedData.Name;
            empexisting.Department = updatedData.Department;
            empexisting.Salary = updatedData.Salary;
            
            await _repo.UpdateEmp(empexisting);
            return empexisting;
        }


        public async Task<Employee> GetEmpById(int id)
        {
            var emp = await _repo.GetById(id);
            if (emp == null)
            {
                return null;
            }

            return emp;
        }

        public async Task<bool> DleteEmp(int id)
        {
            var emp = await _repo.GetById(id);

            if (emp == null)
            {
                return false;
            }
            await _repo.DeleteEmp(emp);
            
            return true;
        }

        public string GenerateJWTToken(string username)
        {
            throw new NotImplementedException();
        }





        //public List<Employee> GetAll()
        //{
        //   var employees = new List<Employee>
        //    {
        //        new Employee { Id = 1, Name = "Abhiram", Department = "IT", Salary = 50000 },
        //        new Employee { Id = 2, Name = "John", Department = "HR", Salary = 45000 },
        //        new Employee { Id = 3, Name = "Alice", Department = "Finance", Salary = 55000 },
        //        new Employee { Id = 4, Name = "Bob", Department = "Marketing", Salary = 48000 }
        //    };


        //    return (employees);
        //}
    }
}
