using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class OutingRepo
    {
        List<Outing> listOfOutings = new List<Outing>();
        public void AddOuting (Outing addOuting)
        {
            listOfOutings.Add(addOuting);
            
        }
        public List<Outing> GetOutings()
        {
            return listOfOutings;
        }
        public decimal CostEvent()
        {
            decimal totalCost = 0m;


            foreach (Outing item in listOfOutings)
            {
                decimal cost = item.CostEvent;
                totalCost += cost;
            }
            return totalCost;
        }
        public decimal Type(Event type)
        {
            decimal totalCost = 0m;
            foreach (Outing item in listOfOutings)
            {
                
                if (item.Type == type)
                {
                    decimal cost = item.CostEvent;
                    totalCost += cost;
                }
            }
            return totalCost;
        }
        
    }
}
