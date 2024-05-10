﻿using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrate;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal= userDal ;
        }
       
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.AddedUserSucces);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.DeleteUserSuccess);
        }

        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersSuccessListed);
        }

        public IDataResult<User> GetByMail(string email)
        {
            
            return new SuccessDataResult<User>(_userDal.Get(p => p.Email == email),Messages.EmailAvailable);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.RoleWasBrought);

        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdateSuccessUser);
        }
    }
}

