using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollService
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeSalary { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string EmployeePhNo { get; set; }
        public string Address { get; set; }
        public int BasicPay { get; set; }
        public int Deductions { get; set; }
        public int TaxPayable { get; set; }
        public int IncomeTax { get; set; }
        public int NetPay { get; set; }
        public string DeptName { get; set; }
        public int EmpID { get; set; }
    
        public EmployeeDetails(int EmployeeId, string EmployeeName, int EmployeeSalary, DateTime StartDate, string Gender, string EmployeePhNo, string Address, int BasicPay, int Deductions, int TaxPayable, int IncomeTax, int NetPay)
        {
            this.EmployeeId = EmployeeId;
            this.EmployeeName = EmployeeName;
            this.EmployeeSalary = EmployeeSalary;
            this.StartDate = StartDate;
            this.Gender = Gender;
            this.EmployeePhNo = EmployeePhNo;
            this.Address = Address;
            this.BasicPay = BasicPay;
            this.Deductions = Deductions;
            this.TaxPayable = TaxPayable;
            this.IncomeTax = IncomeTax;
            this.NetPay = NetPay;
        }

        public EmployeeDetails()
        {
            this.EmployeeId = EmployeeId;
            this.EmployeeName = EmployeeName;
            this.EmployeeSalary = EmployeeSalary;
            this.StartDate = StartDate;
            this.Gender = Gender;
            this.EmployeePhNo = EmployeePhNo;
            this.Address = Address;
            this.BasicPay = BasicPay;
            this.Deductions = Deductions;
            this.TaxPayable = TaxPayable;
            this.IncomeTax = IncomeTax;
            this.NetPay = NetPay;
        }
    }
}
