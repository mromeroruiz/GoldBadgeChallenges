using System;
using System.Collections.Generic;

namespace _01_Challenge
{
    internal class ProgramUI
    {
        private MealRepository mealRepo;
        private bool keepRunning = true;
        private List<Meal> meals;

        public ProgramUI()
        {
            mealRepo = new MealRepository();
            meals = mealRepo.GetMenuList();
        }

        internal void Run()
        {
            while (keepRunning)
            {
                Console.Clear();
                Menu();
            }

            Console.ReadLine();
        }
        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("Hello Welcome to Komodo Cafe.. What would you like to do?\n" +
                "1. Add a new Meal\n" +
                "2. See the list of Meals you've added\n" +
                "3. Remove a Meal from the list\n" +
                "4. Exit Program");
            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    AddAMeal();
                    break;
                case 2:
                    ViewMenu();
                    break;
                case 3:
                    RemoveFromMenu();
                    break;
                case 4:
                    keepRunning = false;
                    break;
            }

        }

        private void AddAMeal()
        {
            Meal newMeal = new Meal();
            Console.WriteLine("Name your meal");
            newMeal.MealName = Console.ReadLine();
            Console.WriteLine("What Number would you like to set this Meal as? (1-10)");
            newMeal.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"Write a description for this meal:");
            newMeal.MealDescription = Console.ReadLine();
            Console.WriteLine("What ingredients does it use?");
            newMeal.MealIngredients = Console.ReadLine();
            Console.WriteLine("Set a price for this meal:");
            newMeal.MealCost = decimal.Parse(Console.ReadLine());

            
            mealRepo.AddMealToMenu(newMeal);
        }
        private void ViewMenu()
        {
            List<Meal> meals = mealRepo.GetMenuList();
            foreach (Meal content in meals)
            {
                Console.WriteLine($"{content.MealNumber}: {content.MealName} for ${content.MealCost}\n");
            }
            Console.WriteLine($"This is the Menu so far.\n" +
                    $"Press any key to continue..");
            Console.ReadLine();
        }
        private void RemoveFromMenu()
        {
            Console.Clear();
            ViewMenu();

            Meal removeMeal = new Meal();
            Console.WriteLine("What Menu number would you like to remove? (1-10)");
            int mealNumber = int.Parse(Console.ReadLine());

            bool success = mealRepo.RemoveMealFromMenu(mealNumber);
            if(success == true)
            {
                Console.WriteLine($"Number {mealNumber}. has been removed.");
                Console.ReadLine();
            }

        }
        
    }
}