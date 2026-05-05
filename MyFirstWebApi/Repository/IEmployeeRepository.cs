using MyFirstWebApi.Model;

namespace MyFirstWebApi.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();

        Task<Employee> GetById(int id);

        Task<Employee> AddEmp(Employee employee);

        Task UpdateEmp( Employee employee);

        Task DeleteEmp(Employee employee);

    }
}
