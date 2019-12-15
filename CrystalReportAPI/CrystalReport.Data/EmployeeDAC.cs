using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace CrystalReport.Data
{
    public class EmployeeDAC
    {
        public int Save(Employee employee)
        {
            int result = 0;
            try
            {
                
                SqlConnection connection = DbCon.GetConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand("InsertRecord", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@DateofBirth", employee.DateofBirth);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                result = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int Delete(int id)
        {
            int result = 0;
            try
            {
                SqlConnection con = DbCon.GetConnection();
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Delete_", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }


            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int Update(Employee employee)
        {
            int result = 0;
            try
            {
                SqlConnection con = DbCon.GetConnection();
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("UpdateOne", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@DateofBirth", employee.DateofBirth);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                SqlConnection con = DbCon.GetConnection();
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("GetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(dr["Id"]);
                        employee.FirstName = Convert.ToString(dr["FirstName"]);
                        employee.LastName = Convert.ToString(dr["LastName"]);
                        employee.DateofBirth = Convert.ToDateTime(dr["DateofBirth"]);

                        employee.Salary = (float)Convert.ToDouble(dr["Salary"]);
                        employees.Add(employee);
                        
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                employees = null;
            }
            return employees;
        }

        public List<Employee> Search(int id)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                SqlConnection con = DbCon.GetConnection();
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("GetOne", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(dr["Id"]);
                        employee.FirstName = Convert.ToString(dr["FirstName"]);
                        employee.LastName = Convert.ToString(dr["LastName"]);
                        employee.DateofBirth = Convert.ToDateTime(dr["DateofBirth"]);
                        employee.Salary = (float) Convert.ToDouble(dr["Salary"]);
                        employees.Add(employee);
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                employees = null;
            }
            return employees;
        }


    }
}