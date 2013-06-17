using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class MileageList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<Mileage, string>()
                {
                    { Mileage.Unknown, "Weet ik niet" },
                    { Mileage.LessThanTenThousand, "Minder dan 10 000" },
                    { Mileage.MoreThanTenThousand, "Meer dan 10 000" }
                };


                return Enum.GetValues(typeof(Mileage))
                    .AsQueryable()
                    .Cast<Mileage>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = MileageTranslation.Translations[b] });
            }
        }
    }
}