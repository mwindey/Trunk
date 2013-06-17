using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class FuelTypeTranslation
    {
        public static Dictionary<FuelType, string> Translations
        {
            get
            {
                var translations = new Dictionary<FuelType, string>()
                {
                    { FuelType.Diesel, "Diesel" },
                    { FuelType.Gas, "Benzine" },
                    { FuelType.LPG, "LPG" }
                };


                return translations;
            }
        }
    }
}