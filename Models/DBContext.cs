using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using VineYardSolutionsTask.Models;

namespace VineYardSolutionsTask.Models
{
    public class DBContext
    {
        string connection = ConfigurationManager.AppSettings["ConnectionString"];

        public List<Department> GetDepartments()
        {

            List<Department> list = new List<Department>();
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("GetDepartmentDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Department department = new Department();
                        department.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                        department.DepartmentName = Convert.ToString(dr["DepartmentName"]);
                        list.Add(department);
                    }
                }
                conn.Close();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {

            }
            
            return list;

        }


        public List<otherdepartment> GetOtherDepartments(int departmentID)
        {
            int i;
            List<otherdepartment> list = new List<otherdepartment>();
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("GetOtherdepartmentdetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentID", departmentID);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        otherdepartment department = new otherdepartment();
                        department.OtherDepartmentID = Convert.ToInt32(dr["OtherDepartmentID"]);
                        department.OtherDepartmentName = Convert.ToString(dr["OtherDepartmentName"]);
                        list.Add(department);
                    }
                }
                conn.Close();
            }
            catch (Exception ex) 
            {
                throw ex;
            }   
            finally
            {

            }
            
            return list;

        }


        public List<states> GetStatebycountryID(int countryID)
        {
            List<states> list = new List<states>();
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("getstatesbyCountryID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@countryId", countryID);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        states states = new states();
                        states.stateID = Convert.ToInt32(dr["stateID"]);
                        states.stateName = Convert.ToString(dr["stateName"]);

                        list.Add(states);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
           
            return list;

        }

        public List<countries> getCountyList()
        {
            List<countries> list = new List<countries>();
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("getcountries", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        countries countries = new countries();
                        countries.countryID = Convert.ToInt32(dr["countryID"]);
                        countries.countryName = Convert.ToString(dr["CountryName"]);
                        list.Add(countries);
                    }
                }
                conn.Close();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
            }


            return list;

        }

        public int InsertEmployeeInfo(Employee employee)
        {
            int i;
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Sp_InsertEmployeeInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", employee.Empname);
                cmd.Parameters.AddWithValue("@EmpWorkPhone", employee.WorkPhone);
                cmd.Parameters.AddWithValue("@EmpCellPhone", employee.CellPhone);
                cmd.Parameters.AddWithValue("@EmpDOB", employee.EmpDob);
                cmd.Parameters.AddWithValue("@EmpDOJ", employee.EmpDOJ);
                cmd.Parameters.AddWithValue("@EmpAge", employee.Age);
                cmd.Parameters.AddWithValue("@EmpGender", employee.Gender);
                cmd.Parameters.AddWithValue("@Empcaddress", employee.EmpCurrentAddress);
                cmd.Parameters.AddWithValue("@Emppaddress", employee.EmpPermanentAddress);
                cmd.Parameters.AddWithValue("@EmpEmail", employee.Email);
                cmd.Parameters.AddWithValue("@CountryID", employee.CountryID);
                cmd.Parameters.AddWithValue("@StateID", employee.StateID);
                cmd.Parameters.AddWithValue("@DepartmentID", employee.DepartmentId);
                cmd.Parameters.AddWithValue("@otherDepartmentID", employee.otherDepartmentId);
                cmd.Parameters.AddWithValue("@Jobtitle", employee.Jobtitle);
                conn.Open();
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            


            return i;
        }
        public int UpdateEmployeeByID(Employee employee)
        {
            int i;
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Sp_UpdateEmployeeById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@EmpName", employee.Empname);
                cmd.Parameters.AddWithValue("@EmpWorkPhone", employee.WorkPhone);
                cmd.Parameters.AddWithValue("@EmpCellPhone", employee.CellPhone);
                cmd.Parameters.AddWithValue("@EmpDOB", employee.EmpDob);
                cmd.Parameters.AddWithValue("@EmpDOJ", employee.EmpDOJ);
                cmd.Parameters.AddWithValue("@EmpAge", employee.Age);
                cmd.Parameters.AddWithValue("@EmpGender", employee.Gender);
                cmd.Parameters.AddWithValue("@Empcaddress", employee.EmpCurrentAddress);
                cmd.Parameters.AddWithValue("@Emppaddress", employee.EmpPermanentAddress);
                cmd.Parameters.AddWithValue("@EmpEmail", employee.Email);
                cmd.Parameters.AddWithValue("@CountryID", employee.CountryID);
                cmd.Parameters.AddWithValue("@StateID", employee.StateID);
                cmd.Parameters.AddWithValue("@DepartmentID", employee.DepartmentId);
                cmd.Parameters.AddWithValue("@otherDepartmentID", employee.otherDepartmentId);
                cmd.Parameters.AddWithValue("@Jobtitle", employee.Jobtitle);
                conn.Open();
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }


            return i;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Sp_GetEmployesList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeID = Convert.ToInt32(dr["EmpID"]);
                        employee.Empname = Convert.ToString(dr["EmpName"]);
                        employee.CellPhone = Convert.ToString(dr["EmpCellPhone"]);
                        employee.WorkPhone = Convert.ToString(dr["EmpWorkPhone"]);
                        employee.Email = Convert.ToString(dr["EmpEmail"]);
                        employee.EmpCurrentAddress = Convert.ToString(dr["Empcaddress"]);
                        employee.ManagerName = Convert.ToString(dr["ManagerName"]);
                        employee.Jobtitle = Convert.ToString(dr["Jobtitle"]);
                        list.Add(employee);

                    }
                }
                conn.Close();
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
            finally
            {

            }

            return list;
        }

        public List<Employee> GetEmployeeByID(int EmployeeID)
        {
            List<Employee> list = new List<Employee>();
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Sp_GetEmployeeByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", EmployeeID);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = Convert.ToInt32(dr["EmpID"]);
                    employee.Empname = Convert.ToString(dr["EmpName"]);
                    employee.CellPhone = Convert.ToString(dr["EmpCellPhone"]);
                    employee.WorkPhone = Convert.ToString(dr["EmpWorkPhone"]);
                    employee.Gender = Convert.ToString(dr["EmpGender"]);
                    employee.Email = Convert.ToString(dr["EmpEmail"]);
                    employee.CountryID = Convert.ToInt32(dr["CountryID"]);
                    employee.StateID = Convert.ToInt32(dr["StateID"]);
                    employee.EmpCurrentAddress = Convert.ToString(dr["Empcaddress"]);
                    employee.EmpPermanentAddress = Convert.ToString(dr["Emppaddress"]);
                    employee.Jobtitle = Convert.ToString(dr["Jobtitle"]);
                    employee.DepartmentId = Convert.ToInt32(dr["DepartmentID"]);
                    employee.otherDepartmentId = Convert.ToInt32(dr["otherDepartmentID"]);
                    employee.EmpDOJ = Convert.ToDateTime(dr["EmpDOJ"]);
                    employee.Age = Convert.ToInt32(dr["EmpAge"]);
                    employee.EmpDob = Convert.ToDateTime(dr["EmpDOB"]);

                    list.Add(employee);
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {


            }

            return list;
        }


        public int DeleteEmployeeByID(int EmployeeID)
        {
            int i;
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("sp_deleteEmployeeByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", EmployeeID);
                conn.Open();
                i = cmd.ExecuteNonQuery();

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
            return i;

        }


    }
}