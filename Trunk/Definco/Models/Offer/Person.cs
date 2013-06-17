using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Definco.Models.Offer
{
    public class Person
    {
        [Required(ErrorMessage="Voornaam is verplicht")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Achternaam is verplicht")]
        public string LastName { get; set; }
        public Profession Profession { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        [Required(ErrorMessage="Geboortedatum is verplicht")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Geslacht is verplicht")]
        public Sex Sex { get; set; }
        public bool Smoker { get; set; }
        public bool SmallRisksInsuredByHealthInsurance { get; set; }
    }
}