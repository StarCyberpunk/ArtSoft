using Artsofte.Models;
using Artsofte.Models.ViewModels;

namespace Artsofte.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> spGetAllEmployees();
        Task<EmployeeViewModel> spGetEmployee(Guid id);
        Task<bool> spUpdateEmployee(EmployeeViewModel ew);
        Task<bool> spAddEmployee(EmployeeViewModel ew);
        Task<bool> spDeleteEmployee(Guid id);
    }
}
