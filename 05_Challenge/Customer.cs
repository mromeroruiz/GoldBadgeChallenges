using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge
{
    public enum WorkType { Potential = 1, Past, Current }
    public class Customer
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public WorkType Type { get; set; }


        public Customer(int userID,string firstName, string lastName, string email, WorkType type)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            

        }
        public Customer()
        {

        }

        public Customer(int idOfCustomer, string first, string last, int typeNum)
        {
            UserID = idOfCustomer;
            FirstName = first;
            LastName = last;
            Type = (WorkType)typeNum;
        }
    }
}
