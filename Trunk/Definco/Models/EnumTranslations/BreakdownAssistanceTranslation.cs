using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class BreakdownAssistanceTranslation
    {
        public static Dictionary<BreakdownAssistance, string> Translations
        {
            get
            {
                var translations = new Dictionary<BreakdownAssistance, string>()
                {
                    { BreakdownAssistance.None, "Niet nodig" },
                    { BreakdownAssistance.Domestic, "Ja, formule Binnenland" },
                    { BreakdownAssistance.DomesticAndForeign, "Ja, formule Binnenland en Buitenland" }
                };

                return translations;
            }
        }
    }
}