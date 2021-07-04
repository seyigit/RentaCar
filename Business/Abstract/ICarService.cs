using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetById(int id);
        IDataResult<List<CarDetailDto>> CarDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

    }
}
