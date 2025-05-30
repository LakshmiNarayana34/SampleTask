using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleTask.Data;
using SampleTask.Dtos;
using SampleTask.Model;

namespace SampleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmpDbContext _dbcontext;

        public EmployeeController(EmpDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {

                var emp = await _dbcontext.employess.ToListAsync();
                //Map Domain Models to DTOs
                var empsDto = new List<EmpDto>();

                foreach (var EmpData in emp)
                {


                    empsDto.Add(new EmpDto()
                    {
                        EmpId = EmpData.EmpId,
                        Name = EmpData.Name,
                        Role = EmpData.Role,
                        Salary = EmpData.Salary,
                        Address = EmpData.Address

                    });
                };

                return Ok(empsDto);

            }
            catch (Exception ex)
            { 
              return BadRequest(ex.Message);
            
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmp([FromBody] EmpCreateDto empCreateDto)
        {
            var empData = new EmployeeData()
            {
                Name = empCreateDto.Name,
                Role = empCreateDto.Role,
                Salary = empCreateDto.Salary,
                Address = empCreateDto.Address
            };

            await _dbcontext.employess.AddAsync(empData);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmp([FromRoute] int id,EmpCreateDto empCreateDto)
        {
           var matchData = await _dbcontext.employess.FirstOrDefaultAsync(x => x.EmpId == id);
            if (matchData == null)
            {
                return BadRequest();
            }
            matchData.Name = empCreateDto.Name;
            matchData.Role = empCreateDto.Role;
            matchData.Salary = empCreateDto.Salary;
            matchData.Address = empCreateDto.Address;

            return Ok(matchData);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmp([FromRoute] int id)
        {
            var findEmp = await _dbcontext.employess.FirstOrDefaultAsync(x => x.EmpId == id);
            _dbcontext.employess.Remove(findEmp);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
    }
}
