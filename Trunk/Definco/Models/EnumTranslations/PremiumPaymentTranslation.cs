using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class PremiumPaymentTranslations
    {
        public static Dictionary<PremiumPayment, string> Translations
        {
            get
            {
                var translations = new Dictionary<PremiumPayment, string>()
                {
                    { PremiumPayment.ThreeMonthly, "Driemaandelijks (+ bijpremie)" },
                    { PremiumPayment.SixMonthly, "Zesmaandelijks (+ bijpremie)" },
                    { PremiumPayment.Yearly, "Jaarlijks" }
                };


                return translations;
            }
        }
    }
}