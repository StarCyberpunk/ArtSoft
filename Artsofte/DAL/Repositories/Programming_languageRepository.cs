using Artsofte.DAL.Interfaces;
using Artsofte.Models;
using System.Data.SqlClient;
using System.Data;

namespace Artsofte.DAL.Repositories
{
	public class Programming_languageRepository : IBaseRepository<Programming_language>
	{
        string connectionString = "Data Source=DESKTOP-2DP756H;Initial Catalog = Artsoft; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Task<bool> Create(Programming_language entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(Programming_language entity)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Programming_language>> Select()
		{

            List<Programming_language> lstpr = new List<Programming_language>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllProgramming_language", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Programming_language department = new Programming_language();

                    department.Id = (int)rdr["Id"];
                    department.Name = rdr["Name"].ToString();
                    


                    lstpr.Add(department);
                }
                con.Close();
            }
            return lstpr;
        }

		public Task<Programming_language> Update(Programming_language entity)
		{
			throw new NotImplementedException();
		}
	}
}
