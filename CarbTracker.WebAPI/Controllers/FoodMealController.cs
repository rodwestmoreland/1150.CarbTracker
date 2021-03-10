using CarbTracker.Models;
using CarbTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarbTracker.WebAPI.Controllers
{
    public class FoodMealController : ApiController
    {
        public IHttpActionResult Get()
        {
            FoodMealService foodMealService = CreateFoodMealService();
            var foodmeals = foodMealService.GetFoodMeal();
            return Ok(foodmeals);
        }

        public IHttpActionResult Post(FoodMealCreate foodMeal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateFoodMealService();

            if (!service.CreateFoodMeal(foodMeal))
                return InternalServerError();

            return Ok();
        }
        private FoodMealService CreateFoodMealService()
        {
            var foodMealService = new FoodMealService();
            return foodMealService;
        }
    }
}
