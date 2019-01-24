using System;
using System.Linq;
using _03_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Challenge_Test
{
    [TestClass]
    public class Outing_Test
    {
        [TestMethod]
        public void AddGetList_Test()
        {
            //Arrange
            Outing outing = new Outing();
            Outing outingTwo = new Outing(Event.Concert, 10, DateTime.Now, 20, 2000);
            Outing outingThree = new Outing(Event.Golf, 2, DateTime.Now, 10, 200);
            OutingRepo repo = new OutingRepo();
            //Act
            repo.AddOuting(outing);
            repo.AddOuting(outingTwo);
            repo.AddOuting(outingThree);
            
            int actual = repo.GetOutings().Count();
            int expected = 3;

            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CostEvent_Test()
        {
            Outing outing = new Outing(Event.Golf, 2, DateTime.Now, 10, 200);
            Outing outingTwo = new Outing(Event.Golf, 3, DateTime.Now, 15, 600);
            Outing outingThree = new Outing(Event.Concert, 10, DateTime.Now, 20, 2000);
            OutingRepo repo = new OutingRepo();
            repo.AddOuting(outing);
            repo.AddOuting(outingTwo);
            repo.AddOuting(outingThree);
            decimal amount = repo.Type(Event.Golf);
            decimal actual = amount;
            decimal expected = 800;

            Assert.AreEqual(actual, expected);



        }
        [TestMethod]
        public void CostAllEvent_Test()
        {
            Outing outing = new Outing(Event.Golf, 2, DateTime.Now, 10, 200);
            Outing outingTwo = new Outing(Event.Golf, 3, DateTime.Now, 15, 600);
            Outing outingThree = new Outing(Event.Concert, 10, DateTime.Now, 20, 2000);
            OutingRepo repo = new OutingRepo();
            repo.AddOuting(outing);
            repo.AddOuting(outingTwo);
            repo.AddOuting(outingThree);
            decimal amount = repo.CostEvent();
            decimal actual = amount;
            decimal expected = 2800;

            Assert.AreEqual(actual, expected);
        }
    }
}
