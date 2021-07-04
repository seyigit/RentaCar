﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccss.Abstract;
using DataAccss.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);

            return new SuccesResult(Messages.AddToBrandSuccessMessage);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);

            return new SuccesResult(Messages.DeleteToBrandSuccessMessage);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.GetAllFilterSuccessMessage);
        }

        public IDataResult<List<Brand>> GetById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.BrandId == id),Messages.GetByIdFilterSuccessMessage);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);

            return new SuccesResult(Messages.UpdateToBrandMessage);
        }
    }
}
