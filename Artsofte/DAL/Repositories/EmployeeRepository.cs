using Artsofte.DAL.Interfaces;
using Artsofte.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Artsofte.DAL.Repositories
{
    public class EmployeeRepository : IBaseRepository<Employee>
    {
       string connectionString= "Data Source=DESKTOP-2DP756H;Initial Catalog = Artsoft; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public async Task<bool> Create(Employee employee)
        {
            try { 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@surname", employee.Surname);
                cmd.Parameters.AddWithValue("@age", employee.Age);
                cmd.Parameters.AddWithValue("@gender", employee.Gender);
                cmd.Parameters.AddWithValue("@departid", employee.Department.Id);
                cmd.Parameters.AddWithValue("@prid", employee.pr_lang.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", employee.Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public async Task<List<Employee>>  Select()
        {
            List<Employee> lstemployee = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = (Guid)rdr["ID"];
                    employee.Name = rdr["Name"].ToString();
                    employee.Surname = rdr["Surname"].ToString();
                    employee.Age = (int)rdr["Age"];
                    employee.Gender = (Models.Enum.Gender)rdr["Gender"];
                    employee.Department = new Department
                    {
                        Id = (int)rdr["DepartId"],
                        Name = rdr["DepartName"].ToString(),
                        Floor = (int)rdr["DepartFloor"]

                    };
                    employee.pr_lang = new Programming_language
                    {
                        Id = (int)rdr["PrId"],
                        Name = rdr["PrName"].ToString()
                    };


                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@id", employee.Id);
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@surname", employee.Surname);
                cmd.Parameters.AddWithValue("@age", employee.Age);
                cmd.Parameters.AddWithValue("@gender", employee.Gender);
                cmd.Parameters.AddWithValue("@departid", employee.Department.Id);
                cmd.Parameters.AddWithValue("@prid", employee.pr_lang.Id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return employee;
        }
    }
}
