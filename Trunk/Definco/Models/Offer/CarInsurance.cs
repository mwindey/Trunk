using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Definco.Models.Offer
{
    public class CarInsurance
    {
        #region . Driver Information .
        [Required(ErrorMessage="De voornaam van de bestuurder is verplicht")]
        [Display(Name = "Voornaam bestuurder")]
        public string DriverFirstName { get; set; }
        [Required(ErrorMessage="De achternaam van de bestuurder is verplicht")]
        [Display(Name = "Achternaam bestuurder")]
        public string DriverName { get; set; }
        [Display(Name = "Straat bestuurder")]
        public string DriverAddress { get; set; }
        [Display(Name = "Huisnummer bestuurder")]
        public int? DriverHomeNumber { get; set; }
        [Display(Name = "Postcode bestuurder")]
        public string DriverZipCode { get; set; }
        [Display(Name = "Stad/Gemeente bestuurder")]
        public string DriverCity { get; set; }
        [Required(ErrorMessage="Email adres is verplicht")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ongeldig emailadres")]
        [Display(Name = "Email")]
        public string DriverEmail { get; set; }
        [Required(ErrorMessage="Telefoonnummer is verplicht")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Ongeldig telefoonnummer")]
        [Display(Name = "Telefoon")]
        public string DriverTelephone { get; set; }
        [Required(ErrorMessage="De geboortedatum van de bestuurder is verplicht")]
        [Display(Name = "Geboortedatum bestuurder")]
        public DateTime? DriverBirthDate { get; set; }
        [Display(Name = "Ambtenaar")]
        public bool IsCivilServant { get; set; }
        [Display(Name = "Beroep")]
        public Profession Profession { get; set; }
        [Display(Name = "Burgelijke stand")]
        public MaritalStatus MaritalStatus { get; set; }
        [Required(ErrorMessage="Uw nationaliteit is verplicht")]
        [Display(Name = "Nationaliteit")]
        public Nationality Nationality { get; set; }
        [Display(Name = "Uw geboortedatum")]
        public DateTime? PersonBirthDate { get; set; }
        [Display(Name = "Datum afgifte rijbewijs")]
        public DateTime? DriverLicenseReleaseDate { get; set; }
        [Display(Name = "Geslacht")]
        public Sex Sex { get; set; }
        #endregion

        #region . Vehicle Information .
        [Required(ErrorMessage="Merk van het voertuig is verplicht")]
        [Display(Name = "Merk")]
        public string VehicleMake { get; set; }
        [Required(ErrorMessage="Model van het voertuig is verplicht")]
        [Display(Name = "Model")]
        public string VehicleModel { get; set; }
        [Display(Name = "Cylinderinhoud in CC")]
        public int? VehicleCylinderContent { get; set; }
        [Display(Name = "Voertuig ingeschreven als")]
        public VehicleType VehicleType { get; set; }
        [Display(Name = "Vermogen in KW")]
        public int? VehiclePower { get; set; }
        [Display(Name = "4x4")]
        public bool FourByFour { get; set; }
        [Display(Name = "Firmawagen")]
        public CompanyCarType CompanyCarType { get; set; }
        [Display(Name = "Brandstof")]
        public FuelType FuelType { get; set; }
        [Display(Name = "Aantal kilometers per jaar")]
        public Mileage Mileage { get; set; }
        [Display(Name = "Datum eerste ingebruikname")]
        public DateTime? VehicleFirstUse { get; set; }
        #endregion

        #region  . Required Guarantees .
        [Display(Name = "Verplichte dekking burgelijke aansprakelijkheid")]
        public bool CompulsoryCivilLiabilityCoverage { get; set; }
        [Display(Name = "Rechtsbijstand")]
        public LegalAssistance LegalAssistance { get; set; }
        [Display(Name = "Dekking omnium / eigen schade")]
        public OmniumType OmniumType { get; set; }
        [Display(Name = "Ongevallen bestuurder")]
        public bool DriverAccidents { get; set; }
        [Display(Name = "Bijstand (pechverhelping)")]
        public BreakdownAssistance BreakdownAssistance { get; set; }
        [Display(Name = "Gewenste premiebetaling")]
        public PremiumPayment PremiumPayment { get; set; }
        #endregion

        #region . Additional Information .
        [Display(Name = "Bent u reeds opgezegd of geweigerd geweest door een verzekeringsmaatschappij voor een een autoverzekering?")]
        public InsuranceDenial InsuranceDenial { get; set; }
        [Required(ErrorMessage = "Huidige BM graad is verplicht")]
        [Display(Name = "Uw huidige / laatst gekende BM graad")]
        public int? CurrentBMDegree { get; set; }
        [Display(Name = "Aantal ongevallen in fout laatste 5 jaar")]
        public int? NumberAccidentsInFaultFiveYears { get; set; }
        [Display(Name = "Aantal ongevallen in fout laatste 3 jaar")]
        public int? NumberAccidentsInFaultThreeYears { get; set; }
        [Display(Name = "Opmerkingen")]
        public string Remarks { get; set; }

        public IEnumerable<int> BMDegrees { get { return Enumerable.Range(-2, 17); } }
        #endregion

    }
}