using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<User>> GetAll()
        {
            var getAll = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(getAll);
        }

        public IDataResult<User> GetById(int userId)
        {
            var getById = _userDal.Get(u => u.Id == userId);
            return new SuccessDataResult<User>(getById);
        }

        //IDataResult<List<OperationClaim>> IUserService.GetClaims(User user)
        //{
        //    var getClaims = _userDal.GetClaims(user);
        //    return new SuccessDataResult<List<OperationClaim>>(getClaims);
        //}

        //IDataResult<User> IUserService.GetByMail(string email)
        //{
        //    var getByMail = _userDal.Get(u => u.Email == email);
        //    return new SuccessDataResult<User>(getByMail);
        //}

        public IDataResult<User> GetLastUser()
        {
            var lastUser = _userDal.GetAll().LastOrDefault();
            return new SuccessDataResult<User>(lastUser);
        }

        //[ValidationAspect(typeof(UserValidator))]
        //IResult IUserService.Add(User user)
        //{
        //    _userDal.Add(user);
        //    return new SuccessResult(Messages.UserAdded);
        //}

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
    }
}