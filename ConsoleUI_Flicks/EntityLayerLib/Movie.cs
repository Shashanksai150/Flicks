using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLib;

namespace EntityLayerLib
{
    public class Movie
    {
		string _ID;
		public string MovieID
		{
			get { return _ID; }
			set
			{
				try
				{
					_ID = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		string _Title;
		public string Title
		{
			get { return _Title; }
			set
			{
				try
				{
					_Title = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		int _Mnum;
		public int Mnum
		{
			get { return _Mnum; }
			set
			{
				try
				{
					_Mnum = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		string Lang;
		public string Language
		{
			get { return Lang; }
			set
			{
				try
				{
					Lang = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		string _Genres;
		public string Genres
		{
			get { return _Genres; }
			set
			{
				try
				{
					_Genres = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		int year;
		public int Year
		{
			get { return year; }
			set
			{
				try
				{
					year = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}


		decimal _Rating;
		public decimal Rating
		{
			get { return _Rating; }
			set
			{
				try
				{
					_Rating = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		int _sa;
		public int StocKavailable
		{
			get { return _sa; }
			set
			{
				try
				{
					_sa = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		int _TS;
		public int TotalStock
		{
			get { return _TS; }
			set
			{
				try
				{
					_TS = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		double BRP;
		public double Bluerayprice
		{
			get { return BRP; }
			set
			{
				try
				{
					BRP = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		int TUR;
		public int TotalUnitsrented
		{
			get { return TUR; }
			set
			{
				try
				{
					TUR = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}

		double RG;
		public double RevenueGenerated
		{
			get { return RG; }
			set
			{
				try
				{
					RG = value;
				}
				catch (Exception ex) { throw ex; }
			}
		}
	}
}
