using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Definco.Models.Offer
{
    public class MotorbikeInsurance
    {
        #region . Driver Information .
        [Required(ErrorMessage = "De voornaam van de bestuurder is verplicht")]
        public string DriverFirstName { get; set; }
        [Required(ErrorMessage = "De achternaam van de bestuurder is verplicht")]
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
        [Required(ErrorMessage = "Merk van het voertuig is verplicht")]
        public string VehicleMake { get; set; }
        [Required(ErrorMessage = "Model van het voertuig is verplicht")]
        public string VehicleModel { get; set; }
        public int? VehicleCylinderContent { get; set; }
        public int? VehiclePower { get; set; }
        [Required(ErrorMessage="Dit veld is verplicht")]
        public DateTime? VehicleFirstUse { get; set; }
        [Required(ErrorMessage="Aanvangsdatum is verplicht")]
        public DateTime? StartDate { get; set; }
        #endregion

        #region . Required Guarantees .
        public bool CompulsoryCivilLiabilityCoverage { get; set; }
        public LegalAssistance LegalAssistance { get; set; }
        public bool BasicAccidentInsurance { get; set; }
        #endregion

        #region . Additional Information .
        public bool VehicleAlreadyInsured { get; set; }
        public string InsuranceCompany { get; set; }
        public string PolisNumber { get; set; }
        public InsuranceDenial InsuranceDenial { get; set; }
        public bool MotorbikeCarCombination { get; set; }
        #endregion

    }
}