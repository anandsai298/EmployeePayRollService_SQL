// See https://aka.ms/new-console-template for more information
using System;
using System.Data.SqlTypes;

namespace EmployeePayRollService;
class Program
{
    static void Main(string[] args)
    {
        Operations operation = new Operations();
        //operation.GetALLEmployeePayRollRecords();
        EmployeeDetails employeeDetails = new EmployeeDetails()
       {
            EmployeeName = "Arjun",
            EmployeeSalary = 20000,
            StartDate = DateTime.Now,
            Gender = "M",
            EmployeePhNo = "7418529637",
            Address = "Vizag",
            BasicPay =1000,
            Deductions = 2000,
            TaxPayable = 3000,
            IncomeTax = 4000,
            NetPay = 10000,
        };
        operation.AddEmployee(employeeDetails);
        //operation.DeleteEmployee(id);
        //operation.UpdateEmployee(4, "Anand");

    }
}
