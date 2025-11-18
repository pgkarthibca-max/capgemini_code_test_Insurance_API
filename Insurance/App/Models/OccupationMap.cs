using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public static class OccupationMap
    {
        // maps occupation display name -> rating group
        public static readonly Dictionary<string, OccupationRating> Map = new Dictionary<string, OccupationRating>
        {
            {"Cleaner", OccupationRating.LightManual},
            {"Doctor", OccupationRating.Professional},
            {"Author", OccupationRating.WhiteCollar},
            {"Farmer", OccupationRating.HeavyManual},
            {"Mechanic", OccupationRating.HeavyManual},
            {"Florist", OccupationRating.LightManual},
            {"Other", OccupationRating.HeavyManual}
        };

        public static decimal FactorFor(OccupationRating rating)
        {
            switch (rating)
            {
                case OccupationRating.Professional: return 1.5m;
                case OccupationRating.WhiteCollar: return 2.25m;
                case OccupationRating.LightManual: return 11.50m;
                case OccupationRating.HeavyManual: return 31.75m;
                default: return 1.0m;
            }
        }
    }
}