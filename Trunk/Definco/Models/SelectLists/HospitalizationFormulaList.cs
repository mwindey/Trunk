using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class HospitalizationFormulaList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<HospitalizationFormula, string>()
                {
                    { HospitalizationFormula.Normal, "Hospitalisatie + Pre- en post" },
                    { HospitalizationFormula.SevereDiseases, "Hospitalisatie + Pre- en post + zware ziekten" },
                };


                return Enum.GetValues(typeof(HospitalizationFormula))
                    .AsQueryable()
                    .Cast<HospitalizationFormula>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = HospitalizationFormulaTranslation.Translations[b] });
            }
        }
    }
}