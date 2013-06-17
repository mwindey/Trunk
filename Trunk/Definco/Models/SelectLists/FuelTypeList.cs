using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class FuelTypeList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<FuelType, string>()
                {
                    { FuelType.Diesel, "Diesel" },
                    { FuelType.Gas, "Benzine" },
                    { FuelType.LPG, "LPG" }
                };


                return Enum.GetValues(typeof(FuelType))
                    .AsQueryable()
                    .Cast<FuelType>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = FuelTypeTranslation.Translations[b] });
            }
        }
    }
}