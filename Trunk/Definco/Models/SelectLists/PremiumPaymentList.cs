using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class PremiumPaymentList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<PremiumPayment, string>()
                {
                    { PremiumPayment.ThreeMonthly, "Driemaandelijks (+ bijpremie)" },
                    { PremiumPayment.SixMonthly, "Zesmaandelijks (+ bijpremie)" },
                    { PremiumPayment.Yearly, "Jaarlijks" }
                };


                return Enum.GetValues(typeof(PremiumPayment))
                    .AsQueryable()
                    .Cast<PremiumPayment>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = PremiumPaymentTranslations.Translations[b] });
            }
        }
    }
}