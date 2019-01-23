using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge
{
    public enum CarType {Electric = 1, Hybrid, Gas }
    public class Vehicle
    {
        private int numberOfCars;
        private int typeNum;

        public string Name { get; set; }
        public string Info { get; set; }
        public CarType Type { get; set; }
        public decimal Price { get; set; }
        public int CarID { get; set; }

        public Vehicle(string name, string info, CarType type, decimal price)
        {
            Name = name;
            Info = info;
            Type = type;
            Price = price;
        }
        public Vehicle()
        {
        }

        public Vehicle(int carID, string name, string info, int typeNum)
        {
            CarID = carID;
            Name = name;
            Info = info;
            Type = (CarType)typeNum;
        }
    }
}
