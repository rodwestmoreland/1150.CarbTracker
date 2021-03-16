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
       
        public MenuOps()
        {

        }
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
            menuOptions.Add("Find total carbs in food\n");
            menuOptions.Add("Find total carbs in meal\n");
            menuOptions.Add("Add a new food item\n");
            menuOptions.Add("Add a new meal item\n");
            menuOptions.Add("Modify a meal item\n");
            menuOptions.Add("Delete a meail item\n");
            menuOptions.Add("Exit application\n");


            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Blood Sugar Tracker \nSelect option below:\n\n");
                int i = 1;
                foreach (var option in menuOptions)
                {
                    Console.WriteLine($"{i}. {option}");
                    i++;
                }
                        
                string menuSelect = (Console.ReadLine());
                MenuSelectionCheck(menuSelect);
            }// \while


        }//MenuSelections()


        public static void MenuProcessing(byte selection)
        {
            var ops = new MenuOps();
            var ui = new UI();

            Console.Clear();

            switch (selection)
            {
                case 1:
                    
                    ClickToCont();
                    break;
                case 2:
                    
                    ClickToCont();
                    break;
                case 3:
                    var getFoods = new SyncAPIFoods();
                    getFoods.GetFoods(_atoken, _baseUrl);
                    ClickToCont();
                    break;
                case 4:
                    
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
            Console.WriteLine("\n\n\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }


    }//class
}