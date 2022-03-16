using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityLayerLib;
using ExceptionLib;
using System.Data;

namespace DataAccessLayerLib
{
    public class MoviesDAL
    {
        public bool AddNewMovie(Movie movie)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("sp_InsertMovie", cn);
            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@year", movie.Year);
            cmd.Parameters.AddWithValue("@Language", movie.Language);
            cmd.Parameters.AddWithValue("@Genres", movie.Genres);
            cmd.Parameters.AddWithValue("@BlueRayPrice", movie.Bluerayprice);
            cmd.Parameters.AddWithValue("@Rating", movie.Rating);
            cmd.Parameters.AddWithValue("@TS", movie.TotalStock);

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

        public bool UpdateMovie(Movie movie)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Sp_UpdateMovie", cn);
            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@year", movie.Year);
            cmd.Parameters.AddWithValue("@Language", movie.Language);
            cmd.Parameters.AddWithValue("@Genres", movie.Genres);
            cmd.Parameters.AddWithValue("@BlueRayPrice", movie.Bluerayprice);
            cmd.Parameters.AddWithValue("@Rating", movie.Rating);
            cmd.Parameters.AddWithValue("@TS", movie.TotalStock);

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

        public bool DeleteMovie(string ID)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("delete from Movies where MovieID='" + ID + "'or Mnum = " + ID, cn);
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

        public Movie GetMovie(int ID)
        {
            Movie movie = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Movies where Mnum = " + ID + "or MovieID = " + ID, cn);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    movie = new Movie()
                    {
                        MovieID = (string)dr[0],
                        Title = (string)dr[1],
                        Mnum = (int)dr[2],
                        Language = (string)dr[3],
                        Genres = (string)dr[4],
                        Year = (int)dr[5],
                        Rating = (decimal)dr[6],
                        StocKavailable = (int)dr[7],
                        TotalStock = (int)dr[8],
                        Bluerayprice = (double)dr[9],
                        TotalUnitsrented = (int)dr[10],
                        RevenueGenerated = (double)dr[11]
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

        public Movie GetMovie(string MID)
        {
            Movie movie = new Movie();
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Movies where [Movie ID] = '" + MID + "'", cn);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    movie.MovieID = Convert.ToString(dr[0]);
                    movie.Title = Convert.ToString(dr[1]);
                    movie.Mnum = Convert.ToInt32(dr[2]);
                    movie.Language = Convert.ToString(dr[3]);
                    movie.Genres = Convert.ToString(dr[4]);
                    movie.Year = Convert.ToInt32(dr[5]);
                    movie.Rating = Convert.ToDecimal(dr[6]);
                    movie.StocKavailable = Convert.ToInt32(dr[7]);
                    movie.TotalStock = Convert.ToInt32(dr[8]);
                    movie.Bluerayprice = (double)Convert.ToDecimal(dr[9]);
                    movie.TotalUnitsrented = Convert.ToInt32(dr[10]);
                    movie.RevenueGenerated = (double)Convert.ToDecimal(dr[11]);

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

        public List<Movie> GetAllMovies()
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Movies order by Mnum", cn);

            List<Movie> list = new List<Movie>();

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Movie movie = new Movie();
                movie.MovieID = Convert.ToString(dr[0]);
                movie.Title = Convert.ToString(dr[1]);
                movie.Mnum = Convert.ToInt32(dr[2]);
                movie.Language = Convert.ToString(dr[3]);
                movie.Genres = Convert.ToString(dr[4]);
                movie.Year = Convert.ToInt32(dr[5]);
                movie.Rating = Convert.ToDecimal(dr[6]);
                movie.StocKavailable = Convert.ToInt32(dr[7]);
                movie.TotalStock = Convert.ToInt32(dr[8]);
                movie.Bluerayprice = (double)Convert.ToDecimal(dr[9]);
                movie.TotalUnitsrented = Convert.ToInt32(dr[10]);
                movie.RevenueGenerated = (double)Convert.ToDecimal(dr[11]);
                list.Add(movie);

            }


            cn.Close();
            cn.Dispose();


            return list;
        }

        public List<Movie> GetAllMoviesByTLG(string vari)
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Movies where Title = '" + vari + "' or Title like '" + vari + "%'"
                                                               + "or Language = '" + vari + "' or Language like '" + vari + "%'"
                                                               + "or Genres = '" + vari + "' or Genres like '" + vari + "%'", cn);

            List<Movie> list = new List<Movie>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Movie movie = new Movie();
                    movie.MovieID = Convert.ToString(dr[0]);
                    movie.Title = Convert.ToString(dr[1]);
                    movie.Mnum = Convert.ToInt32(dr[2]);
                    movie.Language = Convert.ToString(dr[3]);
                    movie.Genres = Convert.ToString(dr[4]);
                    movie.Year = Convert.ToInt32(dr[5]);
                    movie.Rating = Convert.ToDecimal(dr[6]);
                    movie.StocKavailable = Convert.ToInt32(dr[7]);
                    movie.TotalStock = Convert.ToInt32(dr[8]);
                    movie.Bluerayprice = (double)Convert.ToDecimal(dr[9]);
                    movie.TotalUnitsrented = Convert.ToInt32(dr[10]);
                    movie.RevenueGenerated = (double)Convert.ToDecimal(dr[11]);
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

        public List<Movie> GetAllMoviesByYear(int year)
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Movies where Year = " + year, cn);

            List<Movie> list = new List<Movie>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Movie movie = new Movie();
                    movie.MovieID = Convert.ToString(dr[0]);
                    movie.Title = Convert.ToString(dr[1]);
                    movie.Mnum = Convert.ToInt32(dr[2]);
                    movie.Language = Convert.ToString(dr[3]);
                    movie.Genres = Convert.ToString(dr[4]);
                    movie.Year = Convert.ToInt32(dr[5]);
                    movie.Rating = Convert.ToDecimal(dr[6]);
                    movie.StocKavailable = Convert.ToInt32(dr[7]);
                    movie.TotalStock = Convert.ToInt32(dr[8]);
                    movie.Bluerayprice = (double)Convert.ToDecimal(dr[9]);
                    movie.TotalUnitsrented = Convert.ToInt32(dr[10]);
                    movie.RevenueGenerated = (double)Convert.ToDecimal(dr[11]);
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

        public List<Movie> GetAllhighratedMovies()
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Movies where Rating >= " + 6, cn);

            List<Movie> list = new List<Movie>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Movie movie = new Movie();
                    movie.MovieID = Convert.ToString(dr[0]);
                    movie.Title = Convert.ToString(dr[1]);
                    movie.Mnum = Convert.ToInt32(dr[2]);
                    movie.Language = Convert.ToString(dr[3]);
                    movie.Genres = Convert.ToString(dr[4]);
                    movie.Year = Convert.ToInt32(dr[5]);
                    movie.Rating = Convert.ToDecimal(dr[6]);
                    movie.StocKavailable = Convert.ToInt32(dr[7]);
                    movie.TotalStock = Convert.ToInt32(dr[8]);
                    movie.Bluerayprice = (double)Convert.ToDecimal(dr[9]);
                    movie.TotalUnitsrented = Convert.ToInt32(dr[10]);
                    movie.RevenueGenerated = (double)Convert.ToDecimal(dr[11]);
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

        public List<Movie> GetAllLowRatedMovies()
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Movies where Rating < " + 6, cn);

            List<Movie> list = new List<Movie>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Movie movie = new Movie();
                    movie.MovieID = Convert.ToString(dr[0]);
                    movie.Title = Convert.ToString(dr[1]);
                    movie.Mnum = Convert.ToInt32(dr[2]);
                    movie.Language = Convert.ToString(dr[3]);
                    movie.Genres = Convert.ToString(dr[4]);
                    movie.Year = Convert.ToInt32(dr[5]);
                    movie.Rating = Convert.ToDecimal(dr[6]);
                    movie.StocKavailable = Convert.ToInt32(dr[7]);
                    movie.TotalStock = Convert.ToInt32(dr[8]);
                    movie.Bluerayprice = (double)Convert.ToDecimal(dr[9]);
                    movie.TotalUnitsrented = Convert.ToInt32(dr[10]);
                    movie.RevenueGenerated = (double)Convert.ToDecimal(dr[11]);
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

        public List<Movie> GetAllTop10Movies()
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Movies where [Total Units rented] > 100", cn);

            List<Movie> list = new List<Movie>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Movie movie = new Movie();
                    movie.MovieID = Convert.ToString(dr[0]);
                    movie.Title = Convert.ToString(dr[1]);
                    movie.Mnum = Convert.ToInt32(dr[2]);
                    movie.Language = Convert.ToString(dr[3]);
                    movie.Genres = Convert.ToString(dr[4]);
                    movie.Year = Convert.ToInt32(dr[5]);
                    movie.Rating = Convert.ToDecimal(dr[6]);
                    movie.StocKavailable = Convert.ToInt32(dr[7]);
                    movie.TotalStock = Convert.ToInt32(dr[8]);
                    movie.Bluerayprice = (double)Convert.ToDecimal(dr[9]);
                    movie.TotalUnitsrented = Convert.ToInt32(dr[10]);
                    movie.RevenueGenerated = (double)Convert.ToDecimal(dr[11]);
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
