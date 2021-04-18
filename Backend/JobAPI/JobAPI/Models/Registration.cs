namespace JobAPI.Models
{
	public class Registration : Login
	{
		public UserInfo User { get; set; }

		public bool Valid => User != null && User.Valid && !(string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password));

		public void UpdateWith(Registration update)
		{
			if (update.Email != null) Email = update.Email;
			if (update.Password != null) Password = update.Password;
			if (update.User != null) User.UpdateWith(update.User);
		}
	}
}
