﻿using CarbTracker.Data;
using CarbTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Services
{
    public class MealService
    {
        private readonly string _userId;
        public MealService(string userId)
        {
            _userId = userId;
        }


        public IEnumerable<MealTableListItem> GetMeal()
        {

            using (var context = new ApplicationDbContext())
            {
                if (context.MealTables.Count() < 2)
                {
                    List<MealTable> seedMeals = new List<MealTable>();
                    seedMeals.Add(new MealTable("Cheese Sandwich", 37));
                    seedMeals.Add(new MealTable("Omelet", 2));
                    seedMeals.Add(new MealTable("BLT", 38));
                    seedMeals.Add(new MealTable("Turkey Sandwich", 37));
                    seedMeals.Add(new MealTable("French Toast", 43));
                    seedMeals.Add(new MealTable("Banana Apple Salad", 33));
                    seedMeals.Add(new MealTable("Turkey Club", 39));
                    seedMeals.Add(new MealTable("Apple Banana Smoothie", 45));

                    foreach (var meals in seedMeals)
                    {
                        context.MealTables.Add(meals);
                        context.SaveChanges();
                    }
                }
                var query = context.MealTables
                                .Select(e => new MealTableListItem
                                {
                                    MealId = e.MealId,
                                    MealName = e.MealName,
                                    TotalCarbs = e.TotalCarbs,
                                    Id = _userId
                                }
                            );

                return query.ToArray();

            }
        }

        public bool CreateMeal(MealTableCreate model)
        {

            var entity = new MealTable()
            {
                MealName = model.MealName,
                TotalCarbs = model.TotalCarbs,
                Id = _userId
            };

            using (var context = new ApplicationDbContext())
            {
                context.MealTables.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
