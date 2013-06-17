using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class BoatNatureTranslation
    {
        public static Dictionary<BoatNature, string> Translations
        {
            get
            {
                var translations = new Dictionary<BoatNature, string>()
                {
                    { BoatNature.OpenSailboat, "Open zeilboot" },
                    { BoatNature.ClosedSailboat, "Gesloten zeilboot" },
                    { BoatNature.Motorboat, "Motorboot" }
                };
                return translations;
            }
        }
    }
}