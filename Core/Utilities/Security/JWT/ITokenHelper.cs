using System;
using Core.Entities.Concrate;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
	public interface ITokenHelper
	{
		public AccessToken CreateToken(User user , List<OperationClaim> operationClaims);
	}
}

