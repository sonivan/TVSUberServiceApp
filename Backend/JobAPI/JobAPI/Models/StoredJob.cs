using System;

namespace JobAPI.Models
{
	public class StoredJob : JobBase
	{
		public Guid Owner { get; set; }

		public StoredJob() { }

		public StoredJob(Guid owner, JobBase job) : base(job)
		{
			Owner = owner;
		}

		public bool IsValid()
		{
			return BaseValid;
		}
	}
}
