using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLib;

namespace EntityLayerLib
{
    public class CurrentlyRented
    {
		string _RentID;
		public string RentID
		{
			get { return _RentID; }
			set
			{
				try
				{
					_RentID = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}
		string _MID;
		public string MID
		{
			get { return _MID; }
			set
			{
				try
				{
					_MID = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}
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
		DateTime _RentedDateTime;

		public DateTime RentedDateTime
		{
			get { return _RentedDateTime; }
			set
			{
				try
				{
					_RentedDateTime = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}
		

		
		

	}
}
