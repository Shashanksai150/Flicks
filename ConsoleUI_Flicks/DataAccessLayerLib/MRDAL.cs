using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityLayerLib;
using ExceptionLib;

namespace DataAccessLayerLib
{
    public class MRDAL
    {
        public List<string> GetRentedMoviesP(string ID)
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Select mr.RentID, c.Name,m.Title,mr.[Rented DateTime],mr.[Returned DateTime],mr.[Days Rented],mr.[Rent Amount],mr.[Paid Or Not] from Customers as c left join [Movies Rented] as mr on mr.[Mobile Number] = c.[Mobile Number] join Movies as m on mr.MID = m.[Movie ID] where cr.[Mobile Number] = '" + ID + "' or cr.MID = '" + ID + "'", cn);
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
                    var ReturnedDate = Convert.ToDateTime(dr[4]);
                    var Daysrented = Convert.ToInt32(dr[5]);
                    var RentAmount = Convert.ToString(dr[6]);
                    var Paidornot = Convert.ToBoolean(dr[7]);
                    string record = RentID + " " + Name + " " + Title + " " + RentedDate + " " + ReturnedDate + " " + Daysrented + " " + RentAmount + " " + Paidornot;
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
        public bool AddMoviesRented(MoviesRented movie)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("sp_InsertMR", cn);
            cmd.Parameters.AddWithValue("@RentID", movie.RentID);
            // cmd.Parameters.AddWithValue("@MID", movie.MID);
            // cmd.Parameters.AddWithValue("@MobileNumber", movie.MobileNumber);
            // cmd.Parameters.AddWithValue("@RentedDateTime", movie.RentedDateTime);
            // cmd.Parameters.AddWithValue("@ReturnedDateTime", movie.ReturnedDateTime);
            // cmd.Parameters.AddWithValue("@DaysRented", movie.DaysRented);
            // cmd.Parameters.AddWithValue("@RentAmount", movie.RentAmount);
            cmd.Parameters.AddWithValue("@Returned", movie.Returned);
            cmd.Parameters.AddWithValue("@PaidorNot", movie.PaidorNot);

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
        public bool UpdateMoviesRented(MoviesRented movie)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Sp_UpdateMR", cn);
            cmd.Parameters.AddWithValue("@RentID", movie.RentID);
            //  cmd.Parameters.AddWithValue("@MovieID", movie.MID);
            //  cmd.Parameters.AddWithValue("@MobileNumber", movie.MobileNumber);
            //   cmd.Parameters.AddWithValue("@RentedDateTime", movie.RentedDateTime);
            //   cmd.Parameters.AddWithValue("@ReturnedDateTime", movie.ReturnedDateTime);
            //   cmd.Parameters.AddWithValue("@DaysRented", movie.DaysRented);
            //   cmd.Parameters.AddWithValue("@RentAmount", movie.RentAmount);
            cmd.Parameters.AddWithValue("@Returned", movie.Returned);
            cmd.Parameters.AddWithValue("@PON", movie.PaidorNot);

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
        public bool DeleteMoviesRented(int ID)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Delete from [MoviesRented] where RentID = '" + ID + "'", cn);
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
        public MoviesRented GetMoviesRented(string ID)
        {
            MoviesRented movie = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from [Movies Rented] where RentID = '" + ID + "'", cn);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    movie = new MoviesRented()
                    {
                        RentID = (string)dr[0],
                        MID = (string)dr[1],
                        MobileNumber = (string)dr[2],
                        RentedDateTime = (DateTime)dr[3],
                        ReturnedDateTime = (DateTime)dr[4],
                        DaysRented = (int)dr[5],
                        RentAmount = (decimal)dr[6],
                        Returned = (bool)dr[7],
                        PaidorNot = (bool)dr[8],

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

            return movie;
        }
        public List<MoviesRented> GetAllMoviesRented()
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from [Movies Rented]", cn);

            List<MoviesRented> list = new List<MoviesRented>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MoviesRented movie = new MoviesRented()
                    {
                        RentID = (string)dr[0],
                        MID = (string)dr[1],
                        MobileNumber = (string)dr[2],
                        RentedDateTime = (DateTime)dr[3],
                        ReturnedDateTime = (DateTime)dr[4],
                        DaysRented = (int)dr[5],
                        RentAmount = (decimal)dr[6],
                        Returned = (bool)dr[7],
                        PaidorNot = (bool)dr[8],
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
        public List<MoviesRented> GetAllMoviesRentedByMobileNumber(string MobileNumber)
        {
            MoviesRented movie = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from [Movies Rented] where [Mobile Number] ='" + MobileNumber + "'", cn);

            List<MoviesRented> list = new List<MoviesRented>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    movie = new MoviesRented()
                    {
                        RentID = (string)dr[0],
                        MID = (string)dr[1],
                        MobileNumber = (string)dr[2],
                        RentedDateTime = (DateTime)dr[3],
                        ReturnedDateTime = (DateTime)dr[4],
                        DaysRented = (int)dr[5],
                        RentAmount = (decimal)dr[6],
                        Returned = (bool)dr[7],
                        PaidorNot = (bool)dr[8],
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
        public List<MoviesRented> GetDaysRented(int DaysRented)
        {
            MoviesRented movie = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from [Movies Rented] where [Days rented] >= " + 1, cn);

            List<MoviesRented> list = new List<MoviesRented>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    movie = new MoviesRented()
                    {
                        RentID = (string)dr[0],
                        MID = (string)dr[1],
                        MobileNumber = (string)dr[2],
                        RentedDateTime = (DateTime)dr[3],
                        ReturnedDateTime = (DateTime)dr[4],
                        DaysRented = (int)dr[5],
                        RentAmount = (decimal)dr[6],
                        Returned = (bool)dr[7],
                        PaidorNot = (bool)dr[8],
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
        public List<MoviesRented> GetRentAmount(double RentAmount)
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from [Movies Rented] where [Rent ID] = " + RentAmount, cn);

            List<MoviesRented> list = new List<MoviesRented>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MoviesRented movie = new MoviesRented()
                    {
                        RentID = (string)dr[0],
                        MID = (string)dr[1],
                        MobileNumber = (string)dr[2],
                        RentedDateTime = (DateTime)dr[3],
                        ReturnedDateTime = (DateTime)dr[4],
                        DaysRented = (int)dr[5],
                        RentAmount = (decimal)dr[6],
                        Returned = (bool)dr[7],
                        PaidorNot = (bool)dr[8],
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
        public List<MoviesRented> GetReturned()
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Movies Rented where [Returned] =  1", cn);

            List<MoviesRented> list = new List<MoviesRented>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MoviesRented movie = new MoviesRented()
                    {
                        RentID = (string)dr[0],
                        MID = (string)dr[1],
                        MobileNumber = (string)dr[2],
                        RentedDateTime = (DateTime)dr[3],
                        ReturnedDateTime = (DateTime)dr[4],
                        DaysRented = (int)dr[5],
                        RentAmount = (decimal)dr[6],
                        Returned = (bool)dr[7],
                        PaidorNot = (bool)dr[8],
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
        public List<MoviesRented> GetPayment()
        {
            MoviesRented movie = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from [Movies Rented] where [Paid Or Not] = 1", cn);

            List<MoviesRented> list = new List<MoviesRented>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    movie = new MoviesRented()
                    {
                        RentID = (string)dr[0],
                        MID = (string)dr[1],
                        MobileNumber = (string)dr[2],
                        RentedDateTime = (DateTime)dr[3],
                        ReturnedDateTime = (DateTime)dr[4],
                        DaysRented = (int)dr[5],
                        RentAmount = (decimal)dr[6],
                        Returned = (bool)dr[7],
                        PaidorNot = (bool)dr[8],
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
