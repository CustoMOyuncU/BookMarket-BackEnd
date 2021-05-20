using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        List<OperationClaim> GetClaimsByUserId(int id);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);
    }
}
