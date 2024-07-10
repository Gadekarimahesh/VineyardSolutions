using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VineYardSolutionsTask.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Enter Employee Name")]
        public string Empname { get; set; }
        [Required(ErrorMessage = "Enter current Address")]
        public string EmpCurrentAddress { get; set; }
        [Required(ErrorMessage = "Enter permanent Address")]
        public string EmpPermanentAddress { get; set; }
        [Required(ErrorMessage = "Select Date of Birth")]
        public DateTime EmpDob { get; set; }
        [Required(ErrorMessage = "Select Date of joining")]
        public DateTime EmpDOJ { get; set; }

        [Required(ErrorMessage = "Select Country")]
        public int CountryID { get; set; }
        [Required(ErrorMessage = "Select State")]
        public int StateID { get; set; }

        [Required(ErrorMessage = "Enter JobTitle")]
        public string Jobtitle { get; set; }
        [Required(ErrorMessage = "Enter Work Phone Number")]
        public string WorkPhone { get; set; }
        [Required(ErrorMessage = "Enter Cell Phone Number")]
        public string CellPhone { get; set; }
        [Required(ErrorMessage = "Select Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Select Other Department")]
        public int otherDepartmentId { get; set; }

        [Required(ErrorMessage = "Enter Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Select State")]
        public string Gender { get; set; }
        public string ManagerName { get; set; }
    }

    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }

    }
    public class otherdepartment
    {
        public int OtherDepartmentID { get; set; }
        public string OtherDepartmentName { get; set; }
        public int DepartmentID { get; set; }

    }
    public class states
    {
        public int stateID { get; set; }
        public string stateName { get; set; }
        public int CountryID { get; set; }

    }
    public class countries
    {
        public int countryID { get; set; }
        public string countryName { get; set; }
    }
}