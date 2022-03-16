using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayerLib
{

    public class Customers
    {
        string _MobileNumber;

        public string MobileNumber

        {

            get { return _MobileNumber; }

            set

            {

                try

                {

                    _MobileNumber = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }



        string _Password;

        public string Password

        {

            get { return _Password; }

            set

            {

                try

                {

                    _Password = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }



        int _CID;

        public int CID

        {

            get { return _CID; }

            set

            {

                try

                {

                    _CID = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }



        string _Name;

        public string Name

        {

            get { return _Name; }

            set

            {

                try

                {

                    _Name = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }



        string _Category;

        public string Category

        {

            get { return _Category; }

            set

            {

                try

                {

                    _Category = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }

        DateTime _LastPassword;

        public DateTime LastPassword

        {

            get { return _LastPassword; }

            set

            {

                try

                {

                    _LastPassword = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }

        bool _PasswordLimitReached;

        public bool PasswordLimitReached

        {

            get { return _PasswordLimitReached; }

            set

            {

                try

                {

                    _PasswordLimitReached = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }



        int _MoviesRented;

        public int MoviesRented

        {

            get { return _MoviesRented; }

            set

            {

                try

                {

                    _MoviesRented = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }




        string _EmailID;

        public string EmailID

        {

            get { return _EmailID; }

            set

            {

                try

                {

                    _EmailID = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }





        string _Address;

        public string Address

        {

            get { return _Address; }

            set

            {

                try

                {

                    _Address = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }



        string _City;

        public string City

        {

            get { return _City; }

            set

            {

                try

                {

                    _City = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }



        string _Region;

        public string Region

        {

            get { return _Region; }

            set

            {

                try

                {

                    _Region = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }



        string _PostalCode;

        public string PostalCode

        {

            get { return _PostalCode; }

            set

            {

                try

                {

                    _PostalCode = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }




        string _Country;

        public string Country

        {

            get { return _Country; }

            set

            {

                try

                {

                    _Country = value;

                }

                catch (Exception ex) { throw ex; }

            }

        }

    }
}
