﻿using Business.Abstract;
using Core.Entities.Concrete;
using DataAccss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal  _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public void Add(User user)
        {
            _userdal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userdal.Get(m => m.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userdal.GetClaims(user);
        }
    }
}
