using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class SexList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<Sex, string>()
                {
                    { Sex.Man, "Man" },
                    { Sex.Woman, "Vrouw" }
                };


                return Enum.GetValues(typeof(Sex))
                    .AsQueryable()
                    .Cast<Sex>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = SexTranslation.Translations[b] });
            }
        }
    }
}