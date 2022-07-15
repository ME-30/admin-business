using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace WebApplication7.BL.Halper
{
    public static class uploadFilesHelper
    {
        public static string SaveFile(IFormFile FileUrl ,String FolderPath)
        {
            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderPath;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName) ;

            // Mare Directory with File Name
            string FinalPath = Path.Combine(FilePath , FileName);

            using (var streem = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(streem);
            }
            return FileName ;

            

        }

        public static void RemoveFile(string FolderName , string FileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() +"/wwwroot/Files/" + FolderName + FileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + FileName);
            }
        }

        //public static string UpdateFile( string)
        //{

        //    if (file != null)
        //    {
        //        var location = Server.MapPath("~/App_Data/upload");

        //        //Delete existing file
        //        if (!string.IsNullOrEmpty(currentupdown.upload))
        //        {
        //            var existingFile = Path.Combine(location, currentupdown.upload);
        //            if (System.IO.File.Exists(existingFile))
        //            {
        //                System.IO.File.Delete(existingFile);
        //            }
        //        }

        //        var fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
        //        var path = Path.Combine(location, fileName);
        //        file.SaveAs(path);
        //        currentupdown.upload = fileName;   // Update to the new file name
        //    }

        //    currentupdown.keterangan = viewModel.keterangan;





        //    return " ";
        //}
    }
}
