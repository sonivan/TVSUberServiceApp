using JobAPI.Models;
using System;

namespace JobAPI.Interfaces
{
	public interface IAccountsRepository
	{
		APIActionResult<Token> Create(Registration registration);
		APIActionResult<Token> Login(Login login);
		APIActionResult KeepAlive(Token token);
		APIActionResult Update(Token token, Registration registration);
		APIActionResult Logout(Token token);
		APIActionResult Delete(Token token);

		bool Validate(Token token);
		bool TryGetInfo(Guid id, out UserInfo info);
	}
}
