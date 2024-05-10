using System;
using Core.DataAccess;
using Core.Entities.Concrate;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IUserDal:IEntityRepository<User>
	{
        List<OperationClaim> GetClaims(User user);
    }
}

