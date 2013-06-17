using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class PaybackMethodTranslation
    {
        public static Dictionary<PaybackMethod, string> Translations
        {
            get
            {
                var translations = new Dictionary<PaybackMethod, string>()
                {
                    { PaybackMethod.FixedMonthlyRepayment, "Vaste maandaflossingen" },
                    { PaybackMethod.FixedCapitalRepayment, "Vaste kapitaalaflossingen" }
                };


                return translations;
            }
        }
    }
}