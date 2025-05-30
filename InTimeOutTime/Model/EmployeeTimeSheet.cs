using System.ComponentModel.DataAnnotations;
using System.Security;
using Microsoft.EntityFrameworkCore;

namespace InTimeOutTime.Model
{
    [PrimaryKey(nameof(EmpId),nameof(Date))]
    public class EmployeeTimeSheet
    {

        [Key]
        public string EmpId {  get; set; }
        [Key]
        public DateTime Date {  get; set; }

        
        public string EmployeeName { get; set; }

        public string? InTime {  get; set; }

        public string? OutTime {  get; set; }



    }
}
