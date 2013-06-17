using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class CompanyCarTypeList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<CompanyCarType, string>()
                {
                    { CompanyCarType.Limited, "Beperkt gebruik / woon-werk verkeer" },
                    { CompanyCarType.ProfessionalUse, "Firmawagen, beroepsgebruik" },
                    { CompanyCarType.UnProfessionalUse, "Firmawagen, geen beroepsgebruik" }
                };


                return Enum.GetValues(typeof(CompanyCarType))
                    .AsQueryable()
                    .Cast<CompanyCarType>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = CompanyCarTypeTranslation.Translations[b] });
            }
        }
    }
}