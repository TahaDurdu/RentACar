using System;
namespace Core.Utilities.Results
{
	public class Result:IResult
	{
		public Result(bool success,string message):this(success)
		{
            Message = message;

        }
		public Result(bool success)
		{
			 success = Success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}

