using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class RateRevisabilityTypeTranslation
    {
        public static Dictionary<RateRevisabilityType, string> Translations
        {
            get
            {
                var translations = new Dictionary<RateRevisabilityType, string>()
                {
                    { RateRevisabilityType.FixedRate, "Vaste rentevoet" },
                    { RateRevisabilityType.Yearly, "Jaarlijks 1/1/1" },
                    { RateRevisabilityType.ThreeYearly, "Driejaarlijks 3/3/3" },
                    { RateRevisabilityType.FiveYearly, "Vijfjaarlijks 5/5/5" },
                    { RateRevisabilityType.TenYearly, "Tienjaarlijks 10/5/5" },
                    { RateRevisabilityType.Other, "Andere" }
                };


                return translations;
            }
        }
    }
}