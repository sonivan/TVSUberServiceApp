using JobAPI.Interfaces;
using JobAPI.Models;
using System.Collections.Generic;

namespace JobAPI.Repositories
{
	public class InMemoryJobsRepository : IJobsRepository
	{
		private static IAccountsRepository Accounts => Configuration.Accounts;

		private readonly Dictionary<ulong, StoredJob> Jobs = new Dictionary<ulong, StoredJob>();

		public APIActionResult<StoredJob> Get(ulong id)
		{
			if (Jobs.TryGetValue(id, out StoredJob job))
			{
				return new APIActionResult<StoredJob>(job);
			}
			else
			{
				return new APIActionResult<StoredJob>(404, "No job with the specified ID.");
			}
		}

		public APIActionResult<StoredJob[]> GetMany(ulong? start, ulong count)
		{
			var index = start.HasValue ? start.Value + 1 : 0;
			var all = new StoredJob[Jobs.Count];
			Jobs.Values.CopyTo(all, 0);

			var results = new List<StoredJob>();

			for (int i = 0; i < all.Length && (ulong)results.Count < count; i++)
			{
				if (all[i].Id >= index) results.Add(all[i]);
			}

			return new APIActionResult<StoredJob[]>(results.ToArray());
		}

		public APIActionResult Update(Token token, StoredJob job)
		{
			if (Accounts.Validate(token) && job.Owner == token.User)
			{
				if (job.IsValid())
				{
					Jobs[job.Id.Value] = job;

					return new APIActionResult();
				}
				else
				{
					return new APIActionResult(400, "Missing required fields.");
				}
			}
			else
			{
				return new APIActionResult(401, "Invalid credentials.");
			}
		}
	}
}
