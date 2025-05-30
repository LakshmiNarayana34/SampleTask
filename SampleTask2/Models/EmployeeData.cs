namespace SampleTask2.Models
{
    public static class EmployeeData
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice Johnson", Gender = "Female", Department = "HR", City = "New York", Programming = new List<string>{"python","java","dot net","fullstack"} },
            new Employee { Id = 2, Name = "Bob Smith", Gender = "Male", Department = "IT", City = "Los Angeles" ,Programming = new List<string>{"linux","unix","dot net","fullstack"}},
            new Employee { Id = 3, Name = "Charlie Davis", Gender = "Male", Department = "Finance", City = "Chicago" ,Programming = new List<string>{"linux","unix","dot net","fullstack"}},
            new Employee { Id = 4, Name = "Sara Taylor", Gender = "Female", Department = "HR", City = "Los Angeles",Programming = new List<string>{"linux","unix","dot net","fullstack"} },
            new Employee { Id = 5, Name = "James Smith", Gender = "Male", Department = "IT", City = "Chicago",Programming = new List<string>{"linux","unix","dot net","fullstack"} },
            // Add more employees as needed

        };

    }
}
