using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Repository;
using WebApplication7.DAL.Database;
using WebApplication7.Models;
using System.Diagnostics;
using WebApplication7.BL.Interface;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication7.Controllers
{
    [Authorize]

    public class DepartmentController : Controller
    {

        private readonly IDepartmentRep department;


      
        public DepartmentController(IDepartmentRep department)
        {
            this.department = department;
        }



        public IActionResult Index()
        {

            var data = department.Get();

            return View(data);
            
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Add(dpt);
                    return RedirectToAction("Index", "Department");
                }

                return View(dpt);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);
            }


        }

        public IActionResult Edit(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Edit(dpt);
                    return RedirectToAction("Index", "Department");
                }

                return View(dpt);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);
            }
        }


        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
            //if(data == null)
            //{

            //}
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                    department.Delete(id);
                    return RedirectToAction("Index", "Department");
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
            var data = department.GetById(id);
   

            return View(data);
        }

       
      



    }
}
