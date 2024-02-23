using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SystemSmallSoft.Models;
using System.Net;
using System.Net.Mail;


namespace SystemSmallSoft.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SystemSmallSoft.Models.gmail model)
        {
            MailMessage mm = new MailMessage("itsktyu.mk@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp@gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("itsktyu.mk@gmail.com","ejemplo");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "e-mail enviado";

            return View();
        }
    }
}