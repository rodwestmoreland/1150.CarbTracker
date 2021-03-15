using CarbTracker.Models;
using CarbTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarbTracker.WebAPI.Controllers
{
    [Authorize]
    public class MealController : ApiController
    {
        public IHttpActionResult Get()
        {
            MealService mealService = CreateMealService();
            var meals = mealService.GetMeal();
            return Ok(meals);
        }

        public IHttpActionResult Post(MealTableCreate meal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMealService();

            if (!service.CreateMeal(meal))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(string meal)
        {
            int number;
            bool success = Int32.TryParse(meal, out number);

            var service = CreateMealService();
            if (success)
            {
                if (!service.DeleteMealId(number))
                    return InternalServerError();
            }
            else
            {
                if (!service.DeleteMealName(meal))
                    return InternalServerError();
            }
            return Ok();
        }

        //public IHttpActionResult DeleteMealById(int mealId)
        //{
        //    var service = CreateMealService();

        //    if (!service.DeleteMealId(mealId))
        //        return InternalServerError();

        //    return Ok();
        //}

        //public IHttpActionResult DeleteMealByName(string mealName)
        //{
        //    var service = CreateMealService();

        //    if (!service.DeleteMealName(mealName))
        //        return InternalServerError();

        //    return Ok();
        //}

        public IHttpActionResult Put (MealEdit meal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMealService();

            if (!service.UpdateMeal(meal))
                return InternalServerError();

            return Ok();
        }

        private MealService CreateMealService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var mealService = new MealService(userId.ToString());
            return mealService;
        }
    }
}
