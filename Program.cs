using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollService
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeModule service = new EmployeeModule();
            EmployeeRepo employee = new EmployeeRepo();

            service.EmployeeId = Convert.ToInt32("3525");
            service.EmployeeName = "Mohan";
            service.Phonenumber = "9857484573";
            service.Address = "gh road gju apartment";
            service.Department = "IT";
            service.Gender = "M";
            service.BasicPay = Convert.ToDouble("8473");
            service.Deduction = Convert.ToDouble("565");
            service.TaxablePay = Convert.ToDouble("5658");
            service. Tax= Convert.ToDouble("890");
            service.City = "Mumbai";
            service.Country = "India";

            employee.AddEmployee(service);

        }
    }
}
