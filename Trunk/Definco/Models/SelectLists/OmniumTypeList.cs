using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class OmniumTypeList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<OmniumType, string>()
                {
                    { OmniumType.None, "Geen omnium" },
                    { OmniumType.Mini, "Mini omnium" },
                    { OmniumType.Full, "Volledige omnium" }
                };


                return Enum.GetValues(typeof(OmniumType))
                    .AsQueryable()
                    .Cast<OmniumType>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = OmniumTypeTranslation.Translations[b] });
            }
        }
    }
}