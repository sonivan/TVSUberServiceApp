using JobAPI.Models;
using System;

namespace JobAPI.Interfaces
{
	public interface IAccountsDb
	{
		bool TryGet(Guid user, out Registration registration);
		bool Exists(Login login, bool includePassword, out Guid user);
		void Update(Guid user, Registration registration);
		void Delete(Guid user);
	}
}
