using System;
namespace Core.GuidHelperr
{
	public class GuidHelper
	{
		public static string CreateGuid()
		{
            return Guid.NewGuid().ToString();
        }

		
    }
}

