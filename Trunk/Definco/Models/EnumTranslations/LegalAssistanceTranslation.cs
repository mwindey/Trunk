using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class LegalAssistanceTranslation
    {
        public static new Dictionary<LegalAssistance, string> Translations
        {
            get
            {
                var translations = new Dictionary<LegalAssistance, string>()
                {
                    { LegalAssistance.None, "Neen, niet nodig" },
                    { LegalAssistance.Basic, "Ja, mini of basisformule" },
                    { LegalAssistance.Extensive, "Ja, uitgebreide rechtsbijstand" }
                };


                return translations;
            }
        }
    }
}