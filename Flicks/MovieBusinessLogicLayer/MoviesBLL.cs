using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieEntity;
using MovieExceptions;
using MovieDAL;

namespace MovieBusinessLogicLayer
{
    public class MoviesBLL
    {
        public static void Validate(Movie m)
        {
            try
            {
                if (m == null)
                {
                    throw new MovieNotException("Movie cannot be null.");
                }

                if (m.Mnum <= 0)
                {
                    throw new MovieNotException("Movie ID cannot be less than 1.");
                }

                if (string.IsNullOrEmpty(m.Language) )
                {
                    throw new MovieNotException("Movie language cannot be null.");
                }

                if (m.Language.Length > 30 || m.Language.Length < 0)
                {
                    throw new MovieNotException("Movie language cannot be less than 1 or greater than 30.");
                }

                if (string.IsNullOrEmpty(m.MovieID))
                {
                    throw new MovieNotException("Movie ID cannot be null.");
                }

                if (m.MovieID.Length > 16 || m.MovieID.Length < 0)
                {
                    throw new MovieNotException("Movie title cannot be less than 1 or greater than 30.");
                }

                if (string.IsNullOrEmpty(m.Title))
                {
                    throw new MovieNotException("Movie title cannot be null.");
                }

                if (m.Title.Length > 30 || m.Title.Length < 0)
                {
                    throw new MovieNotException("Movie title cannot be less than 1 or greater than 30.");
                }

                if (string.IsNullOrEmpty(m.Genres))
                {
                    throw new MovieNotException("Movie title cannot be null.");
                }

                if (m.Genres.Length > 30 || m.Genres.Length < 0)
                {
                    throw new MovieNotException("Movie title cannot be less than 1 or greater than 30.");
                }

                if (m.Year <1888 || m.Year > (int) (DateTime.Today.Year) )
                {
                    throw new MovieNotException("Movie Year is not in range.");
                }

                if (m.Rating < 0 || m.Rating > 10 )
                {
                    throw new MovieNotException("Movie Rating is not in range.");
                }

                if (m.StocKavailable > m.TotalStock || m.StocKavailable < 0)
                {
                    throw new MovieNotException("Stock available is not in range.");
                }

                if (m.Bluerayprice <= 0 || m.StocKavailable > 4000000)
                {
                    throw new MovieNotException("price is not in range.");
                }

                if (m.TotalUnitsrented <= 0 || m.TotalUnitsrented > 400000000)
                {
                    throw new MovieNotException("totalunits rented is not in range.");
                }

                if (m.RevenueGenerated <= 0)
                {
                    throw new MovieNotException("Revenue generated is not in range.");
                }

                if (m.TotalStock <= 0)
                {
                    throw new MovieNotException("Total stock is not in range.");
                }
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (FormatException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }

        public bool AddNewMovie(Movie movie)
        {
            MoviesDAL dal = new MoviesDAL();
            var status = dal.AddNewMovie(movie);
            return status;
        }

        public bool UpdateMovie(Movie movie)
        {
            MoviesDAL DAl = new MoviesDAL();
            var status = DAl.UpdateMovie(movie);
            return status;
        }

        public bool DeleteMovie(int ID)
        {
            MoviesDAL DAl = new MoviesDAL();
            var status = DAl.DeleteMovie(ID);
            return status;
        }

        public Movie GetMovie(int ID)
        {
            MoviesDAL DAl = new MoviesDAL();
            Movie movie = new Movie();
            movie = DAl.GetMovie(ID);
            return movie;
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> list = new List<Movie>();
            MoviesDAL DAl = new MoviesDAL();
            list = DAl.GetAllMovies();
            return list;
        }

        public List<Movie> GetAllMoviesByTLG(string vari)
        {
            List<Movie> list = new List<Movie>();
            MoviesDAL dal = new MoviesDAL();
            dal.GetAllMoviesByTLG(vari);
            return list;
        }

        public List<Movie> GetAllMoviesByYear(int year)
        {
            List<Movie> list = new List<Movie>();
            MoviesDAL dal = new MoviesDAL();
            dal.GetAllMoviesByYear(year);
            return list;
        }

        public List<Movie> GetAllhighratedMovies()
        {
            List<Movie> list = new List<Movie>();
            MoviesDAL dal = new MoviesDAL();
            dal.GetAllhighratedMovies();
            return list;
        }

        public List<Movie> GetAllLowRatedMovies()
        {
            List<Movie> list = new List<Movie>();
            MoviesDAL dal = new MoviesDAL();
            dal.GetAllLowRatedMovies();
            return list;
        }

        public List<Movie> GetAllTop10Movies()
        {
            List<Movie> list = new List<Movie>();
            MoviesDAL dal = new MoviesDAL();
            dal.GetAllTop10Movies();
            return list;
        }
    }
}
