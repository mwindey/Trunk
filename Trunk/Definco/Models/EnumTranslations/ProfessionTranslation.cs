using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class ProfessionTranslation
    {
        public static Dictionary<Profession, string> Translations
        {
            get
            {
                var translations = new Dictionary<Profession, string>()
                {
                    { Profession.Unemployed, "Werkloos" },
                    { Profession.Worker, "Arbeider" },
                    { Profession.Teacher, "Leerkracht" },
                    { Profession.Student, "Student" },
                    { Profession.CivilServant, "Ambtenaar" },
                    { Profession.Clerk, "Bediende" },
                    { Profession.Pensioned, "Gepensioneerd" },
                    { Profession.SelfEmployed, "Zelfstandig" }
                };


                return translations;
            }
        }
    }
}