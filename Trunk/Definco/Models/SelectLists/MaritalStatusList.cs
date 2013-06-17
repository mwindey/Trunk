using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class MaritalStatusList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<MaritalStatus, string>()
                {
                    { MaritalStatus.Single, "Alleenstaand" },
                    { MaritalStatus.Married, "Getrouwd" },
                    { MaritalStatus.Widower, "Weduwnaar" },
                    { MaritalStatus.Divorced, "Gescheiden" },
                    { MaritalStatus.Seperated, "Feitelijk gescheiden" }
                };


                return Enum.GetValues(typeof(MaritalStatus))
                    .AsQueryable()
                    .Cast<MaritalStatus>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = MaritalStatusTranslations.Translations[b] });
            }
        }
    }
}