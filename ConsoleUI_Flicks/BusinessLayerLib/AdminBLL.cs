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
    public class AdminBLL
    {
        public Admin LoginAdmin(string Number, string Password)
        {
            AdminDAL dal = new AdminDAL();
            Admin admin = new Admin();
            admin = dal.LoginAdmin(Number,Password);
            return admin;

        }
        public bool AddNewAdmin(Admin admin)
        {
            AdminDAL dal = new AdminDAL();
            var status = dal.AddNewAdmin(admin);
            return status;
        }

        public bool UpdateAdmin(Admin admin)
        {
            AdminDAL dal = new AdminDAL();
            var status = dal.UpdateAdmin(admin);
            return status;
        }

        public bool DeleteCustomer(string AID)
        {
            AdminDAL dal = new AdminDAL();
            var status = dal.DeleteAdmin(AID);
            return status;
        }
        public bool AdminpasswordReset(string Number,string password)
        {
            AdminDAL dal = new AdminDAL();
            var status = dal.AdminpasswordReset(Number,password);
            return status;
        }
    }
}
