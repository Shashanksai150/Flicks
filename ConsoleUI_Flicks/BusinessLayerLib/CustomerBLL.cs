using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerLib;
using ExceptionLib;
using EntityLayerLib;

namespace BusinessLayerLib
{
    public class CustomerBLL
    {
        
        public static void Validate(Customers C)
        {
            try
            {
                if (C == null)
                {
                    throw new CustomerNotException("Customer cannot be null.");
                }

               

                if (C.Password.Length > 15 || C.Password.Length < 0)
                {
                    throw new CustomerNotException("Customer password cannot be null or too long.");
                }

                if (C.MobileNumber.Length > 10 || C.MobileNumber.Length < 0)
                {
                    throw new CustomerNotException("Customer PhoneNumber cannot be less than 1 or greater than 10.");
                }

                if (C.Name.Length > 50 || C.Name.Length < 0)
                {
                    throw new CustomerNotException("Customer Name cannot be null or greater than 50 characters.");
                }

                if (C.Category.Length > 1 || C.Category.Length < 0)
                {
                    throw new CustomerNotException("Customer Category cannot be less than 0 or greater than 1.");
                }

                if (C.MoviesRented > 5)
                {
                    throw new CustomerNotException("Customer cannot rent more than 5 movies  .");
                }

                if (C.EmailID.Length > 20 || C.EmailID.Length < 0)
                {
                    throw new CustomerNotException("Customer EmailID cannot be less than 1 or greater than 20.");
                }

                if (C.Address.Length > 60 || C.Address.Length < 0)
                {
                    throw new CustomerNotException("Customer Address is not in range.");
                }

                if (C.City.Length < 0 || C.City.Length > 15)
                {
                    throw new CustomerNotException("Customer city length is not in range.");
                }

                if (C.Region.Length > 15 || C.Region.Length < 0)
                {
                    throw new CustomerNotException("Region Length is not in range.");
                }

                if (C.PostalCode.Length > 10 || C.PostalCode.Length < 0)
                {
                    throw new CustomerNotException("Customer Postalcode is not in range.");
                }

                if (C.Country.Length > 15 || C.Country.Length < 0)
                {
                    throw new CustomerNotException("Country length is not in range.");
                }
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (FormatException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }
        public bool AddNewCustomer(Customers Customer)
        {
            CustomersDAL dal = new CustomersDAL();
            //Validate(Customer);
            var status = dal.AddNewCustomer(Customer);
            return status;
        }

        public bool UpdateCustomer(Customers Customer)
        {
            CustomersDAL DAl = new CustomersDAL();
            Validate(Customer);
            var status = DAl.UpdateCustomer(Customer);
            return status;
        }

        public bool DeleteCustomer(string number)
        {
            CustomersDAL DAl = new CustomersDAL();
            var status = DAl.DeleteCustomer(number);
            return status;
        }

        public Customers GetCustomer(string CID)
        {
            CustomersDAL DAl = new CustomersDAL();
            Customers Customer = new Customers();
            Customer = DAl.GetCustomer(CID);
            return Customer;
        }

        public List<Customers> GetAllCustomers()
        {
            List<Customers> list = new List<Customers>();
            CustomersDAL DAl = new CustomersDAL();
            list = DAl.GetAllCustomers();
            return list;
        }
        public void LoginCustomer(string Number, string Password)
        {
            
            LoginCustomer(Number,Password);
            
        }
        public  bool CustomerpasswordReset(string Number,string Password)
        {
            CustomersDAL DAl = new CustomersDAL();
            var status = CustomerpasswordReset(Number,Password);
            return status;
        }

    }
}
