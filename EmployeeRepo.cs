using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollService
{
    public class EmployeeRepo
    {
        public static string connectionstring = "Data Source=(localdb)//MSSQLLocalDB;Initial Catalog=EmployeePayRollService;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionstring);

        public void GetAllEmployee()
        {
            try
            {
                EmployeeModule employeeModel = new EmployeeModule();
                using (this.connection)
                {
                    string query = @"select EmployeeID";
                    SqlCommand cmd = new SqlCommand(query,this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader(); 
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            employeeModel.EmployeeId = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.Phonenumber = dr.GetString(2);
                            employeeModel.Address= dr.GetString(3);

                            Console.WriteLine(employeeModel.EmployeeId);
                            Console.WriteLine(employeeModel.EmployeeName);
                            Console.WriteLine(employeeModel.Phonenumber);
                            Console.WriteLine(employeeModel.Address);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool AddEmployee(EmployeeModule model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("EmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.Phonenumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deduction);
                    command.Parameters.AddWithValue("@Taxablepay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@Netpay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
            
}
