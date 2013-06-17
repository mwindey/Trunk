using Definco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Definco.Models.EnumTranslations;

namespace Definco.Models.SelectLists
{
    public class VehicleTypeList
    {
        public static IEnumerable<SelectListItem> Items
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


                return Enum.GetValues(typeof(VehicleType))
                    .AsQueryable()
                    .Cast<VehicleType>()
                    .Select(b => new SelectListItem() { Value = b.ToString(), Text = VehicleTypeTranslation.Translations[b] });
            }
        }
    }
}