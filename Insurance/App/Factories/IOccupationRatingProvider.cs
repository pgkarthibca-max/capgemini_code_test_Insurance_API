using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Factories
{
    public interface IOccupationRatingProvider
    {
        OccupationRating Resolve(string occupation);
        decimal GetFactor(OccupationRating rating);
    }
}