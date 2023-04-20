// See https://aka.ms/new-console-template for more information
using System;
using System.Data.SqlTypes;

namespace EmployeePayRollService;
class Program
{
    static void Main(string[] args)
    {
        OperationDepartment operationDepartment = new OperationDepartment();
        Operations operation = new Operations();
        bool flag = true;
        while(flag)
        {
            Console.WriteLine("1.GetALLEmployeePayRollRecords\n2.AddEmployee\n3.DeleteEmployee\n4.UpdateEmployee\n5.GetALLDepartmentRecords");
            Console.WriteLine("Select option :");
            int option=Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
             case 1:
                   operation.GetALLEmployeePayRollRecords();
                   break;
             case 2:
                    EmployeeDetails employeeDetails = new EmployeeDetails()
                    {
                        EmployeeName = "Gowthami",
                        EmployeeSalary = 20000,
                        StartDate = DateTime.Now,
                        Gender = "F",
                        EmployeePhNo = "7845129856",
                        Address = "Nellore",
                        BasicPay = 1000,
                        Deductions = 2000,
                        TaxPayable = 3000,
                        IncomeTax = 4000,
                        NetPay = 10000,
                    };
                    operation.AddEmployee(employeeDetails);
                    break;
                case 3:
                    operation.DeleteEmployee(12);
                    break;
                case 4:
                    operation.UpdateEmployee(2, "SaiRam");
                    break;
                case 5:
                    operationDepartment.GetALLDepartmentRecords();
                    break;
            }
        }
    }
}
