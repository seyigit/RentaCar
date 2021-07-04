using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccss.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> CarDetails();
    }
}
