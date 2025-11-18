using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Models;

namespace App.Factories
{
    public class OccupationRatingFactory : IOccupationRatingProvider
    {
        private static readonly Dictionary<string, OccupationRating> _map = new Dictionary<string, OccupationRating>
        {
            {"Cleaner", OccupationRating.LightManual},
            {"Doctor", OccupationRating.Professional},
            {"Author", OccupationRating.WhiteCollar},
            {"Farmer", OccupationRating.HeavyManual},
            {"Mechanic", OccupationRating.HeavyManual},
            {"Florist", OccupationRating.LightManual},
            {"Other", OccupationRating.HeavyManual}
        };

        public OccupationRating Resolve(string occupation)
        {
            if (string.IsNullOrWhiteSpace(occupation)) return OccupationRating.HeavyManual;
            if (_map.TryGetValue(occupation, out var rating)) return rating;
            return OccupationRating.HeavyManual;
        }

        public decimal GetFactor(OccupationRating rating)
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