using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class MaritalStatusTranslations
    {
        public static Dictionary<MaritalStatus, string> Translations
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


                return translations;
            }
        }
    }
}