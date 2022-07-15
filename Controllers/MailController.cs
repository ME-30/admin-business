using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Net.Mail;
using WebApplication7.BL.Repository;
using WebApplication7.Models;
using WebApplication7.BL.Interface;
using Microsoft.AspNetCore.Authorization;
using WebApplication7.BL.Halper;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace WebApplication7.Controllers
{
    [Authorize]

    public class MailController : Controller
    {
        private readonly IMailRep Mail;

        public MailController(IMailRep Mail)
        {
            this.Mail = Mail;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(MailVM mail)
        {
           

             
            TempData["msg"] = MailHalper.sendMail( mail);
            {
                 Mail.Add(mail); ;
            }


                return RedirectToAction("Index");

        }
        public IActionResult MailBox(MailVM mail)
        {
            var data = Mail.Get();
            return View(data);
        }
     
    }

}
