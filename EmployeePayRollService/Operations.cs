using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollService
{
    public class Operations
    {
        public static string Connectingstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayRoll";
        SqlConnection connection = new SqlConnection(Connectingstring);
        public void GetALLEmployeePayRollRecords()
        {
            try
            {
                EmployeeDetails employeeDetails = new EmployeeDetails();
                using (this.connection)
                {
                    string query = @"Select * from Employee_PayRoll";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    cmd.CommandType = CommandType.Text;
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeDetails.EmployeeId = reader.GetInt32(0);
                            employeeDetails.EmployeeName = reader.GetString(1);
                            employeeDetails.EmployeeSalary = (int)reader.GetInt64(2);
                            employeeDetails.StartDate = reader.GetDateTime(3); 
                            employeeDetails.Gender = reader.GetString(4);
                            employeeDetails.EmployeePhNo = reader.GetString(5);
                            employeeDetails.Address = reader.GetString(6);
                            employeeDetails.BasicPay = (int)reader.GetInt64(7);
                            employeeDetails.Deductions = (int)reader.GetInt64(8);
                            employeeDetails.TaxPayable = (int)reader.GetInt64(9);
                            employeeDetails.IncomeTax = (int)reader.GetInt64(10);
                            employeeDetails.NetPay = (int)reader.GetInt64(11);
                            Console.WriteLine(employeeDetails.EmployeeId + "\n" + employeeDetails.EmployeeName + "\n" + employeeDetails.EmployeeSalary + "\n" + employeeDetails.StartDate + "\n" + employeeDetails.Gender + "\n" + employeeDetails.EmployeePhNo + "\n" + employeeDetails.Address + "\n" + employeeDetails.BasicPay + "\n" + employeeDetails.Deductions + "\n" + employeeDetails.TaxPayable + "\n" + employeeDetails.IncomeTax + "\n" + employeeDetails.NetPay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Records are available");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void AddEmployee(EmployeeDetails employee)
        {
            try
            {
                EmployeeDetails employeeDetails = new EmployeeDetails();
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("AddEmployee", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeDetails.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeSalary", employeeDetails.EmployeeSalary);

                    cmd.Parameters.AddWithValue("@StartDate", employeeDetails.StartDate);

                    cmd.Parameters.AddWithValue("@Gender", employeeDetails.Gender);

                    cmd.Parameters.AddWithValue("@EmployeePhNo", employeeDetails.EmployeePhNo);

                    cmd.Parameters.AddWithValue("@Address", employeeDetails.Address);

                    cmd.Parameters.AddWithValue("@BasicPay", employeeDetails.BasicPay);

                    cmd.Parameters.AddWithValue("@Deductions", employeeDetails.Deductions);

                    cmd.Parameters.AddWithValue("@TaxPayable", employeeDetails.TaxPayable);

                    cmd.Parameters.AddWithValue("@IncomeTax", employeeDetails.IncomeTax);

                    cmd.Parameters.AddWithValue("@NetPay", employeeDetails.NetPay);

                    this.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (rowsAffected > 0)
                        Console.WriteLine("Employee Added successfully");
                    else
                        Console.WriteLine("Employee Added UNsuccessfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteEmployee(int Id)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteEmployee", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", Id);
                    this.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (rowsAffected > 0)
                        Console.WriteLine("Employee Delted successfully");
                    else
                        Console.WriteLine("Employee Delted UNsuccessfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateEmployee(int Id, string Name)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateEmployee", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", Id);
                    cmd.Parameters.AddWithValue("@EmployeeName", Name);

                    this.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (rowsAffected > 0)
                        Console.WriteLine("Employee Updated successfully");
                    else
                        Console.WriteLine("Employee Updated UNsuccessfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
