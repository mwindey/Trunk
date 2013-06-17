using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class BreakdownAssistanceList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<BreakdownAssistance, string>()
                {
                    { BreakdownAssistance.None, "Niet nodig" },
                    { BreakdownAssistance.Domestic, "Ja, formule Binnenland" },
                    { BreakdownAssistance.DomesticAndForeign, "Ja, formule Binnenland en Buitenland" }
                };


                return Enum.GetValues(typeof(BreakdownAssistance))
                    .AsQueryable()
                    .Cast<BreakdownAssistance>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = BreakdownAssistanceTranslation.Translations[b] });
            }
        }
    }
}