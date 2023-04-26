using EmployeePayRollService;
using System.Net;
using System.Reflection;

namespace EmployeePayRollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenEmployee_WhenAddedToList_ShouldMatchEmployeeEntries()
        {
            List<EmployeeDetails> list = new List<EmployeeDetails>();
            list.Add(new EmployeeDetails(EmployeeId: 1, EmployeeName: "Anand", EmployeeSalary: 10000,StartDate: DateTime.Now, Gender: "M",  EmployeePhNo: "7894561232", Address: "Hyderabad", BasicPay: 2000,  Deductions: 2000,   TaxPayable: 2000, IncomeTax: 2000, NetPay: 2000));
            list.Add(new EmployeeDetails(EmployeeId: 2, EmployeeName: "Sai", EmployeeSalary: 20000, StartDate: DateTime.Now, Gender: "M", EmployeePhNo: "7894561237", Address: "kakinada", BasicPay: 3000, Deductions: 3000, TaxPayable: 3000, IncomeTax: 3000, NetPay: 8000));
            list.Add(new EmployeeDetails(EmployeeId: 3, EmployeeName: "Kumari", EmployeeSalary: 30000, StartDate: DateTime.Now, Gender: "F", EmployeePhNo: "7894565232", Address: "Vizag", BasicPay: 4000, Deductions: 4000, TaxPayable: 4000, IncomeTax: 4000, NetPay: 14000));
            list.Add(new EmployeeDetails(EmployeeId: 4, EmployeeName: "Vijaya", EmployeeSalary: 40000, StartDate: DateTime.Now, Gender: "F", EmployeePhNo: "7894567232", Address: "Vijayawada", BasicPay: 5000, Deductions: 5000, TaxPayable: 5000, IncomeTax: 5000, NetPay: 20000));
            list.Add(new EmployeeDetails(EmployeeId: 5, EmployeeName: "Rowthu", EmployeeSalary: 50000, StartDate: DateTime.Now, Gender: "M", EmployeePhNo: "7894569232", Address: "Rajamundry", BasicPay: 6000, Deductions: 6000, TaxPayable: 6000, IncomeTax: 6000, NetPay: 26000));
            list.Add(new EmployeeDetails(EmployeeId: 6, EmployeeName: "Harsha", EmployeeSalary: 60000, StartDate: DateTime.Now, Gender: "F", EmployeePhNo: "7894564232", Address: "Yanam", BasicPay: 7000, Deductions: 7000, TaxPayable: 7000, IncomeTax: 7000, NetPay: 32000));
            list.Add(new EmployeeDetails(EmployeeId: 7, EmployeeName: "Askar", EmployeeSalary: 70000, StartDate: DateTime.Now, Gender: "M", EmployeePhNo: "7894561132", Address: "Kovvuru", BasicPay: 8000, Deductions: 8000, TaxPayable: 8000, IncomeTax: 8000, NetPay: 38000));
            Operations operations = new Operations();
            DateTime StartDateTime=DateTime.Now;
            operations.AddEmployeeToPayRoll(list);
            DateTime StopDateTime = DateTime.Now;
            Console.WriteLine("Duration without threads: " + (StartDateTime - StopDateTime));

            Console.WriteLine("by using thread");
            DateTime StartDateTimeThread = DateTime.Now;
            operations.AddEmployeeToPayRollByThread(list);
            DateTime StopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with threads: " + (StartDateTime - StopDateTime));
        }
    }
}