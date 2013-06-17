using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Definco.Models.Offer
{
    public class HospitalizationInsurance
    {
        #region . Requester Information .
        [Required(ErrorMessage = "Voornaam aanvrager is verplicht")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Achternaam aanvrager is verplicht")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Email adres is verplicht")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ongeldig emailadres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Ongeldig telefoonnummer")]
        public string Telephone { get; set; }
        #endregion

        public List<Person> Persons;

        #region . Required Guarantees .
        public DateTime StartDate { get; set; }
        public HospitalizationFormula Formula { get; set; }
        public decimal DesiredExemption { get; set; }
        #endregion

    }
}