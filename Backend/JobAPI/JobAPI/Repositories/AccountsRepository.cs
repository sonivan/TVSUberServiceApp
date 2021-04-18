using JobAPI.Interfaces;
using JobAPI.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace JobAPI.Repositories
{
	public class AccountsRepository : IAccountsRepository
	{
		private static IAccountsDb Accounts => Configuration.AccountsDb;

		private readonly Dictionary<Guid, UserData> LoggedIn = new Dictionary<Guid, UserData>();

		public APIActionResult<Token> Create(Registration registration)
		{
			if (registration.Valid)
			{
				if (Accounts.Exists(registration, false, out Guid user))
				{
					return new APIActionResult<Token>(400, "A user with the same email already exists.");
				}
				else
				{
					Accounts.Update(user, registration);
					return Login(registration);
				}
			}
			else
			{
				return new APIActionResult<Token>(400, "Missing required fields.");
			}
		}

		public APIActionResult Delete(Token token)
		{
			if (TryGetUser(token, out UserData user) && Logout(token).Success)
			{
				Accounts.Delete(user.Id);
				return new APIActionResult();
			}
			else
			{
				return new APIActionResult(401, "Invalid credentials.");
			}
		}

		public APIActionResult KeepAlive(Token token)
		{
			if (TryGetUser(token, out UserData user))
			{
				user.KeepAlive();
				return new APIActionResult();
			}
			else
			{
				return new APIActionResult(401, "Invalid credentials.");
			}
		}

		public APIActionResult<Token> Login(Login login)
		{
			if (Accounts.Exists(login, true, out Guid id))
			{
				var user = new UserData(id);
				LoggedIn[id] = user;
				return new APIActionResult<Token>(user.Token);
			}
			else
			{
				return new APIActionResult<Token>(401, "Invalid credentials.");
			}
		}

		public APIActionResult Logout(Token token)
		{
			if (TryGetUser(token, out UserData user))
			{
				LoggedIn.Remove(user.Id);
				return new APIActionResult();
			}
			else
			{
				return new APIActionResult(401, "Invalid credentials.");
			}
		}

		public APIActionResult Update(Token token, Registration registration)
		{
			if (TryGetUser(token, out UserData user))
			{
				Accounts.Update(user.Id, registration);
				return new APIActionResult();
			}
			else
			{
				return new APIActionResult(401, "Invalid credentials.");
			}
		}

		public bool TryGetInfo(Guid id, out UserInfo info)
		{
			if (Accounts.TryGet(id, out Registration registration))
			{
				info = registration.User;
				return true;
			}
			else
			{
				info = default;
				return false;
			}
		}

		public bool Validate(Token token)
		{
			return TryGetUser(token, out _);
		}

		private bool TryGetUser(Token token, out UserData user)
		{
			if (token == null)
			{
				user = default;
				return false;
			}

			if (TryGetUserById(token.User, out user))
			{
				return user.Verify(token);
			}
			else
			{
				return false;
			}
		}

		private bool TryGetUserById(Guid id, out UserData user)
		{
			if (LoggedIn.TryGetValue(id, out user))
			{
				if (user.Valid)
				{
					LoggedIn.Remove(user.Id);
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return false;
			}
		}

		private class UserData
		{
			public bool Valid => Expiry > DateTime.UtcNow;

			public Guid Id;
			public string Key;
			public DateTime Expiry;

			public Token Token => new Token
			{
				User = Id,
				Key = Key
			};

			public UserData(Guid id)
			{
				KeepAlive();
				Id = id;
				Key = GenerateKey();
			}

			public bool Verify(Token token)
			{
				return Valid && token.Key == Key;
			}

			public void KeepAlive()
			{
				Expiry = DateTime.UtcNow + TimeSpan.FromMinutes(15);
			}

			private static string GenerateKey()
			{
				var data = new byte[64];
				RandomNumberGenerator.Fill(data);
				return Convert.ToBase64String(data);
			}
		}
	}
}
