using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customers customer)
        {
            _customerDal.Add(customer);

            return new SuccesResult(Messages.AddToCustomerSuccessMessage);
        }

        public IResult Delete(Customers customer)
        {
            _customerDal.Delete(customer);

            return new SuccesResult(Messages.DeleteToCustomerSuccessMessage);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(), Messages.GetAllFilterSuccessMessage);
        }

        public IDataResult<List<Customers>> GetById(int id)
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(p=>p.UserId==id), Messages.GetAllFilterSuccessMessage);
        }

        public IResult Update(Customers customer)
        {
            _customerDal.Update(customer);

            return new SuccesResult(Messages.UpdateToCustomerSuccessMessage);
        }
    }
}
