﻿using Core.Entities.Concrete;
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
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);
    }
}