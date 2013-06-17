using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Definco.Models
{
    public class APRmodel
    {
        [Required]
        [Display(Name = "Hoofdbedrag")]
        public double Principal { get; set; }
        [Required]
        [Display(Name = "Interestpercentage")]
        public double InterestPerc { get; set; }
        [Required]
        [Display(Name = "Aantal jaar")]
        public int Years { get; set; }

        [Display(Name = "Aantal maanden af te betalen")]
        public string MonthsToPay { get; set; }
        [Display(Name = "Maandelijks bedrag")]
        public string MonthlyPay { get; set; }
        [Display(Name = "Totaal bedrag")]
        public string TotalPay { get; set; }

        public bool IsCalculated { get; set; }

        public APRmodel()
        {
            IsCalculated = false;
        }


    }
}
