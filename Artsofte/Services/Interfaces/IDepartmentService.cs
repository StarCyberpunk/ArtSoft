using Artsofte.Models;
using Artsofte.Models.ViewModels;

namespace Artsofte.Services.Interfaces
{
	public interface IDepartmentService
	{
        Task<List<string>> spGetAllDepartment();
    }
}
