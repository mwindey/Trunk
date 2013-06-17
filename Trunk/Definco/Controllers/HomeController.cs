using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Definco.Models;
using SimpleMembershipExample;

namespace Definco.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Immo()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Documents()
        {
            return View();
        }

        public ActionResult Partners()
        {
            return View();
        }


        public ActionResult Tools()
        {
            return View(new APRmodel());
        }

        [HttpPost]
        public ActionResult DirectMail(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                StringBuilder strBody = new StringBuilder();

                strBody.AppendLine("Email/telefoon: " + model.ContactMiddel);
                strBody.AppendLine("Vraag: " + model.Vraag);

                string mailrecipient = System.Configuration.ConfigurationManager.AppSettings["mailrecipient"];
                string sender = System.Configuration.ConfigurationManager.AppSettings["sender"];
                var message = new MailMessage(sender, mailrecipient)
                {
                    Subject = "Een vraag via de website !",
                    Body = strBody.ToString(),
                    IsBodyHtml = false
                };

                string smtpadress = System.Configuration.ConfigurationManager.AppSettings["mailserver"];
                var client = new SmtpClient(smtpadress);
                client.Send(message);

                return View("MailSuccess");
            }

            return View("Contact");
        }

        public ActionResult CalculateAPR(APRmodel model)
        {
            model.IsCalculated = false;
            if (ModelState.IsValid){

            GetAPR(model, model.Principal, model.InterestPerc, model.Years);
            model.IsCalculated = true;
        }
            return View("Tools", model);
        }

     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="principal">total mortgage loan</param>
        /// <param name="interestPerc">percent annual interest</param>
        /// <param name="years">years to pay</param>
        /// <returns></returns>
        private void GetAPR(APRmodel model, double principal = 0, double interestPerc = 0, int years = 0)
        {
            //monthly interest rate
            double interestRate = interestPerc / (100 * 12);

            double paymentNum = years * 12;
            model.MonthsToPay = paymentNum.ToString();

            double paymentVal = principal * (interestRate / (1 - Math.Pow((1 + interestRate), (-paymentNum))));
            model.MonthlyPay = String.Format("{0:C}", paymentVal);

            model.TotalPay = String.Format("{0:C}", paymentVal * paymentNum);
        }
    }
}
