using InTimeOutTime.Data;
using InTimeOutTime.Dto;
using InTimeOutTime.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InTimeOutTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInTimeOutTimeController : ControllerBase
    {
        private readonly EmployeeInTimeOutTimeDbContext _dbContext;

        public EmployeeInTimeOutTimeController(EmployeeInTimeOutTimeDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmpDetails([FromBody] EmployeePartialDetails employeePartialDetails)
        {
            var empDeatils = new EmployeeTimeSheet()
            {
                EmpId = employeePartialDetails.EmpId,
                EmployeeName = employeePartialDetails.EmployeeName,
                Date = DateTime.Today
            };
            await _dbContext.employeeTimeSheets.AddAsync(empDeatils);
            await _dbContext.SaveChangesAsync();
            return Ok(empDeatils);

        }

        [HttpPost("InTime/{empId}")]
        public async Task<IActionResult> InTime([FromRoute] string empId)
        {
            

               var EmpIdFind = await _dbContext.employeeTimeSheets.FirstOrDefaultAsync(x => x.EmpId == empId && x.Date == DateTime.Today);

            
            
            if (EmpIdFind == null)
            {
                return BadRequest();
            }

            

            if (EmpIdFind.InTime.IsNullOrEmpty())
            {
                EmpIdFind.InTime = DateTime.Now.ToString("HH:mm:ss");
                await _dbContext.SaveChangesAsync();
                return Ok(EmpIdFind);
            }
            return BadRequest();
        }


        [HttpPost("OutTime/{empId}")]
        public async Task<IActionResult> OutTime([FromRoute] string empId)
        {
            var EmpIdFind = await _dbContext.employeeTimeSheets.FirstOrDefaultAsync(x => x.EmpId == empId && x.Date == DateTime.Today);
            if (EmpIdFind == null)
            {
                return BadRequest();
            }

            

                if (EmpIdFind.OutTime.IsNullOrEmpty())
                {
                EmpIdFind.OutTime = DateTime.Now.ToString("HH:mm:ss");
                await _dbContext.SaveChangesAsync();
                return Ok(EmpIdFind);
                }
            return BadRequest();

            
        }
    }
}
