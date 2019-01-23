using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public enum Event { Golf = 1, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public Event Type { get; set; }
        public int People { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerson { get; set; }
        public decimal CostEvent { get; set; }

        public Outing(Event type, int people, DateTime date, decimal costPerson, decimal costEvent)
        {
            Type = type;
            People = people;
            Date = date;
            CostPerson = costPerson;
            CostEvent = costEvent;
        }
        public Outing()
        {

        }
    }
}
