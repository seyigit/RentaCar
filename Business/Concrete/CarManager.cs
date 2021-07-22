using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.GetAllFilterSuccessMessage);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);

            return new SuccesResult(Messages.AddToCar);
        }

  

        public IResult Update(Car car)
        {
            if (car.CarName=="Toyota")
            {
                return new ErrorResult(Messages.UpdateToCarInvalidMessage);
            }
            _carDal.Update(car);

            return new SuccesResult(Messages.UpdateToCarMessage);
        }

        public IResult Delete(Car car) 
        {
            _carDal.Delete(car);

            return new SuccesResult(Messages.DeleteToCarSuccessMessage);
        }

        public IDataResult<List<CarDetailDto>> CarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.CarDetails(),Messages.CarDetailSuccessMessage);
        }


        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.Id == id),Messages.GetByIdFilterSuccessMessage);
        }
    }
}
