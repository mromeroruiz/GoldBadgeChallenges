using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class MealRepository
    {
        List<Meal> listOfMenu = new List<Meal>();

        public void AddMealToMenu(Meal addMeal)
        {
            listOfMenu.Add(addMeal);
        }
        public List<Meal> GetMenuList()
        {
            return listOfMenu;
        }
        public bool RemoveMealFromMenu(int removeMealNumber)
        {
            foreach (Meal meal in listOfMenu)
            {
                if (meal.MealNumber == removeMealNumber)
                {
                    listOfMenu.Remove(meal);
                    return true;
                }
                
                
            }
            return false;
            
        }

    }
}
