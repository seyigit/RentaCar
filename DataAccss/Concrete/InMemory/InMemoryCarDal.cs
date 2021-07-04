using Core.DataAccess;
using DataAccss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccss.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear="1996",Description="Güzel sarı bir araba",DailyPrice=128500},
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear="1996",Description="Güzel sarı bir araba",DailyPrice=128500},
                new Car{Id=3,BrandId=2,ColorId=1,ModelYear="1996",Description="Güzel sarı bir araba",DailyPrice=128500},
                new Car{Id=4,BrandId=2,ColorId=2,ModelYear="1996",Description="Güzel sarı bir araba",DailyPrice=128500},
                new Car{Id=5,BrandId=3,ColorId=3,ModelYear="1996",Description="Güzel sarı bir araba",DailyPrice=128500}
            };

            _brands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Porsche"},
                new Brand{BrandId=2,BrandName="Mustang"},
                new Brand{BrandId=3,BrandName="Mercedes"}
            };
            _colors = new List<Color>
            {
                new Color{ColorId=1,ColorName="Mavi"},
                new Color{ColorId=2,ColorName="Kırmızı"},
                new Color{ColorId=3,ColorName="Gümüş"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);

            Console.WriteLine(car.Id + " nolu "+car.Description+" özellikli "+car.ModelYear+" Model yılı olan araç eklendi.");
        }

        public List<CarDetailDto> CarDetails()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;

            carToDelete = _cars.SingleOrDefault(p=>p.Id==car.Id);

            _cars.Remove(carToDelete);

            Console.WriteLine(carToDelete.Id + "ye sahip araç silindi.");
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = null;

            carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
