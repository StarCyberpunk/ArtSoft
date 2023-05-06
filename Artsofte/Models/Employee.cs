using Artsofte.Models.Enum;

namespace Artsofte.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
       public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public Programming_language pr_lang { get; set; }
    }
}
