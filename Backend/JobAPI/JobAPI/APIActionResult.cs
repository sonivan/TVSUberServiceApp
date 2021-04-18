namespace JobAPI
{
	public class APIActionResult
	{
		public bool Success { get; protected set; }
		public string Error { get; protected set; }

		protected int Status;

		public APIActionResult()
		{
			Success = true;
			Error = null;
		}

		public APIActionResult(int status, string error)
		{
			Success = false;
			Status = status;
			Error = error;
		}

		public int GetStatus()
		{
			return Status;
		}

		public APIActionResult And(APIActionResult result)
		{
			if (Success)
			{
				return result;
			}
			else
			{
				return this;
			}
		}
	}

	public class APIActionResult<T> : APIActionResult
	{
		public T Result { get; }

		public APIActionResult(T value)
		{
			Success = true;
			Result = value;
		}

		public APIActionResult(int status, string error)
		{
			Success = false;
			Status = status;
			Error = error;
		}
	}
}
