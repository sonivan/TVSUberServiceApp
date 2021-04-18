using JobAPI.Interfaces;
using JobAPI.Models;
using System.Collections.Generic;

namespace JobAPI.Repositories
{
	public class InMemoryBookingRepository : IBookingRepository
	{
		private static IJobsRepository Jobs => Configuration.Jobs;

		private readonly Dictionary<ulong, List<Booking>> Bookings = new Dictionary<ulong, List<Booking>>();

		public APIActionResult Book(Booking booking)
		{
			if (Bookings.TryGetValue(booking.Job, out List<Booking> bookings))
			{
				if (TryAdd(bookings, booking))
				{
					return new APIActionResult();
				}
				else
				{
					return new APIActionResult(400, "The booking can not be added because there is already a booking scheduled that overlaps.");
				}
			}
			else
			{
				if (Jobs.Get(booking.Job).Success)
				{
					return new APIActionResult();
				}
				else
				{
					return new APIActionResult<StoredJob>(404, "No job with the specified ID.");
				}
			}
		}

		public APIActionResult<Booking[]> GetBookings(ulong job)
		{
			throw new System.NotImplementedException();
		}

		private static bool TryAdd(List<Booking> bookings, Booking booking)
		{
			foreach (var elem in bookings)
			{
				if ((booking.StartTime < elem.StartTime && elem.StartTime < booking.EndTime) || (elem.StartTime < booking.StartTime && booking.StartTime < booking.EndTime))
				{
					return false;
				}
			}

			bookings.Add(booking);
			return true;
		}
	}
}
