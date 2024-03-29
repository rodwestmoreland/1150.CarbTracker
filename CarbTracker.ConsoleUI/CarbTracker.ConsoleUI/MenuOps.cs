﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.ConsoleUI
{
    public class MenuOps
    {
        public string AToken
        {
            get => _atoken;
            set => _atoken = value ;
        }

        public string BaseUrl
        { 
            get => _baseUrl;
            set => _baseUrl = value;
        }
       
        public MenuOps(){}
        public MenuOps(string accessToken, string baseUrl)
        {
            _atoken = accessToken;
            _baseUrl = baseUrl;
        }
        public static string _atoken;
        public static string _baseUrl;
        public static List<string> menuOptions = new List<string>();
        
        public static void MenuSelections()
        {
            menuOptions.Add("Enter Blood Sugar Information\n"); // connected
            menuOptions.Add("See all foods in database\n"); // connected
            menuOptions.Add("See all meals in database\n"); // connected
            menuOptions.Add("Add a new food item\n"); // connected
            menuOptions.Add("Add a new meal item\n"); // connected
            menuOptions.Add("Modify a meal item\n"); // connected
            menuOptions.Add("Delete a meal item\n"); // connected
            menuOptions.Add("Search for meal by name\n");
            menuOptions.Add("Exit application\n"); // connected

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Blood Sugar Tracker \nSelect option below:\n");
                int i = 1;
                foreach (var option in menuOptions)
                {
                    Console.WriteLine($"{i}. {option}");
                    i++;
                }
                Console.Write("Selection > ");        
                string menuSelect = (Console.ReadLine());
                MenuSelectionCheck(menuSelect);
            }// \while

        }//MenuSelections()


        public static void MenuProcessing(byte selection)
        {
            Console.Clear();

            switch (selection)
            {
                case 1:
                    var addBS = new SyncAPIBSTracker();
                    addBS.AddBS(_atoken, _baseUrl);
                    ClickToCont();
                    break;
                case 2:
                    var getFoods = new SyncAPIFoods();
                    getFoods.GetFoods(_atoken, _baseUrl);
                    ClickToCont();
                    break;

                case 3: // This is done
                    var getMeals = new SyncAPIMeals();
                    getMeals.GetMeals(_atoken, _baseUrl);
                    ClickToCont();
                    break;
                case 4: // This is done
                    var addFoods = new SyncAPIFoods();
                    addFoods.AddFood(_atoken, _baseUrl);
                    ClickToCont();
                    break;
                case 5: // This is done
                    var addMeal = new SyncAPIMeals();
                    addMeal.AddMeal(_atoken, _baseUrl);
                    ClickToCont();
                    break;
                case 6: // This is done
                    var updateMeal = new SyncAPIMeals();
                    updateMeal.UpdateMeal(_atoken, _baseUrl);
                    
                    ClickToCont();
                    break;
                case 7:
                    var delMeal = new SyncAPIMeals();
                    delMeal.DeleteMeal(_atoken, _baseUrl);
                    ClickToCont();
                    break;
                case 8:
                    var findMeal = new SyncAPIMeals();
                    findMeal.GetByName(_atoken, _baseUrl);
                    ClickToCont();
                    break;
                case 9:
                    ClickToCont();
                    break;
                case 10:
                    Console.WriteLine("not implemented yet");
                    ClickToCont();
                    break;

            }

        }//MenuProcessing()

        private static void MenuSelectionCheck(string menuSelect)
        {
            if (Byte.TryParse(menuSelect, out byte num))
            {
                if (num == menuOptions.Count)
                { Environment.Exit(0); }
                else if (num > 0 && num < menuOptions.Count)
                { MenuProcessing(num); }
                else
                { InvalidSelection(); }
            }
            else
            { InvalidSelection(); }
        }

        public static void InvalidSelection()
        {
            Console.Clear();
            Console.WriteLine($"\nPlease enter a valid menu option: 1 - {menuOptions.Count}\n");
        }

        private static void ClickToCont()
        {
            Console.Write("\n\n\nPress any key to continue: ");
            Console.ReadKey();
            Console.Clear();
        }


    }//class
}
