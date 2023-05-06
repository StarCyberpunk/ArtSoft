using Artsofte.DAL.Interfaces;
using Artsofte.Models;
using Artsofte.Models.ViewModels;
using Artsofte.Services.Interfaces;

namespace Artsofte.Services.Implementations
{
	public class DepartmentService : IDepartmentService
	{
        IBaseRepository<Department> _repoDe;
        public DepartmentService(IBaseRepository<Department> DeRepo)
        {
            _repoDe = DeRepo;
        }
        
        public async Task<List<string>> spGetAllDepartment()
		{
            List<string> r = new List<string>();
            var db_res = await _repoDe.Select();
            foreach(var t in db_res)
            {
                r.Add(t.Name);
            }
            return r;
        }
	}
}
