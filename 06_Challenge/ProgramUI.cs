using System;
using System.Collections.Generic;

namespace _06_Challenge
{
    internal class ProgramUI
    {
        private bool keeprunning = true;
        String input = null;

        internal void Run()
        {

            Vehicle newCar = new Vehicle();
            VehicleRepo repo = new VehicleRepo();
            while (keeprunning)
            {
                Console.Clear();
                Console.WriteLine("Hello and welcome to kamodo dragons list of cars. what would you like to do ?\n" +
                "1.Add a new car\n" +
                "2.Remove a car\n" +
                "3.Edit a car\n" +
                "4.View the list of cars\n" +
                "5.Exit");
                input = Console.ReadLine();
                //public Vehicle(int carID, string name, string info, int typeNum)
                if (input == "1")
                {
                    Console.WriteLine("What Type of car is it?\n" +
                        "1. Electric\n" +
                        "2. Hybrid\n" +
                        "3. Gas\n");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            newCar.Type = CarType.Electric;
                            break;
                        case 2:
                            newCar.Type = CarType.Hybrid;
                            break;
                        case 3:
                            newCar.Type = CarType.Gas;
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("What is the name of this car?");
                    string name = Console.ReadLine();
                    Console.WriteLine("Tell me a bit about this car: ");
                    string info = Console.ReadLine();
                    Console.WriteLine("Car added to list..");
                    Console.ReadLine();
                    repo.NewCar(name, info, choice);
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine("What Type of car is it?\n" +
                        "1. Electric\n" +
                        "2. Hybrid\n" +
                        "3. Gas\n");
                    int choice = int.Parse(Console.ReadLine());
                    CarType type = CarType.Electric;
                    switch (choice)
                    {
                        case 1:
                            type = CarType.Electric;
                            break;
                        case 2:
                            type = CarType.Hybrid;
                            break;
                        case 3:
                            type = CarType.Gas;
                            break;
                        default:
                            break;
                    }


                    Console.WriteLine("What ID did you want to remove?");
                    int response = int.Parse(Console.ReadLine());
                    repo.RemoveCar(response, type);


                }
                else if (input == "3")
                {
                    Console.Clear();
                    Console.WriteLine("What type of list would you like to open?\n" +
                        "1. Electric\n" +
                        "2. Hybrid\n" +
                        "3. Gas\n");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            List<Vehicle> elecCar = repo.GetElecList();
                            foreach (Vehicle vehicle in elecCar)
                            {
                                Console.WriteLine("Enter number ID you would like to Edit");
                                int response = int.Parse(Console.ReadLine());
                                Console.WriteLine($"{vehicle.CarID}|{vehicle.Name}: {vehicle.Info} ");
                                if (vehicle.CarID == response)
                                {
                                    Console.WriteLine($"1. Car: {vehicle.Name}\n" +
                                        $"2. Info: {vehicle.Info}\n" +
                                        $"3. Car Type: {vehicle.Type}\n" +
                                        $"4. Return to Menu\n" +
                                        $"Enter number to update: ");
                                    int updateResponse = int.Parse(Console.ReadLine());
                                    switch (updateResponse)
                                    {
                                        case 1:
                                            Console.Write("Enter new Name: ");
                                            vehicle.Name = Console.ReadLine();
                                            break;
                                        case 2:
                                            Console.Write("Enter new Info: ");
                                            vehicle.Info = Console.ReadLine();
                                            break;
                                        case 3:
                                            Console.WriteLine($"Enter new Type...\n" +
                                                $"1. Electric\n" +
                                                $"2. Hybrid\n" +
                                                $"3. Gas\n");
                                            int updatedType = int.Parse(Console.ReadLine());
                                            if (updatedType == 1)
                                            {
                                                if (vehicle.Type == CarType.Hybrid)
                                                {
                                                    repo.RemoveHybridCar(vehicle);
                                                    vehicle.Type = CarType.Electric;
                                                    repo.AddToElectricList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Gas)
                                                {
                                                    repo.RemoveGasCar(vehicle);
                                                    vehicle.Type = CarType.Electric;
                                                    repo.AddToElectricList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Electric)
                                                {
                                                    vehicle.Type = CarType.Electric;
                                                }


                                            }
                                            else if (updatedType == 2)
                                            {
                                                if (vehicle.Type == CarType.Hybrid)
                                                {
                                                    vehicle.Type = CarType.Hybrid;
                                                }
                                                else if (vehicle.Type == CarType.Electric)
                                                {
                                                    repo.RemoveElecCar(vehicle);
                                                    vehicle.Type = CarType.Hybrid;
                                                    repo.AddToHybridList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Gas)
                                                {
                                                    repo.RemoveGasCar(vehicle);
                                                    vehicle.Type = CarType.Hybrid;
                                                    repo.AddToHybridList(vehicle);
                                                }

                                            }
                                            else if (updatedType == 3)
                                            {
                                                if (vehicle.Type == CarType.Hybrid)
                                                {
                                                    repo.RemoveHybridCar(vehicle);
                                                    vehicle.Type = CarType.Gas;
                                                    repo.AddToGasList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Electric)
                                                {
                                                    repo.RemoveElecCar(vehicle);
                                                    vehicle.Type = CarType.Gas;
                                                    repo.AddToGasList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Gas)
                                                {
                                                    repo.RemoveGasCar(vehicle);
                                                    vehicle.Type = CarType.Gas;
                                                    repo.AddToGasList(vehicle);
                                                }
                                            }
                                           
                                            else
                                                Console.WriteLine("Error..");
                                            break;
                                        case 4:
                                            Console.WriteLine("Press any key to return to menu");
                                            break;
                                        default:
                                            Console.WriteLine("Error...");

                                            break;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 2:
                            List<Vehicle> hybridCar = repo.GetHybridList();
                            foreach (Vehicle vehicle in hybridCar)
                            {
                                Console.WriteLine($"{vehicle.CarID}|{vehicle.Name}: {vehicle.Info} ");
                                Console.WriteLine("Enter number ID you would like to Edit");
                                int response = int.Parse(Console.ReadLine());
                                if (vehicle.CarID == response)
                                {
                                    Console.WriteLine($"1. Car: {vehicle.Name}\n" +
                                        $"2. Info: {vehicle.Info}\n" +
                                        $"3. Car Type: {vehicle.Type}\n" +
                                        $"4. Return to Menu\n" +
                                        $"Enter number to update: ");
                                    int updateResponse = int.Parse(Console.ReadLine());
                                    switch (updateResponse)
                                    {
                                        case 1:
                                            Console.Write("Enter new Name: ");
                                            vehicle.Name = Console.ReadLine();
                                            break;
                                        case 2:
                                            Console.Write("Enter new Info: ");
                                            vehicle.Info = Console.ReadLine();
                                            break;
                                        case 3:
                                            Console.WriteLine($"Enter new Type...\n" +
                                                $"1. Electric\n" +
                                                $"2. Hybrid\n" +
                                                $"3. Gas\n");
                                            int updatedType = int.Parse(Console.ReadLine());
                                            if (updatedType == 1)
                                            {
                                                if (vehicle.Type == CarType.Hybrid)
                                                {
                                                    repo.RemoveHybridCar(vehicle);
                                                    vehicle.Type = CarType.Electric;
                                                    repo.AddToElectricList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Gas)
                                                {
                                                    repo.RemoveGasCar(vehicle);
                                                    vehicle.Type = CarType.Electric;
                                                    repo.AddToElectricList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Electric)
                                                {
                                                    vehicle.Type = CarType.Electric;
                                                }


                                            }
                                            else if (updatedType == 2)
                                            {
                                                if (vehicle.Type == CarType.Hybrid)
                                                {
                                                    vehicle.Type = CarType.Hybrid;
                                                }
                                                else if (vehicle.Type == CarType.Electric)
                                                {
                                                    repo.RemoveElecCar(vehicle);
                                                    vehicle.Type = CarType.Hybrid;
                                                    repo.AddToHybridList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Gas)
                                                {
                                                    repo.RemoveGasCar(vehicle);
                                                    vehicle.Type = CarType.Hybrid;
                                                    repo.AddToHybridList(vehicle);
                                                }

                                            }
                                            else if (updatedType == 3)
                                            {
                                                if (vehicle.Type == CarType.Hybrid)
                                                {
                                                    repo.RemoveHybridCar(vehicle);
                                                    vehicle.Type = CarType.Gas;
                                                    repo.AddToGasList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Electric)
                                                {
                                                    repo.RemoveElecCar(vehicle);
                                                    vehicle.Type = CarType.Gas;
                                                    repo.AddToGasList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Gas)
                                                {
                                                    repo.RemoveGasCar(vehicle);
                                                    vehicle.Type = CarType.Gas;
                                                    repo.AddToGasList(vehicle);
                                                }
                                            }
                                            else
                                                Console.WriteLine("Error..");
                                            break;
                                        case 4:
                                            Console.WriteLine("Press any key to return to menu");
                                            break;
                                        default:
                                            Console.WriteLine("Error...");

                                            break;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 3:
                            List<Vehicle> gasCar = repo.GetGasList();
                            foreach (Vehicle vehicle in gasCar)
                            {
                                Console.WriteLine($"{vehicle.CarID}|{vehicle.Name}: {vehicle.Info} ");
                                Console.WriteLine("Enter number ID you would like to Edit");
                                int response = int.Parse(Console.ReadLine());
                                if (vehicle.CarID == response)
                                {
                                    Console.WriteLine($"1. Car: {vehicle.Name}\n" +
                                        $"2. Info: {vehicle.Info}\n" +
                                        $"3. Car Type: {vehicle.Type}\n" +
                                        $"4. Return to Menu\n" +
                                        $"Enter number to update: ");
                                    int updateResponse = int.Parse(Console.ReadLine());
                                    switch (updateResponse)
                                    {
                                        case 1:
                                            Console.Write("Enter new Name: ");
                                            vehicle.Name = Console.ReadLine();
                                            break;
                                        case 2:
                                            Console.Write("Enter new Info: ");
                                            vehicle.Info = Console.ReadLine();
                                            break;
                                        case 3:
                                            Console.WriteLine($"Enter new Type...\n" +
                                                $"1. Electric\n" +
                                                $"2. Hybrid\n" +
                                                $"3. Gas\n");
                                            int updatedType = int.Parse(Console.ReadLine());
                                            if (updatedType == 1)
                                            {
                                                if (vehicle.Type == CarType.Hybrid)
                                                {
                                                    repo.RemoveHybridCar(vehicle);
                                                    vehicle.Type = CarType.Electric;
                                                    repo.AddToElectricList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Gas)
                                                {
                                                    repo.RemoveGasCar(vehicle);
                                                    vehicle.Type = CarType.Electric;
                                                    repo.AddToElectricList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Electric)
                                                {
                                                    vehicle.Type = CarType.Electric;
                                                }


                                            }
                                            else if (updatedType == 2)
                                            {
                                                if (vehicle.Type == CarType.Hybrid)
                                                {
                                                    vehicle.Type = CarType.Hybrid;
                                                }
                                                else if (vehicle.Type == CarType.Electric)
                                                {
                                                    repo.RemoveElecCar(vehicle);
                                                    vehicle.Type = CarType.Hybrid;
                                                    repo.AddToHybridList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Gas)
                                                {
                                                    repo.RemoveGasCar(vehicle);
                                                    vehicle.Type = CarType.Hybrid;
                                                    repo.AddToHybridList(vehicle);
                                                }

                                            }
                                            else if (updatedType == 3)
                                            {
                                                if (vehicle.Type == CarType.Hybrid)
                                                {
                                                    repo.RemoveHybridCar(vehicle);
                                                    vehicle.Type = CarType.Gas;
                                                    repo.AddToGasList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Electric)
                                                {
                                                    repo.RemoveElecCar(vehicle);
                                                    vehicle.Type = CarType.Gas;
                                                    repo.AddToGasList(vehicle);
                                                }
                                                else if (vehicle.Type == CarType.Gas)
                                                {
                                                    repo.RemoveGasCar(vehicle);
                                                    vehicle.Type = CarType.Gas;
                                                    repo.AddToGasList(vehicle);
                                                }
                                            }
                                            else
                                                Console.WriteLine("Error..");
                                            break;
                                        case 4:
                                            Console.WriteLine("Press any key to return to menu");
                                            break;
                                        default:
                                            Console.WriteLine("Error...");

                                            break;

                                            
                                    }
                                    break;
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Press any key to return to menu");
                            break;
                        default:
                            Console.WriteLine("Error...");

                            break;
                    }
                    
                }
                else if (input == "4")
                {
                    Console.WriteLine("What type of list would you like to open?\n" +
                        "1. Electric\n" +
                        "2. Hybrid\n" +
                        "3. Gas\n");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            List<Vehicle> elecCar = repo.GetElecList();
                            foreach (Vehicle vehicle in elecCar)
                            {
                            Console.WriteLine($"{vehicle.CarID}|{vehicle.Name}: {vehicle.Info} ");
                            }


                            break;
                        case 2:
                            List<Vehicle> hybCar = repo.GetHybridList();
                            foreach (Vehicle vehicle in hybCar)
                            {
                            Console.WriteLine($"{vehicle.CarID}|{vehicle.Name}: {vehicle.Info} ");
                            }


                            break;
                        case 3:
                            List<Vehicle> gasCar = repo.GetGasList();
                            foreach (Vehicle vehicle in gasCar)
                            Console.WriteLine($"{vehicle.CarID}|{vehicle.Name}: {vehicle.Info} ");

                            break;
                        default:
                            break;
                    }
                    Console.ReadLine();
                }
                else if (input == "5")
                {
                    break;
                }

                
            }
            Console.ReadLine();
        }
    }
}