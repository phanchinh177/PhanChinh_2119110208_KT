using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cau1.Model;

namespace Cau1.DAL
{
    public class EmployeeDAL : DBConnection
    {
        public List<Employee> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("selectEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            List<Employee> lstEmployee = new List<Employee>();
            EmployeeDAL employee = new EmployeeDAL();
            DepartmentDAL department = new DepartmentDAL();
            while (reader.Read())
            {
                Employee Emp = new Employee();
                Emp.IdEmployee = reader["IdEmployee"].ToString();
                Emp.Name = reader["Name"].ToString();
                Emp.DateBirth = DateTime.Parse(reader["DateBirth"].ToString());
                if (reader["Gender"].ToString() == "1")
                    Emp.Gender = true;
                else
                {
                    Emp.Gender = false;
                }
                Emp.PlaceBirth = reader["PlaceBirth"].ToString();
                Emp.Department = department.ReadArea((reader["IdDepartment"].ToString()));
                lstEmployee.Add(Emp);

            }
            conn.Close();
            return lstEmployee;
        }
        public void NewEmployee(Employee emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "NewEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.IdEmployee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emp.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = emp.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = emp.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = emp.PlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = emp.Department.IdDepartment;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Them thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                conn.Close();
            }
        }

        public void EditEmployee(Employee emp)
        {

            SqlConnection con = new SqlConnection();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EditEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = emp.IdEmployee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emp.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = emp.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = emp.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = emp.PlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = emp.Department.IdDepartment;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("Sua thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                con.Close();
            }

        }
        public void DeleteEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = 1;
                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Xoa thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
