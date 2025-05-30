namespace SampleTask2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string City { get; set; }

        public List<string> Programming {  get; set; }
    }
}
