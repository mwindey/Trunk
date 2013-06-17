using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class NationalityTranslation
    {
        public static Dictionary<Nationality, string> Translations
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


                return translations;
            }
        }
    }
}