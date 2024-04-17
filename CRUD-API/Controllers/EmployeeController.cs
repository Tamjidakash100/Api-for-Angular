using CRUD_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            await _employeeRepository.AddEmployee(employee);
            return Ok();

        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var emps = await _employeeRepository.GetAllEmployee();
            return Ok(emps);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute]int Id)
        {
            var emp = await _employeeRepository.GetEmployeeById(Id);
            return Ok(emp);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]int id,[FromBody] Employee employee)
        {
            await _employeeRepository.UpdateEmployee(id, employee);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveEmployee([FromRoute]int id)
        {
            await _employeeRepository.RemoveEmployee(id);
            return Ok();
        }
    }
}
