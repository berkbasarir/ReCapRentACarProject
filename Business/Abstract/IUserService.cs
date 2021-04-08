using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        //IDataResult<List<OperationClaim>> GetClaims(User user);
        //IDataResult<User> GetByMail(string email);
        IDataResult<User> GetLastUser();

        //IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}