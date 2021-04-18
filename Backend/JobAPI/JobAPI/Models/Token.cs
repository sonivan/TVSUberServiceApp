using System;
using System.ComponentModel.DataAnnotations;

namespace JobAPI.Models
{
	public class Token
	{
		[Required]
		public Guid User { get; set; }
		[Required]
		public string Key { get; set; }
	}
}
