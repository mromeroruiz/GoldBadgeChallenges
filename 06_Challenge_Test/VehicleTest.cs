using System;
using System.Linq;
using _06_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_Challenge_Test
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void AddCarToElecList_AddCarToGasList_RemoveCarFromSpecificList_GetList_GetElecList_GetGasList_Test()
        {
            //Arrange
            Vehicle name = new Vehicle();
            VehicleRepo repo = new VehicleRepo();
            //Act
            repo.NewCar("SecondTesla", "a bit about this car", 1);
            repo.NewCar("ThirdTesla", "a bit about this car", 1);
            repo.NewCar("Tesla", "a bit about this car", 1);
            repo.NewCar("Ford", "a bit about this car", 3);
            repo.RemoveCar(1, CarType.Electric);
            int actual = repo.GetElecList().Count();
            int expect = 2;
            int actualTwo = repo.GetGasList().Count();
            int expectTwo = 1;
            //Assert
            Assert.AreEqual(actual, expect);
            Assert.AreEqual(actualTwo, expectTwo);
        }
    }
}
