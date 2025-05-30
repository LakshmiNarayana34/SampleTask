using System.ComponentModel.DataAnnotations;

namespace SampleTask.Model
{
    public class EmployeeData
    {
        [Key]
        public int EmpId {  get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
    }
}
