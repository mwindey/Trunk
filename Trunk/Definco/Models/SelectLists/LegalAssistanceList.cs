using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class LegalAssistanceList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<LegalAssistance, string>()
                {
                    { LegalAssistance.None, "Neen, niet nodig" },
                    { LegalAssistance.Basic, "Ja, mini of basisformule" },
                    { LegalAssistance.Extensive, "Ja, uitgebreide rechtsbijstand" }
                };


                return Enum.GetValues(typeof(LegalAssistance))
                    .AsQueryable()
                    .Cast<LegalAssistance>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = LegalAssistanceTranslation.Translations[b] });
            }
        }
    }
}