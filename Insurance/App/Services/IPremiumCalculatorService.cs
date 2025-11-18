using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Services
{
    public interface IPremiumCalculatorService
    {
        decimal CalculateMonthlyPremium(decimal deathCover, string occupation, int age);
        MemberPremium CreateAndPersistPremium(PremiumRequest req);
    }
}