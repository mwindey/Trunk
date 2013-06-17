using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Definco.Models.Offer
{
    public class OutstandingBalanceInsurance
    {
        public List<Person> Persons { get; set; }
        [Required(ErrorMessage="Voornaam aanvrager is verplicht")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Achternaam aanvrager is verplicht")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public Decimal ToInsureCapitalPerPerson { get; set; }
        public PaybackMethod PaybackMethod { get; set; }
        public int LoanDuration { get; set; }
        public RateRevisabilityType RateRevisabilityType { get; set; }
        public decimal CurrentInterestRate { get; set; }
    }
}