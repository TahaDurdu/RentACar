using System;
using Core.Entities.Concrate;
using Core.Entities.Concrete;
using Core.Utilities.Results;


namespace Business.Abstract
{
	public interface IUserService
	{
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> GetByMail(string email);
    }
}

