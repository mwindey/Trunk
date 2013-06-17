using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class MileageTranslation
    {
        public static Dictionary<Mileage, string> Translations
        {
            get
            {
                var translations = new Dictionary<Mileage, string>()
                {
                    { Mileage.Unknown, "Weet ik niet" },
                    { Mileage.LessThanTenThousand, "Minder dan 10 000" },
                    { Mileage.MoreThanTenThousand, "Meer dan 10 000" }
                };


                return translations;
            }
        }
    }
}