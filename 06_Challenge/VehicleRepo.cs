using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge
{
    public class VehicleRepo
    {

        List<Vehicle> electric = new List<Vehicle>();
        List<Vehicle> hybrid = new List<Vehicle>();
        List<Vehicle> gas = new List<Vehicle>();
        

        int numberOfCars = 0;

        public void NewCar(string name, string info, int typeNum)
        {
            numberOfCars++;
            Vehicle newCar = new Vehicle(numberOfCars, name, info, typeNum);

            if (newCar.Type == CarType.Electric)
            {
                electric.Add(newCar);
            }
            else if (newCar.Type == CarType.Hybrid)
            {
                hybrid.Add(newCar);
            }
            else if (newCar.Type == CarType.Gas)
            {
                gas.Add(newCar);
            }
        }

        public void AddToHybridList(Vehicle vehicle)
        {
            hybrid.Add(vehicle);
        }

        public void AddToElectricList(Vehicle vehicle)
        {
            electric.Add(vehicle);
        }
        public void AddToGasList(Vehicle vehicle)
        {
            gas.Add(vehicle);
        }

        public List<Vehicle> GetElecList()
        {
            return electric;
        }
        public List<Vehicle> GetHybridList()
        {
            return hybrid;
        }
        public List<Vehicle> GetGasList()
        {
            return gas;
        }


        public void RemoveCar(int carID, CarType type)
        {
            

            if(type == CarType.Electric)
            {
                foreach(Vehicle car in electric)
                {
                    if(car.CarID == carID && car.Type == type)
                    {
                        RemoveElecCar(car);
                        break;
                    }
                }
            }
           
            numberOfCars--;

        }

        public void RemoveElecCar(Vehicle car)
        {
            electric.Remove(car);
        }
        public void RemoveHybridCar(Vehicle car)
        {
            hybrid.Remove(car);
        }
        public void RemoveGasCar(Vehicle car)
        {
            gas.Remove(car);
        }
    }

}
