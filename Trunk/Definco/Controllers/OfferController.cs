using Definco.Models.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Extensions;
using System.Text;
using System.Net.Mail;
using Definco.Models.EnumTranslations;

namespace Definco.Controllers
{
    public class OfferController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CarInsurance()
        {
            return View(new CarInsurance());
        }

        [HttpPost]
        public ActionResult CarInsurance(CarInsurance carInsuranceOffer)
        {
            if (ModelState.IsValid)
            {
                StringBuilder strBody = new StringBuilder();

                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverFirstName), carInsuranceOffer.DriverFirstName));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverName), carInsuranceOffer.DriverName));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverAddress), carInsuranceOffer.DriverAddress));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverHomeNumber), carInsuranceOffer.DriverHomeNumber));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverZipCode), carInsuranceOffer.DriverZipCode));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverCity), carInsuranceOffer.DriverCity));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverEmail), carInsuranceOffer.DriverEmail));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverTelephone), carInsuranceOffer.DriverTelephone));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverBirthDate), carInsuranceOffer.DriverBirthDate));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.IsCivilServant), carInsuranceOffer.IsCivilServant ? "Ja" : "Nee"));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.Profession), ProfessionTranslation.Translations[carInsuranceOffer.Profession]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.MaritalStatus), MaritalStatusTranslations.Translations[carInsuranceOffer.MaritalStatus]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.Nationality), NationalityTranslation.Translations[carInsuranceOffer.Nationality]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.PersonBirthDate), carInsuranceOffer.PersonBirthDate));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverLicenseReleaseDate), carInsuranceOffer.DriverLicenseReleaseDate));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.Sex), SexTranslation.Translations[carInsuranceOffer.Sex]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.VehicleCylinderContent), carInsuranceOffer.VehicleCylinderContent));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.VehicleType), VehicleTypeTranslation.Translations[carInsuranceOffer.VehicleType]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.VehiclePower), carInsuranceOffer.VehiclePower));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.FourByFour), carInsuranceOffer.FourByFour ? "Ja" : "Nee"));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.CompanyCarType), CompanyCarTypeTranslation.Translations[carInsuranceOffer.CompanyCarType]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.FuelType), FuelTypeTranslation.Translations[carInsuranceOffer.FuelType]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.Mileage), MileageTranslation.Translations[carInsuranceOffer.Mileage]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.CompulsoryCivilLiabilityCoverage), carInsuranceOffer.CompulsoryCivilLiabilityCoverage ? "Ja" : "Nee"));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.LegalAssistance), LegalAssistanceTranslation.Translations[carInsuranceOffer.LegalAssistance]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.OmniumType), OmniumTypeTranslation.Translations[carInsuranceOffer.OmniumType]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.DriverAccidents), carInsuranceOffer.DriverAccidents ? "Ja" : "Nee"));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.LegalAssistance), LegalAssistanceTranslation.Translations[carInsuranceOffer.LegalAssistance]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.InsuranceDenial), InsuranceDenialTranslation.Translations[carInsuranceOffer.InsuranceDenial]));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.CurrentBMDegree), carInsuranceOffer.CurrentBMDegree));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.NumberAccidentsInFaultFiveYears), carInsuranceOffer.NumberAccidentsInFaultFiveYears));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.NumberAccidentsInFaultThreeYears), carInsuranceOffer.NumberAccidentsInFaultThreeYears));
                strBody.AppendLine(String.Format("{0}: {1}", carInsuranceOffer.GetDisplayName(c => c.Remarks), carInsuranceOffer.Remarks));
                
                string mailrecipient = System.Configuration.ConfigurationManager.AppSettings["mailrecipient"];
                string sender = System.Configuration.ConfigurationManager.AppSettings["sender"];
                var message = new MailMessage(sender, mailrecipient)
                {
                    Subject = "Nieuwe aanvraag autoverzekering offerte",
                    Body = strBody.ToString(),
                    IsBodyHtml = false
                };

                string smtpadress = System.Configuration.ConfigurationManager.AppSettings["mailserver"];
                var client = new SmtpClient(smtpadress);
                client.Send(message);

                return View("MailSuccess");
            }

            return View(carInsuranceOffer);
        }

        [HttpGet]
        public ActionResult MotorbikeInsurance()
        {
            return View(new MotorbikeInsurance());
        }

        [HttpPost]
        public ActionResult MotorbikeInsurance(MotorbikeInsurance motorbikeInsurance)
        {
            if (ModelState.IsValid)
            {

            }
            return View(motorbikeInsurance);
        }

        public ActionResult KMOInsurance()
        {
            return View(new KMOInsurance());
        }

        [HttpPost]
        public ActionResult KMOInsurance(KMOInsurance kmoInsurance)
        {
            if (ModelState.IsValid)
            {

            }
            return View(kmoInsurance);
        }

        public ActionResult BoatingInsurance()
        {
            return View(new BoatingInsurance());
        }

        [HttpPost]
        public ActionResult BoatingInsurance(BoatingInsurance boatingInsurance)
        {
            if (ModelState.IsValid)
            {

            }
            return View(boatingInsurance);
        }


        public ActionResult OutstandingBalanceInsurance()
        {
            return View(new OutstandingBalanceInsurance());
        }

        [HttpPost]
        public ActionResult OutstandingBalanceInsurance(OutstandingBalanceInsurance outstandingBalanceInsurance)
        {
            if (ModelState.IsValid)
            {

            }
            return View(outstandingBalanceInsurance);
        }

        public ActionResult HospitalizationInsurance()
        {
            return View(new HospitalizationInsurance());
        }

        [HttpPost]
        public ActionResult HospitalizationInsurance(HospitalizationInsurance hospitalizationInsurance)
        {
            if (ModelState.IsValid)
            {

            }
            return View(hospitalizationInsurance);
        }
    }
}
