using DAL;

using BusinessObject;
using BO;

namespace BAL
{
    public class Bal
    {
        Dal dal = new Dal();


        public int AddEmployee(Employee emp)
        {

            dal.AddEmployee(emp);
            return 0;
        }
        public int EditEmployee(int id, Employee emp)
        {
            dal.EditEmployee(id, emp);
            return 0;
        }

        public int DeleteEmployee(int id)
        {
            dal.DeleteEmployee(id);
            return 0;
        }
        public List<Employee> GetEmployees()
        {
            return null;
        }

    }
}