using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayerLib;
using System.Data;
using System.Data.SqlClient;
using ExceptionLib;

namespace DataAccessLayerLib
{
    public class CustomersDAL
    {
        public bool AddNewCustomer(Customers customer)
        {
            
            
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("sp_InsertCustomers", cn);
            cmd.Parameters.AddWithValue("@MobileNumber", customer.MobileNumber);
            cmd.Parameters.AddWithValue("@password", customer.Password);
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@Category", customer.Category);
            cmd.Parameters.AddWithValue("@EmailID", customer.EmailID);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@Region", customer.Region);
            cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
            cmd.Parameters.AddWithValue("@Country", customer.Country);


            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    status = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return status;

        }

        public bool UpdateCustomer(Customers customer)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Sp_UpdateCustomers", cn);
            cmd.Parameters.AddWithValue("@MobileNumber", customer.MobileNumber);
            cmd.Parameters.AddWithValue("@password", customer.Password);
            cmd.Parameters.AddWithValue("@Name", customer.Name);          
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@Region", customer.Region);
            cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
            cmd.Parameters.AddWithValue("@Country", customer.Country);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    status = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return status;
        }
        public bool DeleteCustomer(string number)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("delete from Customers where [Mobile Number] = '" + number + "'", cn);
            try
            {
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    status = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return status;
        }
        public static bool CustomerpasswordvalicheckMovie(string number)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("[dbo].Sp_PasswordvalidityCustomer", cn);
            cmd.Parameters.AddWithValue("@number", number);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    status = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return status;
        }
        public static bool CustomerpasswordReset(string number, string npass)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("update Customers set [Password] = '"+ npass + "' where [Mobile Number] = '" + number + "'", cn);
            
            try
            {
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    status = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return status;
        }

        public Customers GetCustomer(string MobileNumber)
        {
            Customers Customer = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Customers where [Mobile Number] = '" + MobileNumber + "'", cn);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Customer = new Customers()
                    {
                        MobileNumber = (string)dr[0],
                        Password = (string)dr[1],
                        CID = (int)dr[2],
                        Name = (string)dr[3],
                        Category = (string)dr[4],
                        LastPassword = (DateTime)dr[5],
                        PasswordLimitReached = (bool)dr[6],
                        MoviesRented = (int)dr[7],
                        EmailID = (string)dr[8],
                        Address = (string)dr[9],
                        City = (string)dr[10],
                        Region = (string)dr[11],
                        PostalCode = (string)dr[12],
                        Country = (string)dr[13]
                    };

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return Customer;
        }

        public List<Customers> GetAllCustomers()
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Customers", cn);

            List<Customers> list = new List<Customers>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Customers Customer = new Customers()
                    {
                        MobileNumber = (string)dr[0],
                        Password = (string)dr[1],
                        CID = (int)dr[2],
                        Name = (string)dr[3],
                        Category = (string)dr[4],
                        LastPassword = (DateTime)dr[5],
                        PasswordLimitReached = (bool)dr[6],
                        MoviesRented = (int)dr[7],
                        EmailID = (string)dr[8],
                        Address = (string)dr[9],
                        City = (string)dr[10],
                        Region = (string)dr[11],
                        PostalCode = (string)dr[12],
                        Country = (string)dr[13]

                    };
                    list.Add(Customer);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return list;
        }
        public static void LoginCustomer(string Number, string Password)
        {
            Customers customer = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Customers where [Mobile Number] = '" + Number + "'" + "and [Password] = '" + Password + "'", cn);

            try
            {
                CustomerpasswordvalicheckMovie(Number);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Console.WriteLine("Login successfull");
                    customer = new Customers()
                    {
                        MobileNumber = (string)dr[0],
                        Password = (string)dr[1],
                        CID = (int)dr[2],
                        Name = (string)dr[3],
                        Category = (string)dr[4],
                        LastPassword = (DateTime)dr[5],
                        PasswordLimitReached = (bool)dr[6],
                        MoviesRented = (int)dr[7],
                        EmailID = (string)dr[8],
                        Address = (string)dr[9],
                        City = (string)dr[10],
                        Region = (string)dr[11],
                        PostalCode = (string)dr[12],
                        Country = (string)dr[13]
                    };
                }
                else
                {
                    Console.WriteLine("Login unsuccessfull");
                }

                if (customer.PasswordLimitReached)
                {
                    Console.WriteLine("Password expired, please enter a new password");
                    var npass = Console.ReadLine();
                    CustomerpasswordReset(Number, npass);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cn.Close();
                cn.Dispose();
            }
            
        }
    }
}
