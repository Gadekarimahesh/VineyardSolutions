using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VineYardSolutionsTask.Models;




namespace VineYardSolutionsTask.Controllers
{
    public class EmployeeController : Controller
    {
        DBContext obj = new DBContext();
        public ActionResult Index()
        {
            var EmployeesList = obj.GetEmployees();
            return View(EmployeesList);
        }

        public ActionResult Details(int id)
        {
            IEnumerable<Employee> Employee = obj.GetEmployeeByID(id);
            return View(Employee);
        }

        public ActionResult Create()
        {
            ViewBag.Countrieslist = obj.getCountyList();
            ViewBag.departmentlist = obj.GetDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int i = obj.InsertEmployeeInfo(employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Countrieslist = obj.getCountyList();
                    ViewBag.departmentlist = obj.GetDepartments();
                    return View();
                }
                 
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Countrieslist = obj.getCountyList();
                ViewBag.departmentlist = obj.GetDepartments();
                IEnumerable<Employee> Employee = obj.GetEmployeeByID(id);
                foreach (var emp in Employee)
                {
                    ViewBag.OtherDepartment = obj.GetOtherDepartments(emp.DepartmentId);
                    ViewBag.StatesList = obj.GetStatebycountryID(emp.CountryID);
                }

                return View(Employee);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                int i = obj.UpdateEmployeeByID(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                int i = obj.DeleteEmployeeByID(id);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public ActionResult GetStatesByCountry(int countryId)
        {
            var states = obj.GetStatebycountryID(countryId);
            return Json(states, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getDepartmentByOtherdept(int DepartmentID)
        {
            var states = obj.GetOtherDepartments(DepartmentID);
            return Json(states, JsonRequestBehavior.AllowGet);
        }


    }
}
