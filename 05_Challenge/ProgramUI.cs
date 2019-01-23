using System;
using System.Collections.Generic;

namespace _05_Challenge
{
    internal class ProgramUI
    {
        private ObjectRepo repo;
        private bool keeprunning = true;
        private List<Customer> objects;
        String input = null;
        public ProgramUI()

        {
            repo = new ObjectRepo();
            objects = repo.GetList();
        }

        internal void Run()
        {
            while (keeprunning)
            {
                Console.Clear();
                Menu();
            }
            Console.ReadLine();
        }

        private void Menu()
        {
            Customer newObject = new Customer();
            Console.Clear();
            Console.WriteLine($"Welcome, what would you like to do?\n" +
                $"1.Add a customer\n" +
                $"2.View all users\n" +
                $"3.Update a customer\n" +
                $"4.Remove a user\n" +
                $"5. Exit\n");
            input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("What's the first name?");
                string newFirstName = Console.ReadLine();
                Console.WriteLine("What's the last name?");
                string newLastName = Console.ReadLine();
                Console.WriteLine($"Which type of customer?\n" +
                    $"1. Potential\n" +
                    $"2. Current\n" +
                    $"3. Past\n");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        newObject.Type = WorkType.Potential;
                        break;
                    case 2:
                        newObject.Type = WorkType.Current;
                        break;
                    case 3:
                        newObject.Type = WorkType.Past;
                        break;
                    default:
                        Console.WriteLine("Error..");
                        break;
                }

                repo.NewCustomer(newFirstName, newLastName, choice);
            }
            else if (input == "2")
            {
                
                Console.Clear();
                Console.WriteLine("UserID\tFirst\tLast\tCustomer Type\tEmailSent");
                repo.Recount();
                //objects.Sort() TRY TO FIGURE OUT HOW TO SORT //
                foreach (Customer customer in objects)
                {
                    switch (customer.Type)
                    {
                        case WorkType.Potential:
                            newObject.Email = "\tWe currently have the lowest rates on Helicopter Insurance!";
                            break;
                        case WorkType.Current:
                            newObject.Email = "\tThank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                            break;
                        case WorkType.Past:
                            newObject.Email = "\tIt's been a long time since we've heard from you, we want you back";
                            break;
                    }
                    Console.WriteLine($"{customer.UserID} {customer.FirstName, 10} {customer.LastName, 9} {customer.Type, 10}  {newObject.Email, 13}");
                }   
                Console.ReadLine();

            }
            else if (input == "3")
            {
                Console.Clear();
                Console.WriteLine("Enter the number ID you would like to update:");
                int response = int.Parse(Console.ReadLine());

                foreach (Customer customer in objects)
                {
                    if (customer.UserID == response)
                    {
                        Console.WriteLine($"1. First Name: {customer.FirstName}\n" +
                            $"2. Last Name: {customer.LastName}\n" +
                            $"3. Customer Type: {customer.Type}\n" +
                            $"4. Return to Menu\n" +
                            $"Enter number to update: ");
                        int updateResponse = int.Parse(Console.ReadLine());
                        switch (updateResponse)
                        {
                            case 1:
                                Console.Write("Enter new First Name: ");
                                customer.FirstName = Console.ReadLine();
                                break;
                            case 2:
                                Console.Write("Enter new Last Name: ");
                                customer.LastName = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine($"Enter new Type...\n" +
                                    $"1. Potential\n" +
                                    $"2. Current\n" +
                                    $"3. Past\n");
                                int updatedType = int.Parse(Console.ReadLine());
                                if (updatedType == 1)
                                    customer.Type = WorkType.Potential;
                                else if (updatedType == 2)
                                    customer.Type = WorkType.Current;
                                else if (updatedType == 3)
                                    customer.Type = WorkType.Past;
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

            }
            else if(input == "4")
            {
                Console.Clear();
                //Removing a Customer
                Console.WriteLine("Enter the Customers ID which you would like to remove.");
                int response = int.Parse(Console.ReadLine());
                repo.RemoveObject(response);

                foreach (Customer customer in objects)
                {
                    if (customer.UserID == response)
                    {
                        Console.WriteLine($"User has been deleted");
                        Console.ReadLine();
                    }
                    else

                        Console.WriteLine("Error..");
                    Console.ReadLine();
                }
            }
        }
    }
}
