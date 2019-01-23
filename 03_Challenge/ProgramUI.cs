using System;
using System.Collections.Generic;

namespace _03_Challenge
{
    internal class ProgramUI
    {
        OutingRepo _repo = new OutingRepo();
        internal void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to my world");
                Console.WriteLine("What would you like to do?\n" +
                    "1. Add an Outing\n" +
                    "2. See list of Outings\n" +
                    "3. Calculate combined cost of all outings\n" +
                    "4. Calculate cost of individual outing by type\n");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddAnOuting();
                        break;
                    case 2:
                        SeeList();
                        break;
                    case 3:
                        CombinedCost();
                        break;
                    case 4:
                        CostByType();
                        break;

                }
            }

        }

        private void AddAnOuting()
        {
            Outing outing = new Outing();

            Console.WriteLine("Enter Type of Event\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    outing.Type = Event.Golf;
                    break;
                case 2:
                    outing.Type = Event.Bowling;
                    break;
                case 3:
                    outing.Type = Event.AmusementPark;
                    break;
                case 4:
                    outing.Type = Event.Concert;
                    break;
                default:
                    break;
            }
            Console.WriteLine("How many people attended?");
            outing.People = int.Parse(Console.ReadLine());
            Console.WriteLine("What date was it?");
            outing.Date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("how much was the cost per person?");
            outing.CostPerson = decimal.Parse(Console.ReadLine());
            Console.WriteLine("how much was the cost of the event?");
            outing.CostEvent = decimal.Parse(Console.ReadLine());

            _repo.AddOuting(outing);
        }
        private void SeeList()
        {
            decimal total = 0m;
            List<Outing> outing = _repo.GetOutings();
            foreach (Outing content in outing)
            {
                Console.WriteLine($"Date: {content.Date}   Type: {content.Type}  NumberOfPeople: {content.People}  Cost: {content.CostEvent}");
                Console.ReadLine();
            }

        }
        private void CombinedCost()
        {
            decimal totalCost = _repo.CostEvent();
            Console.WriteLine($"The combined cost is {totalCost}");
            Console.ReadLine();
        }
        private void CostByType()
        {
            decimal totalByType = 0;
            Console.WriteLine("Which type do you want the cost from?\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            int choice = int.Parse(Console.ReadLine());

                switch (choice)
            {
                case 1:
                    totalByType = _repo.Type(Event.Golf);
                    break;
                case 2:
                    totalByType = _repo.Type(Event.Bowling);
                    break;
                case 3:
                    totalByType = _repo.Type(Event.AmusementPark);
                    break;
                case 4:
                    totalByType = _repo.Type(Event.Concert);
                    break;
            }
                    Console.WriteLine($"The combined cost is {totalByType}");
            Console.ReadLine();
        }
    }
}