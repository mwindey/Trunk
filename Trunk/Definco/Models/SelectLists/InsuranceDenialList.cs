using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class InsuranceDenialList
    {
        public static IEnumerable<SelectListItem> Items
        {
            get
            {
                var translations = new Dictionary<InsuranceDenial, string>()
                {
                    { InsuranceDenial.None, "Nooit opgezegd geweest" },
                    { InsuranceDenial.AfterDamage, "Ja, polis opgezegd door verzekeraar na schadegevallen" },
                    { InsuranceDenial.PaymentProblems, "Ja, polis opgezegd problemen premiebetaling" },
                    { InsuranceDenial.Other, "Ja, polis opgezegd onbekende of andere reden" }
                };


                return Enum.GetValues(typeof(InsuranceDenial))
                    .AsQueryable()
                    .Cast<InsuranceDenial>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = InsuranceDenialTranslation.Translations[b] });
            }
        }
    }
}