using JobAPI.Databases;
using JobAPI.Interfaces;
using JobAPI.Repositories;

namespace JobAPI
{
	public static class Configuration
	{
		public static IAccountsRepository Accounts { get; } = new AccountsRepository();
		public static IAccountsDb AccountsDb { get; } = new InMemoryAccountsDb();
		public static IJobsRepository Jobs { get; } = new InMemoryJobsRepository();
		public static IBookingRepository Booking { get; } = new InMemoryBookingRepository();
	}
}
