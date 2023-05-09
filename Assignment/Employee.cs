using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Employee
    {
        int id;
        public string name;
        public string reportingManager;
        public virtual void GetDetails()
        {
           
            Console.WriteLine("Enter The Employee Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter The reporting manager Name");
            reportingManager = Console.ReadLine();
        }
        public void DisplayDetails()
        {
            Console.WriteLine("The Id is {0} ", id);
            Console.WriteLine("The name of the Employee is {0} ", name);
            Console.WriteLine("The Reporting Manager is {0}", reportingManager);
        }
    }
}
