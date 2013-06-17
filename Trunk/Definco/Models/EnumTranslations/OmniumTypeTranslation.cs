using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class OmniumTypeTranslation
    {
        public static Dictionary<OmniumType, string> Translations
        {
            get
            {
                var translations = new Dictionary<OmniumType, string>()
                {
                    { OmniumType.None, "Geen omnium" },
                    { OmniumType.Mini, "Mini omnium" },
                    { OmniumType.Full, "Volledige omnium" }
                };


                return translations;
            }
        }
    }
}