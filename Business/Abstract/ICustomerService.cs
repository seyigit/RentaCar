using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ICustomerService
    {
        IDataResult<List<Customers>> GetAll();
        IDataResult<List<Customers>> GetById(int id);
        IResult Add(Customers customer);
        IResult Update(Customers customer);
        IResult Delete(Customers customer);
    }
}
