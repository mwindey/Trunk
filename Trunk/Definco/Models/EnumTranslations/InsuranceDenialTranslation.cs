using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class InsuranceDenialTranslation
    {
        public static Dictionary<InsuranceDenial, string> Translations
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


                return translations;
            }
        }
    }
}