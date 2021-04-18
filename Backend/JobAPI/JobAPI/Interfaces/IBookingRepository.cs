using JobAPI.Models;

namespace JobAPI.Interfaces
{
	public interface IBookingRepository
	{
		APIActionResult Book(Booking booking);
		APIActionResult<Booking[]> GetBookings(ulong job);
	}
}
