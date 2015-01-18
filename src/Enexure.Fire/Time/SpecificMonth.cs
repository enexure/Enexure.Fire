using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enexure.Fire.Time
{
	public class SpecificMonth
	{
		private readonly int year;
		private readonly int month;

		public SpecificMonth(int year, int month)
		{
			this.year = year;
			this.month = month;
		}

		public int Year
		{
			get { return year; }
		}

		public int Month
		{
			get { return month; }
		}
	}
}
