using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Definco.Models.EnumTranslations
{
    public class VehicleTypeTranslation
    {
        public static Dictionary<VehicleType, string> Translations
        {
            get
            {
                var translations = new Dictionary<VehicleType, string>()
                {
                    { VehicleType.PassengerCar, "Personenwagen" },
                    { VehicleType.Camper, "Kampeerwagen" },
                    { VehicleType.LightTruckOwnAccount, "Lichte vrachtwagen vervoer eigen rekeningen" },
                    { VehicleType.LightTruckThirdParty, "Lichte vrachtwagen vervoer rekening derden" },
                    { VehicleType.OldTimer, "Oldtimer" },
                    { VehicleType.Other, "Andere" }
                };


                return translations;
            }
        }
    }
}