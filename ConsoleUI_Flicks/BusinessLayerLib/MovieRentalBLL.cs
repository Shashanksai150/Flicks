using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayerLib;
using ExceptionLib;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayerLib;

namespace BusinessLayerLib
{
    public class MovieRentalBLL
    {
        public static void Validate(MoviesRented m)
        {
            try
            {
                if (m == null)
                {
                    throw new MRNotException("Movies Rented cannot be null.");
                }
                if (string.IsNullOrEmpty(m.RentID))
                {
                    throw new MRNotException("Rent ID cannot be null.");
                }

                if (string.IsNullOrEmpty(m.MID))
                {
                    throw new MRNotException("Movie ID cannot be null.");
                }


                if (string.IsNullOrEmpty(m.MobileNumber))
                {
                    throw new MRNotException("Mobile Number  cannot be null.");
                }


                if (m.DaysRented < 0 || m.DaysRented > 100)
                {
                    throw new MRNotException("Days rented cannot be less than 0 and it cannot be greater than 100");
                }


                if (m.RentAmount < 0)
                {
                    throw new MRNotException("RentAmount  cannot be less than 0.");
                }



            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (FormatException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }


        public bool AddMoviesRented(MoviesRented movie)
        {
            MRDAL dal = new MRDAL();
            var status = dal.AddMoviesRented(movie);
            return status;
        }
        public bool UpdateMoviesRented(MoviesRented movie)
        {
            MRDAL dal = new MRDAL();
            var status = dal.UpdateMoviesRented(movie);
            return status;
        }
        public bool DeleteMoviesRented(int ID)
        {
            MRDAL dal = new MRDAL();
            var status = dal.DeleteMoviesRented(ID);
            return status;
        }
        public MoviesRented GetMoviesRented(string ID)
        {
            MRDAL dal = new MRDAL();
            MoviesRented movie = new MoviesRented();
            movie = dal.GetMoviesRented(ID);
            return movie;
        }
        public List<MoviesRented> GetAllMoviesRented()
        {
            List<MoviesRented> list = new List<MoviesRented>();
            MRDAL dal = new MRDAL();
            list = dal.GetAllMoviesRented();
            return list;
        }

        public List<MoviesRented> GetAllMoviesRentedByMobileNumber(string MobileNumber)
        {
            List<MoviesRented> list = new List<MoviesRented>();
            MRDAL dal = new MRDAL();
            list = dal.GetAllMoviesRentedByMobileNumber(MobileNumber);
            return list;
        }
        public List<MoviesRented> GetDaysRented(int DaysRented)
        {
            List<MoviesRented> list = new List<MoviesRented>();
            MRDAL dal = new MRDAL();
            dal.GetDaysRented(DaysRented);
            return list;
        }
        public List<MoviesRented> GetRentAmount(double RentAmount)
        {
            List<MoviesRented> list = new List<MoviesRented>();
            MRDAL dal = new MRDAL();
            dal.GetRentAmount(RentAmount);
            return list;
        }
        public List<MoviesRented> GetReturned()
        {
            List<MoviesRented> list = new List<MoviesRented>();
            MRDAL dal = new MRDAL();
            list = dal.GetReturned();
            return list;
        }
        public List<MoviesRented> GetPayment()
        {
            List<MoviesRented> list = new List<MoviesRented>();
            MRDAL dal = new MRDAL();
            list = dal.GetPayment();
            return list;
        }

    }
}
