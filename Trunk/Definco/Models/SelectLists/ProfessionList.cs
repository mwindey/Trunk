using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class ProfessionList
    {
        public static IEnumerable<SelectListItem> Items
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


                return Enum.GetValues(typeof(Profession))
                    .AsQueryable()
                    .Cast<Profession>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = ProfessionTranslation.Translations[b] });
            }
        }
    }
}