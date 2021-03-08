using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarbTracker.Services;

namespace CarbTracker.WebAPI.Controllers
{
    [Authorize]
    public class FoodController : ApiController
    {
        public IHttpActionResult Get()
        {
            FoodService foodService = CreateFoodService();
            var foods = foodService.GetFood();
            return Ok(foods);
        }

        private FoodService CreateFoodService()
        {
            var foodService = new FoodService();
            return foodService;
        }

    }
}
