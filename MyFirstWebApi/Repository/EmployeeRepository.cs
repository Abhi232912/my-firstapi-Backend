using Microsoft.EntityFrameworkCore;
using MyFirstWebApi.Model;

namespace MyFirstWebApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Employee>> GetAll()
        {
            var allemp = await _dbContext.Employees.ToListAsync();
            return allemp;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }

        public async Task<Employee> AddEmp(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateEmp( Employee employee)
        {


            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteEmp(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
