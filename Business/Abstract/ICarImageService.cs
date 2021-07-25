using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int id);
        IDataResult<List<CarImages>> GetByImageByCarId(int id);
        IResult Add(CarImages carImages,IFormFile file);
        IResult Update(CarImages carImages, IFormFile file);
        IResult Delete(CarImages carImages);
    }
}
