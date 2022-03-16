using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayerLib;
using ExceptionLib;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerLib
{
    public class CRDAL
    {
        public List<string> GetCurrentlyRentedMovie(string ID)
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Select cr.RentID, c.Name,m.Title,cr.[Rented DateTime] from Customers as c left join[Currently Rented] as cr on cr.[Mobile Number] = c.[Mobile Number] join Movies as m on cr.MID = m.[Movie ID] where cr.[Mobile Number] = '" + ID + "' or cr.MID = '" + ID + "'", cn);
            List<string> ret = new List<string>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var RentID = Convert.ToString(dr[0]);
                    var Name = Convert.ToString(dr[1]);
                    var Title = Convert.ToInt32(dr[2]);
                    var RentedDate = Convert.ToDateTime(dr[3]);
                    string record = RentID + " " + Name + " " + Title + " " + RentedDate;
                    ret.Add(record);
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
            return ret;
        }

        public bool AddCurrentlyRented(CurrentlyRented movie)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("sp_InsertCR", cn);
            //cmd.Parameters.AddWithValue("@RentID", movie.RentID);
            cmd.Parameters.AddWithValue("@MID", movie.MID);
            cmd.Parameters.AddWithValue("@MN", movie.MobileNumber);
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

        public bool UpdateCurrentlyRented(CurrentlyRented movie)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True"; ;
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Sp_UpdateCR", cn);
            cmd.Parameters.AddWithValue("@RentID", movie.RentID);

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

        public bool DeleteCurrentlyRented(int ID)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Delete from [currentlyRented] where MID=" + ID + "or RentID = " + ID, cn);
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

        public List<CurrentlyRented> GetAllCurrentlyRented()
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from [Currently Rented]", cn);

            List<CurrentlyRented> list = new List<CurrentlyRented>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CurrentlyRented movie = new CurrentlyRented()
                    {
                        RentID = (string)dr[0],
                        MID = (string)dr[1],
                        MobileNumber = (string)dr[2],
                        RentedDateTime = (DateTime)dr[3],
                        // ReturnedDateTime = (DateTime)dr[4],


                    };
                    list.Add(movie);
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

        public List<CurrentlyRented> GetAllCurrentlyRentedByMobileNumber(string MobileNumber)
        {
            CurrentlyRented movie = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from [Currently Rented] where [Mobile Number] = '" + MobileNumber + "'", cn);

            List<CurrentlyRented> list = new List<CurrentlyRented>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    movie = new CurrentlyRented()
                    {
                        RentID = (string)dr[0],
                        MID = (string)dr[1],
                        MobileNumber = (string)dr[2],
                        RentedDateTime = (DateTime)dr[3],
                        //ReturnedDateTime = (DateTime)dr[4],

                    };
                    list.Add(movie);
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

    }
}
