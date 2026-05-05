using MyFirstWebApi.Model;

namespace MyFirstWebApi.Services
{
    public interface IEmployeeService
    {

        string Login(LoginDto loginDto);
        Task<List<EmployeeDTO>> GetAll();


        Task<EmployeeDTO> AddEmp(EmployeeDTO employeedto);

        Task<bool> DleteEmp(int id);

        Task<Employee> GetEmpById(int id);

        Task<Employee> UpdateEmp(int id,Employee employee);
    }
}
