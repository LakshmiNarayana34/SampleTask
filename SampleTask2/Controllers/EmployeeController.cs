using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleTask2.Models;

namespace SampleTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Route("EmployeeId/{id}")]
        public ActionResult<Employee> EmployeeGetById(int id)
        {
            var FetchEmployeeData = EmployeeData.Employees.FirstOrDefault(x => x.Id == id);
            if (FetchEmployeeData == null)
            {
                return NotFound();
            }
            return Ok(FetchEmployeeData);

        }

        [HttpGet("Gender/{gender}/City/{city}")]
        public ActionResult<IEnumerable<Employee>> GetByGenderAndCity([FromRoute] string gender, [FromRoute] string city) 
        {
           var filteredEmployee = EmployeeData.Employees.Where(e => e.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) && 
                                              e.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!filteredEmployee.Any())
            {
                return NotFound($"No Employee Found with Gender {gender} and with this city {city}");
            }
            return Ok(filteredEmployee);
        }
        //ex/https://localhost:7134/api/Employee/Search?Department=hr
        [HttpGet("Search")]
        public ActionResult<Employee> GetEmployeeByQuery([FromQuery] string Department)
        {
           var FilteredEmployees = EmployeeData.Employees.Where(e => e.Department.Equals(Department, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!FilteredEmployees.Any())
            {
                return NotFound($"no employee found by this department {Department}");
            }
            return Ok(FilteredEmployees);
        }

        //Filtering Employees by City, Gender, and Department
        [HttpGet("SearchByQuery")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetByOptionalParamater([FromQuery] string? gender, [FromQuery] string? city, [FromQuery] string? department)
        {
            var FilterdEmployees = EmployeeData.Employees.AsQueryable();
            if (!string.IsNullOrEmpty(gender))
                FilterdEmployees = FilterdEmployees.Where(x => x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase));
            if(!string.IsNullOrEmpty(city))
                FilterdEmployees = FilterdEmployees.Where(x => x.City.Equals(city, StringComparison.OrdinalIgnoreCase)); 
            if(!string.IsNullOrEmpty(department))
                FilterdEmployees = FilterdEmployees.Where(x => x.Department.Equals(department, StringComparison.OrdinalIgnoreCase));
            var result = FilterdEmployees.ToList();
            if (!result.Any())
                return NotFound("No employees match the provided search criteria.");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult GetCurrentTime()
        {
            var currentTime = DateTime.Now;
            return Ok(new { currentTime });
        }

        public static List<string> ListOfPrograms()
        {
            return EmployeeData.Employees.SelectMany(x => x.Programming).ToList();
        }



    }
}
