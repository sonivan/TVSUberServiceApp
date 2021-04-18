using JobAPI.Interfaces;

namespace JobAPI.Models
{
	public class Job : JobBase
	{
		public UserInfo Owner { get; set; }

		public Job(IAccountsRepository repository, StoredJob stored) : base(stored)
		{
			if (repository.TryGetInfo(stored.Owner, out UserInfo info))
			{
				Owner = info;
			}
			else
			{
				Owner = null;
			}
		}
	}
}
