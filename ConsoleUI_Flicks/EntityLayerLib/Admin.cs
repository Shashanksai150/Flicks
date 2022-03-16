using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayerLib
{
    public class Admin
    {
        string _adminID;
        public string AdminID
        {
            get { return _adminID; }
            set
            {
                try
                {
                    _adminID = value;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        string _pwd;
        public string password
        {
            get { return _pwd; }
            set
            {
                try
                {
                    _pwd = value;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        string _adminName;
        public string AdminName
        {
            get { return _adminName; }
            set
            {
                try
                {
                    _adminName = value;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        DateTime _lstpwd;
        public DateTime lastPassword
        {
            get { return _lstpwd; }
            set
            {
                try
                {
                    _lstpwd = value;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        bool _limreached;
        public bool LimitReached
        {
            get { return _limreached; }
            set
            {
                try
                {
                    _limreached = value;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
       
            
    }
}
