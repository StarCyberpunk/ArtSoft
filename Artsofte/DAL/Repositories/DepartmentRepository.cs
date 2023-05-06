using Artsofte.DAL.Interfaces;
using Artsofte.Models;
using System.Data.SqlClient;
using System.Data;

namespace Artsofte.DAL.Repositories
{
	public class DepartmentRepository:IBaseRepository<Department>
    {
        string connectionString = "Data Source=DESKTOP-2DP756H;Initial Catalog = Artsoft; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Task<bool> Create(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Department>> Select()
        {
            List<Department> lstdep = new List<Department>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Department department = new Department();

                    department.Id = (int)rdr["Id"];
                    department.Name = rdr["Name"].ToString();
                    department.Floor = (int)rdr["Floor"];


                    lstdep.Add(department);
                }
                con.Close();
            }
            return lstdep;
        }

        public Task<Department> Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
