namespace JobAPI.Models
{
	public abstract class JobBase
	{
		public ulong? Id { get; set; }
		public string Title { get; set; }
		public string ShortText { get; set; }
		public string Description { get; set; }
		public string[] Images { get; set; }

		protected bool BaseValid => Id.HasValue && !(string.IsNullOrWhiteSpace(Title) || ShortText == null || Description == null || Images == null);

		public JobBase() { }

		public JobBase(ulong id, string title, string shortText, string description, string[] images)
		{
			Id = id;
			Title = title;
			ShortText = shortText;
			Description = description;
			Images = images;
		}

		public JobBase(JobBase original)
		{
			Id = original.Id;
			Title = original.Title;
			ShortText = original.ShortText;
			Description = original.Description;
			Images = original.Images;
		}
	}
}
