using JobAPI.Interfaces;
using JobAPI.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace JobAPI.Databases
{
	public class InMemoryAccountsDb : IAccountsDb
	{
		private static readonly SHA512 HashFunction = SHA512.Create();

		private readonly Dictionary<Guid, UserData> Data = new Dictionary<Guid, UserData>();

		public void Delete(Guid user)
		{
			Data.Remove(user);
		}

		public bool Exists(Login login, bool includePassword, out Guid user)
		{
			if (includePassword)
			{
				login.Password = Hash(login.Email, login.Password);
			}

			foreach (var data in Data.Values)
			{
				if (data.Email == login.Email)
				{
					user = data.Id;
					return !includePassword || data.Password == login.Password;
				}
			}

			user = default;
			return false;
		}

		public void Update(Guid user, Registration registration)
		{
			if (Data.TryGetValue(user, out UserData data))
			{
				if (registration.Password != null)
				{
					registration.Password = Hash(registration.Email, registration.Password);
				}

				data.UpdateWith(registration);
			}
		}

		private static string Hash(string email, string password)
		{
			return Encoding.UTF8.GetString(HashFunction.ComputeHash(Encoding.UTF8.GetBytes(email + password)));
		}

		public bool TryGet(Guid user, out Registration registration)
		{
			if (Data.TryGetValue(user, out UserData data))
			{
				registration = data;
				return true;
			}
			else
			{
				registration = default;
				return false;
			}
		}

		private class UserData : Registration
		{
			public Guid Id { get; set; }
		}
	}
}
