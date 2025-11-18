using App.App_Start;
using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using App.Models;

namespace App.APIs
{
    public class PremiumApiController : ApiController
    {
        private readonly IPremiumCalculatorService _calculator;

        public PremiumApiController()
        {
            // simple resolver via bootstrapper container (you can plug a proper DI framework later)
            _calculator = Bootstrapper.Container.Resolve<IPremiumCalculatorService>();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/premium/calculate")]
        public IHttpActionResult Calculate([FromBody] PremiumRequest req)
        {
            if (req == null) return BadRequest("Request body is required");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // persist and compute
            var entity = _calculator.CreateAndPersistPremium(req);

            return Ok(new { MonthlyPremium = entity.MonthlyPremium, OccupationRating = entity.OccupationRating, OccupationFactor = entity.OccupationFactor });
        }
    }
}
