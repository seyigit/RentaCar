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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(Users user)

        {
           
            _userDal.Add(user);

            return new SuccesResult(Messages.AddToUser);
        }

        public IResult Delete(Users user)
        {
            _userDal.Delete(user);

            return new SuccesResult(Messages.DeleteToUserSuccessMessage);
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(), Messages.GetAllFilterSuccessMessage);
        }

        public IDataResult<List<Users>> GetById(int id)
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(p=>p.Id == id), Messages.GetAllFilterSuccessMessage);
        }

        public IResult Update(Users user)
        {
            _userDal.Update(user);
            return new SuccesResult(Messages.UpdateToUserMessage);
        }
    }
}
