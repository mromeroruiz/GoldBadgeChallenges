using System;
using System.Linq;
using _05_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Challenge_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToList()
        {
            //Arrange
            Customer name = new Customer();
            ObjectRepo repo = new ObjectRepo();
            //Act
            repo.NewCustomer("first", "last", 1);
            int actual = repo.GetList().Count();
            int expect = 1;
            //Assert
            Assert.AreEqual(actual, expect);
        }
        [TestMethod]
        public void RemovingFromList()
        {
            Customer firstCustomer = new Customer();
            Customer secondCustomer = new Customer();
            ObjectRepo repo = new ObjectRepo();

            repo.NewCustomer("miguel", "romero", 2);
            repo.NewCustomer("first", "last", 1);
            repo.RemoveObject(2);
            int actual = repo.GetList().Count();
            int expected = 1;
            Assert.AreEqual(actual, expected);
        }
    }
}
