using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class NationalityList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<Nationality, string>()
                {
                    { Nationality.Belgium, "België" },
                    { Nationality.France, "Frankrijk" },
                    { Nationality.Germany, "Duitsland" },
                    { Nationality.Luxembourg, "Luxemburg" },
                    { Nationality.Netherlands, "Nederland" }
                };


                return Enum.GetValues(typeof(Nationality))
                    .AsQueryable()
                    .Cast<Nationality>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = NationalityTranslation.Translations[b] });
            }
        }
    }
}