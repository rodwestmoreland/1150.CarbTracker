using CarbTracker.Data;
using CarbTracker.Models;
using CarbTracker.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CarbTracker.XUnitTesting
{
    [TestClass]
    public class FoodTest
    {
        [TestMethod]
        public void AddingFood()
        {
            //using (var context = new ApplicationDbContext())
            //    {
            //    //var getIndex = from x in context.MealTables
            //    //               where x.TotalCarbs.Equals(1.0)
            //    //               select x;
            //    //foreach (var item in getIndex)
            //    //{
            //    //    Console.WriteLine(item.Name);
            //    //}
            //}

            FoodCreate addFood = new FoodCreate();
            addFood.Name = "Waffle";
            //addFood.ServingInOunces = 1.0;
            //addFood.Carbs = 50;
            addFood.Description = "waffle";

            var foodService = new FoodService();
            var getMeAWaffle = foodService.CreateFood(addFood);

            Assert.AreEqual(true, getMeAWaffle);

        }
    }
}
