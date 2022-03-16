using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayerLib;
using ExceptionLib;

namespace DataAccessLayerLib
{
    public class AdminDAL
    {
        public Admin LoginAdmin(string AdminID, string Password)
        {
            Admin admin = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Admin where AdminID = '" + AdminID + "'" + "and Password = '" + Password + "'", cn);

            try
            {
                AdminpasswordvalicheckMovie(AdminID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Console.WriteLine("Login successfull");
                    admin = new Admin()
                    {
                        AdminID = (string)dr[0],
                        password = (string)dr[1],                       
                        AdminName = (string)dr[2],                   
                        lastPassword = (DateTime)dr[4],
                        LimitReached = (bool)dr[5],
                        
                    };
                    if (AdminpasswordvalicheckMovie(AdminID))
                    {
                        Console.WriteLine("Password expired, please enter a new password");
                        var npass = Console.ReadLine();
                        AdminpasswordReset(AdminID, npass);
                    }
                }
                else
                {
                    Console.WriteLine("Login unsuccessfull");
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
            return admin;
        }

        public static bool AdminpasswordvalicheckMovie(string AID)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("[dbo].Sp_PasswordvalidityAdmin", cn);
            cmd.Parameters.AddWithValue("@AdminID", AID);

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

        

        public bool AdminpasswordReset(string AID, string npass)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("[dbo].Sp_PasswordResetAdmin", cn);
            cmd.Parameters.AddWithValue("@AdminID", AID);
            cmd.Parameters.AddWithValue("@Paswordnew", npass);
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
        public bool AddNewAdmin(Admin admin)
            {
                
                bool status = false;
                string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
                SqlConnection cn = new SqlConnection(cnstring);
                SqlCommand cmd = new SqlCommand("sp_InsertAdmin", cn);
                
                cmd.Parameters.AddWithValue("@password", admin.password);
                cmd.Parameters.AddWithValue("@Name", admin.AdminName);
                cmd.Parameters.AddWithValue("@LastPasswordChanged", admin.lastPassword);
                cmd.Parameters.AddWithValue("@PasswordLimitReached", admin.LimitReached);
                cmd.Parameters.AddWithValue("@AdminID", admin.AdminID);


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

            public bool UpdateAdmin(Admin admin)
            {
                bool status = false;
                string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
                SqlConnection cn = new SqlConnection(cnstring);
                SqlCommand cmd = new SqlCommand("Sp_UpdateAdmin", cn);
                cmd.Parameters.AddWithValue("@password", admin.password);
                cmd.Parameters.AddWithValue("@Name", admin.AdminName);
                cmd.Parameters.AddWithValue("@LastPasswordChanged", admin.lastPassword);
                cmd.Parameters.AddWithValue("@PasswordLimitReached", admin.LimitReached);
                cmd.Parameters.AddWithValue("@AdminID", admin.AdminID);

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
            public bool DeleteAdmin(string AID)
            {
                bool status = false;
                string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
                SqlConnection cn = new SqlConnection(cnstring);
                SqlCommand cmd = new SqlCommand("delete from Admin where AID= '" + AID + "'", cn);
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
        }
    }

