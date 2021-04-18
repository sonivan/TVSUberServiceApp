using System.ComponentModel.DataAnnotations;

namespace JobAPI.Models
{
	public class Range
	{
		public ulong? Start { get; set; }
		[Required]
		public ulong Count { get; set; }
	}
}
