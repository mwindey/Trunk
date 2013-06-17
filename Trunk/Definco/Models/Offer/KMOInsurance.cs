using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Definco.Models.Offer
{
    public class KMOInsurance
    {
        #region . Requester Information .
        [Required(ErrorMessage="Voornaam is verplicht")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Achternaam is verplicht")]
        public string LastName { get; set; }
        [Required(ErrorMessage="Functie is verplicht")]
        public string Function { get; set; }
        #endregion

        #region . Company Information .
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyAddress { get; set; }
        public int? CompanyHomeNumber { get; set; }
        public string CompanyZipCode { get; set; }
        public string CompanyCity { get; set; }
        [Required(ErrorMessage = "Email adres is verplicht")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ongeldig emailadres")]
        public string CompanyEmail { get; set; }
        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Ongeldig telefoonnummer")]
        public string CompanyTelephone { get; set; }
        public string CompanyActivities { get; set; }
        #endregion

        #region . Requested Offers .
        public bool AccidentsAtWork { get; set; }
        public bool CL_Operation_Demise { get; set; }
        public bool CompanyVehicles { get; set; }
        public bool Hospitalization { get; set; }
        public bool GroupInsurances { get; set; }
        public bool GuaranteedIncome { get; set; }
        public bool CreditInsurance { get; set; }
        public string Other { get; set; }
        #endregion
    }
}