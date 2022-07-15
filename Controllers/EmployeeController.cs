using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Interface;
using WebApplication7.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using WebApplication7.BL.Halper;

namespace WebApplication7.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;

        public EmployeeController(IEmployeeRep employee , IDepartmentRep department)
        {
            this.employee = employee;
            this.department = department;
        }

        public IActionResult Index()
        {

            var data = employee.Get();

            return View(data);
        }


        public IActionResult Create()
        {

            var data = department.Get();

            ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    employee.Add(emp);
                    return RedirectToAction("Index", "Employee");
                }

                var data = department.Get();

                ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }


        }

        public IActionResult Edit(int id)
        {
            var data = employee.GetById(id);

            ViewBag.Deptdata = department.Get();

            //ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", 1);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (emp.CvUrl != null && emp.photoUrl != null)
                    //{
                    //    uploadFilesHelper.RemoveFile("docs/", emp.CvName);
                    //    emp.CvName = uploadFilesHelper.SaveFile(emp.CvUrl, "docs/");

                    //    uploadFilesHelper.RemoveFile("photos/", emp.PhotoName);
                    //    emp.PhotoName = uploadFilesHelper.SaveFile(emp.photoUrl, "photes/");
                    //}
                    employee.Edit(emp);
                    return RedirectToAction("Index", "Employee");
                }

                var Deptdata = department.Get();

                ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", emp.DepartmentId);

                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }
        }


        public IActionResult Delete(int id)
        {
            var data = employee.GetById(id);
            //if(data == null)
            //{

            //}

            var Dptdata = department.Get();
            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "DepartmentName", data.DepartmentId);

            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                employee.Delete(id);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }
        }

        public IActionResult Details(int id)
        {
            var data = employee.GetById(id);
            var Dptdata = department.Get();
          

            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "DepartmentName", data.DepartmentId);

            return View(data);
        }
    }
}
