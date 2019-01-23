using System;
using System.Linq;
using _01_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class MealRepository_Tests
    {
        [TestMethod]
        public void AddToList_Test()
        {

            //Arrange
            Meal newMeal = new Meal();
            MealRepository repo = new MealRepository();
            //Act
            repo.AddMealToMenu(newMeal);
            int actual = repo.GetMenuList().Count();
            int expected = 1;
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void RemoveFromList_Test()
        {
            Meal newMeal = new Meal(1, "taco", "none", "none", 2);
            Meal newMealTwo = new Meal();
            MealRepository repo = new MealRepository();

            repo.AddMealToMenu(newMeal);
            repo.AddMealToMenu(newMealTwo);
            repo.RemoveMealFromMenu(newMeal.MealNumber);
            int actualTwo = repo.GetMenuList().Count();
            int expectedTwo = 1;

            Assert.AreEqual(actualTwo, expectedTwo);

        }
    }
}
