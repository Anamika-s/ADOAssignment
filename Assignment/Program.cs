namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte ch;
            char choice = 'y';
            while(choice=='y')
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1.Add Record");
                Console.WriteLine("2.Delete Record ");
                Console.WriteLine("3.Edit Record");
                Console.WriteLine("4.List of Employee");
                Console.WriteLine("5.Search Employee By ID");
                Console.WriteLine("Enter Your Choice");
                ch=byte.Parse(Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        {
                            Console.WriteLine("Prees\n1.Oncontract basis\n2.on payroll");
                            int x = Convert.ToInt32(Console.ReadLine());
                            
                            if (x==1)
                            {
                                
                                OnContract onContract = new OnContract();
                                onContract.GetDetails();
                               
                                 CalculateOnContract(onContract.duration, onContract.charges);

                                OnContract employee = new OnContract();
                                Dal dal = new Dal();
                                dal.AddEmployee(1, employee);
                                
                                


                            }
                            else if(x==2)
                            {
                                
                               
                                Console.WriteLine("Enter the Joining Date date: ");
                                DateTime joiningDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the experience");
                                byte exp = byte.Parse(Console.ReadLine());
                                Console.WriteLine("Enter The basic Salary");
                                double basicSalary=Convert.ToDouble(Console.ReadLine());
                                double netSalary = CalculateOnPayroll(basicSalary, exp);
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid Option");
                            }
                            break;
                        }
                }
            }

        }
        public  static double CalculateOnContract(int days,double chargePerDay)
        {
             return days * chargePerDay;
        }
        public static double CalculateOnPayroll(double basicSalary,byte exp)
        {
            double netSalary;
            if (exp > 10)
            {
                netSalary = (((10 / 100) * basicSalary) + ((8.5 / 100) * basicSalary) - 6500);
            }
            else if (exp > 7 && exp < 10)
            {
                netSalary = (((7 / 100) * basicSalary) + ((6.5 / 100) * basicSalary) - 4100);
            }
            else if (exp > 5 && exp < 7)
            {
                netSalary = (((4.1 / 100) * basicSalary) + ((3.8 / 100) * basicSalary) - 1800);
            }
            else
            {
                netSalary = (((1.9 / 100) * basicSalary) + ((2.0 / 100) * basicSalary) - 1200);
            }
            return netSalary;
        }
    }
}