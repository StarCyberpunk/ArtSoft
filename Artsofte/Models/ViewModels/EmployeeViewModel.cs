using Artsofte.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string pr_lang { get; set; }
    }
}
