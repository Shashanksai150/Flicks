using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieEntity
{
	/*[Movie ID] varchar(6) primary key not null,
	Name varchar(30) not null,
	[Language] varchar(10) not null,
	Genres varchar(10),
	Rating smallint ,
	[Stock Available] smallint,
	[Total Stock] smallint,
	[BlueRay Price] money,
	[Total Units rented] smallint,
	[Revenue Generated] money*/
    public class Movie
    {
		public int MovieID { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public string Language { get; set; }
		public string Genres { get; set; }
		public decimal Rating { get; set; }
		public int StocKavailable { get; set; }
		public int TotalStock { get; set; }
		public int TotalUnitsrented { get; set; }
		public double Bluerayprice { get; set; }
		public double RevenueGenerated { get; set; }

		
    }
}
