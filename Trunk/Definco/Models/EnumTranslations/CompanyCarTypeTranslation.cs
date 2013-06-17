using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class CompanyCarTypeTranslation
    {
        public static Dictionary<CompanyCarType, string> Translations
        {
            get
            {
                var translations = new Dictionary<CompanyCarType, string>()
                {
                    { CompanyCarType.Limited, "Beperkt gebruik / woon-werk verkeer" },
                    { CompanyCarType.ProfessionalUse, "Firmawagen, beroepsgebruik" },
                    { CompanyCarType.UnProfessionalUse, "Firmawagen, geen beroepsgebruik" }
                };


                return translations;
            }
        }
    }
}