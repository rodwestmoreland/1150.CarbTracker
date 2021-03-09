using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarbTracker.Data;
using CarbTracker.Models;
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


        public IHttpActionResult Post(FoodCreate food)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFoodService();

            if (!service.CreateFood(food))
                return InternalServerError();

            return Ok();
        }
        private FoodService CreateFoodService()
        {
            var foodService = new FoodService();
            return foodService;
        }

    }
}
