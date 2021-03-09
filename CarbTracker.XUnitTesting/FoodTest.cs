using CarbTracker.Data;
using CarbTracker.Models;
using CarbTracker.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarbTracker.XUnitTesting
{
    [TestClass]
    public class FoodTest
    {
        [TestMethod]
        public void AddingFood()
        {
            FoodCreate addFood = new FoodCreate();
            addFood.Name = "Waffle";
            addFood.ServingInOunces = 1;
            addFood.Carbs = 50;
            addFood.Description = "waffle";

            var foodService = new FoodService();
            var getMeAWaffle = foodService.CreateFood(addFood);

            Assert.AreEqual(true, getMeAWaffle);

        }
    }
}
