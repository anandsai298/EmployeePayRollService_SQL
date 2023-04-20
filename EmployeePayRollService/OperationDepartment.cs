using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollService
{
    public class OperationDepartment
    {
        public static string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayRoll";
        SqlConnection connection = new SqlConnection(connectionstring);
        public void GetALLDepartmentRecords()
        {
            try
            {
                EmployeeDetails employeeDetails = new EmployeeDetails();
                using (this.connection)
                {
                    string queryD = @"select * from Department";
                    SqlCommand cmd = new SqlCommand(queryD, this.connection);
                    cmd.CommandType = CommandType.Text;
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeDetails.EmployeeId= reader.GetInt32(0);
                            employeeDetails.DeptName = reader.GetString(1);
                            employeeDetails.EmpID = reader.GetInt32(2);
                            
                            Console.WriteLine(employeeDetails.EmployeeId + "\n"+employeeDetails.DeptName + "\n" + employeeDetails.EmpID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Records are available");
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
