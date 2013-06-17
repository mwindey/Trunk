using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class RateRevisabilityTypeList
    {
        public static IEnumerable<SelectListItem> Items
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


                return Enum.GetValues(typeof(RateRevisabilityType))
                    .AsQueryable()
                    .Cast<RateRevisabilityType>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = RateRevisabilityTypeTranslation.Translations[b] });
            }
        }
    }
}