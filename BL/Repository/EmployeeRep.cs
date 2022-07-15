using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Interface;
using WebApplication7.DAL.Database;
using WebApplication7.Models;
using WebApplication7.DAL.Entities;
using WebApplication7.BL.Halper;
using System.IO;

namespace WebApplication7.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public EmployeeRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public IQueryable<EmployeeVM> Get()
        {
            IQueryable<EmployeeVM> data = GetAllEmps();
            return data;
        }


        public EmployeeVM GetById(int id)
        {
            EmployeeVM data = GetEmployeeByID(id);
            return data;
        }


        public void Add(EmployeeVM emp)
        {
            // Mapping
            var data = mapper.Map<Employee>(emp);
            data.PhotoName  = uploadFilesHelper.SaveFile(emp.photoUrl, "photes/");
            data.CvName = uploadFilesHelper.SaveFile(emp.CvUrl, "docs/");

            db.Employee.Add(data);
            db.SaveChanges();
        }

        public void Edit(EmployeeVM emp)
        {
            // Mapping
            var data = mapper.Map<Employee>(emp);

            //var empcv = emp.CvName;
            //if (empcv == null)
            //{
            //    var location = uploadFilesHelper.SaveFile(   emp.CvUrl, "docs/");

            //    //Delete existing file
            //    if (!string.IsNullOrEmpty(emp.CvUrl.Name))
            //    {
            //         static void RemoveFile(string FolderName, string FileName)
            //        {
            //            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + FileName))
            //            {
            //                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + FileName);
            //            }
            //        }
            //    }

            //    string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/docs/" ;

            //    // Get File Name
            //    string FileName = Guid.NewGuid() + Path.GetFileName(data.CvName);

            //    // Mare Directory with File Name
            //    string FinalPath = Path.Combine(FilePath, FileName);

            //    //using (var streem = new FileStream(FinalPath, FileMode.Create))
            //    //{
            //    //    location.CopyTo(streem);
            //    //}


            //    //var fileName = Guid.NewGuid() + Path.GetFileName(empcv.FileName);
            //    //var path = Path.Combine(location, fileName);
            //    //empcv.CopyTo(path);

            //    //empcv.SaveAs(path);
            //    data.CvName = FileName;   // Update to the new file name
            //}

            ////data.keterangan = viewModel.keterangan;





            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var DeletedObject = db.Employee.Find(id);
            db.Employee.Remove(DeletedObject);
            uploadFilesHelper.RemoveFile("photos/", DeletedObject.PhotoName);
            uploadFilesHelper.RemoveFile("docs/", DeletedObject.CvName);
            db.SaveChanges();
        }



        // Refactor
        private EmployeeVM GetEmployeeByID(int id)
        {
            return db.Employee.Where(a => a.Id == id)
                                    .Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Salary = a.Salary, Address = a.Address, HireDate = a.HireDate, IsActive = a.IsActive, Email = a.Email,
                                        Notes = a.Notes, DepartmentName = a.Department.DepartmentName , DepartmentId = a.DepartmentId , PhotoName =a.PhotoName ,CvName = a.CvName })
                                    .FirstOrDefault();
        }

        private IQueryable<EmployeeVM> GetAllEmps()
        {
            return db.Employee
                       .Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Salary = a.Salary, Address = a.Address, HireDate = a.HireDate, IsActive = a.IsActive,
                           Email = a.Email, Notes = a.Notes, DepartmentName = a.Department.DepartmentName , DepartmentId = a.DepartmentId, PhotoName = a.PhotoName, CvName = a.CvName });
        }
    }
}
