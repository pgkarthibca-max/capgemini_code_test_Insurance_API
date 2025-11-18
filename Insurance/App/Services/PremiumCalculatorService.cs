using App.Factories;
using App.Models;
using App.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Services
{
    public class PremiumCalculatorService : IPremiumCalculatorService
    {
        private readonly IOccupationRatingProvider _occupationProvider;
        private readonly IUnitOfWork _uow;

        public PremiumCalculatorService(IOccupationRatingProvider occupationProvider, IUnitOfWork uow)
        {
            _occupationProvider = occupationProvider;
            _uow = uow;
        }

        public decimal CalculateMonthlyPremium(decimal deathCover, string occupation, int age)
        {
            var rating = _occupationProvider.Resolve(occupation);
            var factor = _occupationProvider.GetFactor(rating);

            // Using the simplified monthly formula (DeathCover * Factor * Age) / 1000
            var monthly = (deathCover * factor * age) / 1000m;
            return Math.Round(monthly, 2);
        }

        public MemberPremium CreateAndPersistPremium(PremiumRequest req)
        {
            var monthly = CalculateMonthlyPremium(req.DeathCoverAmount, req.Occupation, req.AgeNextBirthday);
            var rating = _occupationProvider.Resolve(req.Occupation);
            var factor = _occupationProvider.GetFactor(rating);

            var entity = new MemberPremium
            {
                Name = req.Name,
                DateOfBirth = req.DateOfBirth,
                AgeNextBirthday = req.AgeNextBirthday,
                Occupation = req.Occupation,
                OccupationRating = rating.ToString(),
                OccupationFactor = factor,
                DeathCoverAmount = req.DeathCoverAmount,
                MonthlyPremium = monthly,
                CalculatedOn = DateTime.UtcNow
            };

            var repo = _uow.Repository<MemberPremium>();
            repo.Insert(entity);
            _uow.SaveChanges();

            return entity;
        }
    }
}