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
        public void AddToList_Test()
        {
            //Arrange
            Outing outing = new Outing();
            OutingRepo repo = new OutingRepo();
            //Act
            repo.AddOuting(outing);
            int actual = repo.GetOutings().Count();
            int expected = 1;

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
            Event type = Event.Golf;



        }
    }
}
