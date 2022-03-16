using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLib;
using EntityLayerLib;
using DataAccessLayerLib;

namespace BusinessLayerLib
{
    public class CurrentlyRentedBLL
    {

        public static void Validate(CurrentlyRented m)
        {
            try
            {
                if (m == null)
                {
                    throw new CRNotException("Currently Rented cannot be null.");
                }
                if (string.IsNullOrEmpty(m.RentID))
                {
                    throw new CRNotException("Rent ID cannot be null.");
                }

                if (string.IsNullOrEmpty(m.MID))
                {
                    throw new CRNotException("Movie ID cannot be null.");
                }


                if (string.IsNullOrEmpty(m.MobileNumber))
                {
                    throw new CRNotException("Mobile Number  cannot be null.");
                }






            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (FormatException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }


        public bool AddCurrentlyRented(CurrentlyRented movie)
        {
            CRDAL dal = new CRDAL();
            var status = dal.AddCurrentlyRented(movie);
            return status;
        }
        public bool UpdateCurrentlyRented(CurrentlyRented movie)
        {
            CRDAL dal = new CRDAL();
            var status = dal.UpdateCurrentlyRented(movie);
            return status;
        }
        public bool DeleteMoviesRented(int ID)
        {
            CRDAL dal = new CRDAL();
            var status = dal.DeleteCurrentlyRented(ID);
            return status;
        }

        public List<CurrentlyRented> GetAllCurrentlyRented()
        {
            List<CurrentlyRented> list = new List<CurrentlyRented>();
            CRDAL dal = new CRDAL();
            list = dal.GetAllCurrentlyRented();
            return list;
        }

        public List<CurrentlyRented> GetAllMoviesRentedByMobileNumber(string MobileNumber)
        {
            List<CurrentlyRented> list = new List<CurrentlyRented>();
            CRDAL dal = new CRDAL();
            list = dal.GetAllCurrentlyRentedByMobileNumber(MobileNumber);
            return list;
        }

        public List<string> GetCurrentlyRentedMovie(string num)
        {
            List <string> list = new List<string>();
            CRDAL dal = new CRDAL();
            list = dal.GetCurrentlyRentedMovie(num);
            return list;
        }

    }
}
