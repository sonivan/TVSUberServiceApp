using System;
using System.ComponentModel.DataAnnotations;

namespace JobAPI.Models
{
	public class Booking
	{
		[Required]
		public Guid By { get; set; }
		[Required]
		public ulong Job { get; set; }
		[Required]
		public DateTime StartTime { get; set; }
		[Required]
		public DateTime EndTime { get; set; }
	}
}
