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
        /*EmployeeDetails employeeDetails = new EmployeeDetails()
       {
            EmployeeName = "Gowthami",
            EmployeeSalary = 20000,
            StartDate = DateTime.Now,
            Gender = "F",
            EmployeePhNo = "7845129856",
            Address = "Nellore",
            BasicPay =1000,
            Deductions = 2000,
            TaxPayable = 3000,
            IncomeTax = 4000,
            NetPay = 10000,
        };
        operation.AddEmployee(employeeDetails);*/
        operation.DeleteEmployee(11);
        //operation.UpdateEmployee(4, "Anand");

    }
}
