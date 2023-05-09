using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1
{
    internal class Dal
    {
        static SqlConnection connection;
        static SqlCommand command;

        private static string GetConnectionString()
        {
            return @"data source=ANAMIKA\SQLSERVER;initial catalog=EmpDb;integrated security=true";
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        public void AddEmployee(int type, Employee employee)
        {
            
            if (employee is OnContract)
            {

                try
                {
                    connection = GetConnection();
                    command = new SqlCommand();
                    if (type == 1)
                    {
                        command.CommandText = "Insert into Employee(name, emp_type,Reporting_Manager," +
                            "Contract_Basis,Chargers_PerDay, Duration_In_Days," +
                            "OnContract_FinalSalary)" +
                            " values (@name, 1, @Reporting_Manager, @Contract_Basis, " +
                            "@Chargers_PerDay,@Duration, @OnContract_FinalSalary)";

                        command.Connection = connection;
                        command.Parameters.AddWithValue("@name", employee.name);
                        command.Parameters.AddWithValue("@Reporting_Manager", employee.reportingManager);
                        command.Parameters.AddWithValue("@Contract_Basis", ((OnContract)employee).contractDate);
                        command.Parameters.AddWithValue("@Chargers_PerDay", ((OnContract)employee).charges);
                        command.Parameters.AddWithValue("@Duration", ((OnContract)employee).duration);
                        command.Parameters.AddWithValue("@OnContract_FinalSalary", ((OnContract)employee).paymentAmt);

                    }
                    else if (employee is OnPayroll)
                    {
                        command.CommandText = "Insert into Employee(name, emp_type," +
                            "Reporting_Manager, Joining_Date,Experience,Basic_salary," +
                            "NetSalary,DA,HRA,PF) values " +
                            "(@name,2, @Reporting_Manager,@Joining_Date,@Experience,@Basic_salary,@NetSalary,@DA,@HRA,@PF)";

                        command.Connection = connection;
                        command.Parameters.AddWithValue("@name", employee.name);
                        command.Parameters.AddWithValue("@Reporting_Manager", employee.reportingManager);
                        command.Parameters.AddWithValue("@Joining_Date", ((OnPayroll)employee).joiningDate);
                        command.Parameters.AddWithValue("@xp", ((OnPayroll)employee).exp);
                        command.Parameters.AddWithValue("@basicSalary", ((OnPayroll)employee).basicSalary);
                        command.Parameters.AddWithValue("@hra", ((OnPayroll)employee).hra);
                        command.Parameters.AddWithValue("@pf", ((OnPayroll)employee).pf);
                        command.Parameters.AddWithValue("@netSalary", ((OnPayroll)employee).netSalary);

                    }
                        connection.Open();


                        int count = command.ExecuteNonQuery();
                        if (count > 0)
                        {
                            Console.WriteLine("Record has been added");
                        }
                        else
                            Console.WriteLine("Some Error came");
                    }
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
        }
        public void EditEmployee(int id, Employee employee)
        {

        }
        public void DeleteEmployee(int id)
        {
        }
        public List<Employee> GetEmpoloyees()
        {
            return new List<Employee>();
        }
        public Employee GetEmployee(int id)
        {
            return null;
        }


    }

}
