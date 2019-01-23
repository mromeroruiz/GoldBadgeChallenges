using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge
{
    public class ObjectRepo
    {
        List<Customer> listOfObjects = new List<Customer>();
        int numberOfCustomers = 0;


        public void NewCustomer(string first, string last, int typeNum)
        {
            numberOfCustomers++;
            Customer newObject = new Customer(numberOfCustomers, first, last, typeNum);
            listOfObjects.Add(newObject);
        }

        public List<Customer> GetList()
        {
            return listOfObjects;
        }

        public void Recount()
        {
            foreach (Customer customer in listOfObjects)
            {
                customer.UserID = (listOfObjects.IndexOf(customer) + 1);
            }

        }

        public void RemoveObject(int userID)
        {
            foreach (Customer customer in listOfObjects)
            {
                if (customer.UserID == userID)
                {
            
            listOfObjects.Remove(customer);
                    break;
                }
            }
            Recount();
            numberOfCustomers--;
        }
    }
}
