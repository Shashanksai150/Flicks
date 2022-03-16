using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLib;

namespace EntityLayerLib
{
    public class MoviesRented
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
		DateTime _ReturnedDateTime;

		public DateTime ReturnedDateTime
		{
			get { return _ReturnedDateTime; }
			set
			{
				try
				{
					_ReturnedDateTime = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		int _DaysRented;

		public int DaysRented
		{
			get { return _DaysRented; }
			set
			{
				try
				{
					_DaysRented = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		decimal _RentAmount;

		public decimal RentAmount
		{
			get { return _RentAmount; }
			set
			{
				try
				{
					_RentAmount = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}
		bool _Returned;

		public bool Returned
		{
			get { return _Returned; }
			set
			{
				try
				{
					_Returned = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}
		bool _PaidorNot;

		public bool PaidorNot
		{
			get { return _PaidorNot; }
			set
			{
				try
				{
					_PaidorNot = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}
	}
}
