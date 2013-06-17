using Definco.Models.Enums;
using Definco.Models.EnumTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.SelectLists
{
    public class BoatNatureList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                return Enum.GetValues(typeof(BoatNature))
                    .AsQueryable()
                    .Cast<BoatNature>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = BoatNatureTranslation.Translations[b] });
            }
        }
    }
}