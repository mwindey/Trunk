using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class SexTranslation
    {
        public static Dictionary<Sex, string> Translations
        {
            get
            {
                var translations = new Dictionary<Sex, string>()
                {
                    { Sex.Man, "Man" },
                    { Sex.Woman, "Vrouw" }
                };


                return translations;
            }
        }
    }
}