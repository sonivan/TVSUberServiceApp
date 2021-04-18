using JobAPI.Models;

namespace JobAPI.Interfaces
{
	public interface IJobsRepository
	{
		APIActionResult<StoredJob> Get(ulong id);
		APIActionResult<StoredJob[]> GetMany(ulong? start, ulong count);
		APIActionResult Update(Token token, StoredJob job);
	}
}
