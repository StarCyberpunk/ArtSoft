using Artsofte.DAL.Interfaces;
using Artsofte.Models;
using Artsofte.Models.Enum;
using Artsofte.Models.ViewModels;
using Artsofte.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Artsofte.Services.Implementations
{
    public class EmployeeService:IEmployeeService
    {
        IBaseRepository<Employee> _repoEm;
        IBaseRepository<Department> _repoDe;
        IBaseRepository<Programming_language> _repoPr;
        public EmployeeService(IBaseRepository<Employee> empRepo, IBaseRepository<Department> DeRepo, IBaseRepository<Programming_language> DeRep)
        {
            _repoEm = empRepo;
            _repoDe = DeRepo;
            _repoPr = DeRep;
        }
        public async Task<List<EmployeeViewModel>> spGetAllEmployees()
        {
            List < EmployeeViewModel > res= new List<EmployeeViewModel>();
            var db_res=await _repoEm.Select();
            foreach(Employee e in db_res)
            {
                EmployeeViewModel a = new EmployeeViewModel
                {
                    Id=e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Department = e.Department.Name,
                    pr_lang = e.pr_lang.Name,
                    Gender = e.Gender.ToString(),
                    Surname = e.Surname
                };
                res.Add(a);
            }

            return res;
        }

        public async Task<EmployeeViewModel> spGetEmployee(Guid id)
        {
            EmployeeViewModel res = new EmployeeViewModel();
            var db_res = await _repoEm.Select();
            foreach (Employee e in db_res)
            {
                if (e.Id == id)
                {
                EmployeeViewModel a = new EmployeeViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Department = e.Department.Name,
                    pr_lang = e.pr_lang.Name,
                    Gender = e.Gender.ToString(),
                    Surname = e.Surname
                };
                    return a;
                }
                
            }

            return res;
        }

        public async Task<bool> spUpdateEmployee(EmployeeViewModel ew)
        {
            try { 
            var t=await _repoDe.Select();
          Department d=  t.Select(x => x).Where(x => x.Name == ew.Department).FirstOrDefault();
            var tt = await _repoPr.Select();
            Programming_language pr = tt.Select(x => x).Where(x => x.Name == ew.pr_lang).FirstOrDefault();
            Employee r = new Employee
            {
                Id = ew.Id,
                Name = ew.Name,
                Surname = ew.Surname,
                Age = ew.Age,
                Department = d,
                pr_lang=pr,
                Gender= (Gender)Enum.Parse(typeof(Gender),ew.Gender)
                
            };
            
            await _repoEm.Update(r);
            return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public async Task<bool> spAddEmployee(EmployeeViewModel ew)
        {
            try { 
            var t = await _repoDe.Select();
            Department d = t.Select(x => x).Where(x => x.Name == ew.Department).FirstOrDefault();
            var tt = await _repoPr.Select();
            Programming_language pr = tt.Select(x => x).Where(x => x.Name == ew.pr_lang).FirstOrDefault();
            Employee r = new Employee
            {
                Id = Guid.NewGuid(),
                Name = ew.Name,
                Surname = ew.Surname,
                Age = ew.Age,
                Department = d,
                pr_lang = pr,
                Gender = (Gender)Enum.Parse(typeof(Gender), ew.Gender)

            };
            await _repoEm.Create(r);
            return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> spDeleteEmployee(Guid id)
        {
            try
            {

            
            var t = await _repoEm.Select();
            Employee e = t.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
            await _repoEm.Delete(e);
            return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
