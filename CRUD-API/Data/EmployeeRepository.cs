using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Data;

public class EmployeeRepository
{

    private readonly AppDBContext _db;
    public EmployeeRepository(AppDBContext db)
    {
        _db = db;
    }

    public async Task AddEmployee(Employee employee)
    {
        await _db.Employees.AddAsync(employee);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Employee>> GetAllEmployee()
    {
        return await _db.Employees.ToListAsync();
    }
    public async Task<Employee> GetEmployeeById(int id)
    {
        return await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task UpdateEmployee(int id, Employee employee)
    {
        var emp = await _db.Employees.FirstOrDefaultAsync(x=>x.Id == id);
        if (emp == null)
        {
            throw new Exception("Employee Not Found!!");
        }
        emp.Age = employee.Age;
        emp.Name = employee.Name;
        emp.Phone = employee.Phone;
        emp.Salary = employee.Salary;

         _db.Employees.Update(emp);
        await _db.SaveChangesAsync();
    }
    public async Task RemoveEmployee(int id)
    {
        var emp = await _db.Employees.FirstOrDefaultAsync(x=>x.Id==id);
        if (emp == null)
        {
            throw new Exception("Employee Not Found!!");
        }
        _db.Employees.Remove(emp);
        await _db.SaveChangesAsync();
    }

}
