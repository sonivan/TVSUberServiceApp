namespace JobAPI.Models
{
	public class UserInfo
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public bool Valid => !(string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName));

		public void UpdateWith(UserInfo info)
		{
			if (info.FirstName != null) FirstName = info.FirstName;
			if (info.LastName != null) LastName = info.LastName;
		}
	}
}
