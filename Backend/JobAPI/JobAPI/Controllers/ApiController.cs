using JobAPI.Interfaces;
using JobAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobAPI.Controllers
{
	[ApiController]
	public class ApiController : ControllerBase
	{
		private static IAccountsRepository Accounts => Configuration.Accounts;
		private static IJobsRepository Jobs => Configuration.Jobs;
		private static IBookingRepository Booking => Configuration.Booking;

		[HttpPost]
		[Route("/api/account/create")]
		[ProducesResponseType(typeof(Token), 200)]
		[ProducesResponseType(typeof(ProblemDetails), 400)]
		public object AccountCreate(Registration registration)
		{
			return Status(Accounts.Create(registration));
		}

		[HttpPut]
		[Route("/api/account/login")]
		[ProducesResponseType(typeof(Token), 200)]
		[ProducesResponseType(typeof(ProblemDetails), 400)]
		[ProducesResponseType(typeof(ProblemDetails), 401)]
		public object AccountLogin(Login login)
		{
			return Status(Accounts.Login(login));
		}

		[HttpPut]
		[Route("/api/account/update")]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ProblemDetails), 400)]
		[ProducesResponseType(typeof(ProblemDetails), 401)]
		public object AccountUpdate(RegistrationUpdate update)
		{
			return Status(Accounts.Update(update.Token, update.NewValues));
		}

		[HttpPut]
		[Route("/api/account/logout")]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ProblemDetails), 400)]
		[ProducesResponseType(typeof(ProblemDetails), 401)]
		public object AccountLogout(Token token)
		{
			return Status(Accounts.Logout(token));
		}

		[HttpDelete]
		[Route("/api/account/delete")]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ProblemDetails), 400)]
		[ProducesResponseType(typeof(ProblemDetails), 401)]
		public object AccountsDelete(Token token)
		{
			return Status(Accounts.Delete(token));
		}

		[HttpPut]
		[Route("/api/jobs/createOrUpdate")]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ProblemDetails), 400)]
		[ProducesResponseType(typeof(ProblemDetails), 401)]
		public object JobsCreateOrUpdate(JobUpdate update)
		{
			return Status(Jobs.Update(update.Token, new StoredJob(update.Token.User, update.NewValues)));
		}

		[HttpGet]
		[Route("/api/jobs/{id}")]
		[ProducesResponseType(typeof(Job), 200)]
		[ProducesResponseType(typeof(ProblemDetails), 400)]
		[ProducesResponseType(typeof(ProblemDetails), 404)]
		public object JobsGet(ulong id)
		{
			return Status(Jobs.Get(id));
		}

		[HttpGet]
		[Route("/api/jobs")]
		[ProducesResponseType(typeof(Job[]), 200)]
		[ProducesResponseType(typeof(ProblemDetails), 400)]
		public object JobsMany(Range range)
		{
			return Status(Jobs.GetMany(range.Start, range.Count));
		}

		[HttpPost]
		[Route("/api/bookings/book")]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ProblemDetails), 400)]
		[ProducesResponseType(typeof(ProblemDetails), 404)]
		public object BookingBook(Booking booking)
		{
			return Status(Booking.Book(booking));
		}

		[HttpGet]
		[Route("/api/bookings/{id}")]
		[ProducesResponseType(typeof(Booking[]), 200)]
		public object BookingBookings(ulong id)
		{
			return Status(Booking.GetBookings(id));
		}

		private object Status(APIActionResult result)
		{
			HttpContext.Response.StatusCode = result.GetStatus();

			if (result.Success)
			{
				return null;
			}
			else
			{
				return new ProblemDetails
				{
					Status = result.GetStatus(),
					Detail = result.Error,
					Title = "API Error"
				};
			}
		}

		private object Status<T>(APIActionResult<T> result)
		{
			HttpContext.Response.StatusCode = result.GetStatus();

			if (result.Success)
			{
				return result.Result;
			}
			else
			{
				return new ProblemDetails
				{
					Status = result.GetStatus(),
					Detail = result.Error,
					Title = "API Error"
				};
			}
		}
	}
}
