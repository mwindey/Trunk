using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Definco.Models.Offer
{
    public class BoatingInsurance
    {
        #region . Driver Information .
        [Required(ErrorMessage = "De voornaam is verplicht")]
        public string DriverFirstName { get; set; }
        [Required(ErrorMessage = "De achternaam is verplicht")]
        public string DriverName { get; set; }
        public string DriverAddress { get; set; }
        public int? DriverHomeNumber { get; set; }
        public string DriverZipCode { get; set; }
        public string DriverCity { get; set; }
        [Required(ErrorMessage = "Email adres is verplicht")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ongeldig emailadres")]
        public string DriverEmail { get; set; }
        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Ongeldig telefoonnummer")]
        public string DriverTelephone { get; set; }
        [Required(ErrorMessage = "Uw geboortedatum is verplicht")]
        public DateTime? DriverBirthDate { get; set; }
        public Sex Sex { get; set; }
        #endregion

        #region . Vehicle Information .
        [Required(ErrorMessage = "Merk van het vaartuig is verplicht")]
        public string VehicleMake { get; set; }
        [Required(ErrorMessage = "Model van het vaartuig is verplicht")]
        public string VehicleModel { get; set; }
        public BoatNature BoatNature { get; set; }
        [Required(ErrorMessage = "Dit veld is verplicht")]
        public DateTime? VehicleFirstUse { get; set; }
        public int? VehiclePower { get; set; }
        public int? VehicleTotalLength { get; set; }
        public string ToCoverRegion { get; set; }
        public decimal ToInsureValue { get; set; }
        public decimal ToInsureContents { get; set; }
        #endregion

        #region . Required Guarantees .
        public bool CompulsoryCivilLiabilityCoverage { get; set; }
        public bool StorageCosts { get; set; }
        public bool Hull { get; set; }
        public LegalAssistance LegalAssistance { get; set; }
        public bool BasicAccidentInsurance { get; set; }
        #endregion

    }
}