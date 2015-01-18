using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enexure.Fire.Time
{
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Gets the start of the current day at 0000/12:00AM
		/// </summary>
		public static DateTime GetDayStart(this DateTime dateTime)
		{
			return dateTime.Add(-dateTime.TimeOfDay);
		}

		/// <summary>
		/// Gets the end of the current day at 2359/11:59PM
		/// </summary>
		public static DateTime GetDayEnd(this DateTime dateTime)
		{
			return dateTime.Add(new TimeSpan(0, 23, 59, 59) - dateTime.TimeOfDay);
		}

		/// <summary>
		/// Gets a specific month from a date
		/// </summary>
		/// <param name="date">Date to get the specific month from</param>
		/// <returns>The specific month</returns>
		public static SpecificMonth ToSpecificMonth(this DateTime date)
		{
			return new SpecificMonth(date.Year, date.Month);
		}

		/// <summary>
		/// Finds the date in a specific month that matches the DayOfTheWeek and WeekOfTheMonth of the supplied date
		/// </summary>
		/// <param name="specificMonth">Month to find the day in</param>
		/// <param name="date">Date used to calculate the DayOfTheWeek and WeekOfTheMonth</param>
		public static DateTime GetDateMatching(this SpecificMonth specificMonth, DateTime date)
		{
			var weekdayOfFirst = new DateTime(specificMonth.Year, specificMonth.Month, 1).DayOfWeek;
			var daysInMonth = DateTime.DaysInMonth(specificMonth.Year, specificMonth.Month);

			// Wednesday of Week 1 etc.
			var weekday = date.DayOfWeek;
			var daysOff = (int)weekdayOfFirst;
			var occurenceWeek = (date.Day + daysOff - 1) / 7; // 0 based

			// If there is no Xday in the first week add a week
			if (weekdayOfFirst > weekday && occurenceWeek == 0) {
				occurenceWeek++;
			}

			// Find the day given the Week and Weekday

			// Day to check is the default day in the occurrence week
			var dayToCheck = (occurenceWeek * 7) + 1;
			if (dayToCheck > daysInMonth) {
				dayToCheck = daysInMonth;
			}

			// Shift the day
			var dayWeekday = new DateTime(specificMonth.Year, specificMonth.Month, dayToCheck).DayOfWeek;
			var diff = weekday - dayWeekday;
			var finalDay = dayToCheck + diff;

			// Ensure it occurs in the current SpecificMonth
			if (finalDay > daysInMonth) {
				finalDay -= 7;
			}

			return new DateTime(specificMonth.Year, specificMonth.Month, finalDay);
		}

		/// <summary>
		/// Tests if the date is a weekday
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static bool IsWeekday(this DateTime date)
		{
			var dow = date.DayOfWeek;
			return (dow != DayOfWeek.Sunday && dow != DayOfWeek.Saturday);
		}

		/// <summary>
		/// Gets the closest weekday inside the values SpecificMonth
		/// </summary>
		public static DateTime GetClosestWeekdayInMonth(this DateTime date)
		{
			var dow = date.DayOfWeek;
			var isSat = dow == DayOfWeek.Saturday;
			var isSun = dow == DayOfWeek.Sunday;

			if (!isSat && !isSun) return date;

			var firstDayOfTheMonth = (date.Day == 1);
			var lastDayOfTheMonth = (date.Day == DateTime.DaysInMonth(date.Year, date.Month));

			var diff = (isSat)
				? (firstDayOfTheMonth ? 2 : -1)
				: (lastDayOfTheMonth ? -2 : 1);

			return date.AddDays(diff);
		}

		/// <summary>
		/// Gets the closest weekday without regard for SpecificMonth boundaries
		/// </summary>
		public static DateTime GetClosestWeekday(this DateTime time)
		{
			switch (time.DayOfWeek) {
				case DayOfWeek.Saturday:
					return time.AddDays(-1);

				case DayOfWeek.Sunday:
					return time.AddDays(1);

				default:
					return time;
			}
		}

		/// <summary>
		/// Gets the next weekday after the value without regard for SpecificMonth boundaries
		/// </summary>
		public static DateTime GetNextWeekday(this DateTime time)
		{
			switch (time.DayOfWeek) {
				case DayOfWeek.Saturday:
					return time.AddDays(2);

				case DayOfWeek.Sunday:
					return time.AddDays(1);

				default:
					return time;
			}
		}

		/// <summary>
		/// Gets the first day of the values SpecificMonth
		/// </summary>
		public static DateTime GetFirstDayOfMonth(this SpecificMonth month)
		{
			return new DateTime(month.Year, month.Month, 1);
		}

		/// <summary>
		/// Gets the first day of the values SpecificMonth
		/// </summary>
		public static DateTime GetPlaceDayOfMonth(this SpecificMonth month, Place place)
		{
			return place == Place.Last
				? GetLastDayOfMonth(month) 
				: new DateTime(month.Year, month.Month, (1 + (int)place));
		}

		/// <summary>
		/// Gets the last day of the values SpecificMonth
		/// </summary>
		public static DateTime GetLastDayOfMonth(this SpecificMonth month)
		{
			return new DateTime(month.Year, month.Month,DateTime.DaysInMonth(month.Year, month.Month));
		}

		/// <summary>
		/// Gets the place occurence that matches the weekday
		/// </summary>
		public static DateTime GetPlaceInMonth(this SpecificMonth month, Place place, Weekday weekday)
		{
			DateTime currentDay;
			var step = (place == Place.Last) ? -1 : 1;
			var days = DateTime.DaysInMonth(month.Year, month.Month);

			currentDay = (place == Place.Last)
				? month.GetLastDayOfMonth()
				: month.GetFirstDayOfMonth();

			var count = 0;
			var insideMonth = true;
			do {

				var cDow = currentDay.DayOfWeek;
				if (weekday == Weekday.Day) {
					count++;
				} else if (weekday == Weekday.Weekday) {
					if (cDow != DayOfWeek.Saturday && cDow != DayOfWeek.Sunday) {
						count++;
					}
				} else if (weekday == Weekday.WeekendDay) {
					if (cDow == DayOfWeek.Saturday || cDow == DayOfWeek.Sunday) {
						count++;
					}

					// Normal days
				} else if ((int)cDow == (int)weekday) {
					count++;
				}

				if ((place == Place.Last || place == Place.First) && count == 1) {
					return currentDay;

				} else if (count == ((int)place + 1)) {
					return currentDay;
				}

				var nextDay = currentDay.Day + step;
				if ((nextDay > 0) && (nextDay < days + 1)) {
					currentDay = currentDay.AddDays(step);
					insideMonth = true;
				}
			} while (insideMonth);

			return currentDay;
		}

		/// <summary>
		/// Gets the difference in months using the year and SpecificMonth date parts
		/// </summary>
		public static int MonthsDifferenceWith(this DateTime startDate, DateTime endDate)
		{
			return (12 * (endDate.Year - startDate.Year) + endDate.Month - startDate.Month);
		}

		/// <summary>
		/// Gets the difference in years using the date year part
		/// </summary>
		public static int YearsDifference(this DateTime startDate, DateTime endDate)
		{
			return (endDate.Year - startDate.Year);
		}

		/// <summary>
		/// Returns True if the date occurs after the expiry (ignores date)
		/// </summary>
		public static bool IsAfter(this DateTime dateAfter, DateTime dateBefore)
		{
			return (dateAfter.Date > dateBefore.Date);
		}

		/// <summary>
		/// Returns True if the date occurs after the expiry (ignores date)
		/// </summary>
		public static bool HasReached(this DateTime date, DateTime expiry)
		{
			return (date.Date >= expiry.Date);
		}

		/// <summary>
		/// Returns True if the date occurs before the expiry (ignores date)
		/// </summary>
		public static bool IsBefore(this DateTime dateBefore, DateTime dateAfter)
		{
			return (dateBefore.Date < dateAfter.Date);
		}

		/// <summary>
		/// Gets the number of occurrences for each day of the week in a SpecificMonth
		/// </summary>
		public static IDictionary<DayOfWeek, int> DaysOfAMonth(this SpecificMonth month)
		{
			var result = new Dictionary<DayOfWeek, int>();

			var day = month.GetFirstDayOfMonth();
			do {

				var dayName = day.DayOfWeek;
				if (result.ContainsKey(dayName)) {
					result[dayName] = result[dayName] + 1;
				} else {
					result.Add(dayName, 1);
				}

				day = day.AddDays(1);
			} while (day.Month == month.Month);

			return result;
		}
	}
}
