using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IUserService
    {
        IDataResult<List<Users>> GetAll();
        IDataResult<List<Users>> GetById(int id);
        IResult Add(Users user);
        IResult Update(Users user);
        IResult Delete(Users user);
    }
}
