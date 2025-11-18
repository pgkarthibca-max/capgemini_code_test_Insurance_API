using App.Data;
using App.Factories;
using App.Infrastructure;
using App.Services;
using App.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.App_Start
{
    public static class Bootstrapper
    {
        public static readonly ServiceContainer Container = new ServiceContainer();

        public static void Initialize()
        {
            // register dbcontext as transient
            Container.RegisterTransient<PremiumDbContext>(() => new PremiumDbContext());

            // register unit of work as transient (per request you should create a unit-of-work)
            Container.RegisterTransient<IUnitOfWork>(() => new EfUnitOfWork(Container.Resolve<PremiumDbContext>()));

            // Occupation factory as singleton
            Container.RegisterSingleton<IOccupationRatingProvider>(() => new OccupationRatingFactory());

            // Premium calculator service
            Container.RegisterTransient<IPremiumCalculatorService>(() => new PremiumCalculatorService(Container.Resolve<IOccupationRatingProvider>(), Container.Resolve<IUnitOfWork>()));
        }
    }
}