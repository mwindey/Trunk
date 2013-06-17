using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class PaybackMethodList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<PaybackMethod, string>()
                {
                    { PaybackMethod.FixedMonthlyRepayment, "Vaste maandaflossingen" },
                    { PaybackMethod.FixedCapitalRepayment, "Vaste kapitaalaflossingen" }
                };


                return Enum.GetValues(typeof(PaybackMethod))
                    .AsQueryable()
                    .Cast<PaybackMethod>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = PaybackMethodTranslation.Translations[b] });
            }
        }
    }
}