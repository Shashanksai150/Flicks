using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieEntity;
using MovieExceptions;

namespace MovieDAL
{
    public class MoviesDAL
    {
        public bool AddNewMovie(Movie movie)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=Flicks;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Sp_AddBlogger", cn);
            cmd.Parameters.AddWithValue("@BloggerID", blogger.BloggerID);
            cmd.Parameters.AddWithValue("@BloggerName", blogger.BloggerName);
            cmd.Parameters.AddWithValue("@BloggerSubject", blogger.BloggerSubject);

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
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=CapgTDB;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("Sp_UpdateBlogger", cn);
            cmd.Parameters.AddWithValue("@BloggerID", blogger.BloggerID);
            cmd.Parameters.AddWithValue("@BloggerName", blogger.BloggerName);
            cmd.Parameters.AddWithValue("@BloggerSubject", blogger.BloggerSubject);

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

        public bool DeleteMovie(int ID)
        {
            bool status = false;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=CapgTDB;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("delete from Blogger where BloggerID=" + ID, cn);
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
            Blogger blogger = null;
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=CapgTDB;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Blogger where BloggerID = " + ID, cn);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    blogger = new Blogger()
                    {
                        BloggerID = (int)dr[0],
                        BloggerName = (string)dr[1],
                        BloggerSubject = (string)dr[2],
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

            return blogger;
        }

        public List<Movie> GetAllMovies()
        {
            string cnstring = "Data Source=SHARKTOP-96\\SQLEXPRESS;Initial Catalog=CapgTDB;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("select * from Blogger", cn);

            List<Blogger> list = new List<Blogger>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Blogger blogger = new Blogger()
                    {
                        BloggerID = (int)dr[0],
                        BloggerName = (string)dr[1],
                        BloggerSubject = (string)dr[2],
                    };
                    list.Add(blogger);
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
