using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class HospitalizationFormulaTranslation
    {
        public static Dictionary<HospitalizationFormula, string> Translations
        {
            get
            {
                var translations = new Dictionary<HospitalizationFormula, string>()
                {
                    { HospitalizationFormula.Normal, "Hospitalisatie + Pre- en post" },
                    { HospitalizationFormula.SevereDiseases, "Hospitalisatie + Pre- en post + zware ziekten" },
                };


                return translations;
            }
        }
    }
}