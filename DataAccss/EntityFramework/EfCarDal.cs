using Core.DataAccess.EntityFramework;
using DataAccss.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccss.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentacarContext>, ICarDal
    {
        public List<CarDetailDto> CarDetails()
        {
            using (RentacarContext context = new RentacarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 CarName = c.CarName
                             };
                return result.ToList();
            }
            
        }
    }
}
