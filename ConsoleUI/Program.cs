using Business.Concrete;
using Core.Utilities.Helpers;
using DataAccss.Concrete.InMemory;
using DataAccss.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddRentalCheckMethod();

            //UsersAddOperations();

            //ColorCrudOperationsMethod();
            //BrandCrudOperationsMethod();
            //CarDtoDetailsMethod();

            //CarCrudOperationsMethod();

            GetByCarIdMethod();

        }

        private static void GetByCarIdMethod()
        {
            CarImagesManager image = new CarImagesManager(new EfCarImagesDal(), new FileHelper());
            var result = image.GetByImageByCarId(2);
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ImagePath);
                }
            }
        }

        private static void AddRentalCheckMethod()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rentals rentals = new Rentals() { CarId = 1, CustomerId = 2, RentDate = "2021", ReturnDate = null };

            var result = rentalManager.Add(rentals);
            Console.WriteLine(result.Message);
        }

        //private static void UsersAddOperations()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());

        //    Users users1 = new Users() { FirstName = "Sedat", LastName = "Yiğit", Email = "gnctrkcll947@gmail.com", Password = "Sede_7272" };
        //    Users users2 = new Users() { FirstName = "Serhat", LastName = "Yiğit", Email = "gnctrkc947@gmail.com", Password = "Sere_7272" };
        //    Users users3 = new Users() { FirstName = "Umut", LastName = "Yiğit", Email = "umut@gmail.com", Password = "Umut_7272" };

        //    userManager.Add(users1);
        //    userManager.Add(users2);
        //    userManager.Add(users3);
        //}

        private static void ColorCrudOperationsMethod()
        {
            Console.WriteLine("-----------------------------------------------Color GetAll Method------------------------------------------------");
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorId + " - " + item.ColorName);
            }

            Console.WriteLine("-----------------------------------------------Color  GetById Method------------------------------------------------");

            var result = colorManager.GetById(4);
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ColorId + " - " + item.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            Console.WriteLine("-----------------------------------------------Color  Add Method------------------------------------------------");

            Color color = new Color() { ColorName = "Altın" };
            //Color deletecolor = new Color() { ColorId = 2 };
            Color updatecolor = new Color() { ColorId = 3, ColorName = "Sedat Renk" };

            colorManager.Add(color);

            Console.WriteLine("-----------------------------------------------Color  Deleted Method------------------------------------------------");

            //colorManager.Delete(deletecolor);

            Console.WriteLine("-----------------------------------------------Color  Updated Method------------------------------------------------");

            colorManager.Update(updatecolor);
        }

        private static void BrandCrudOperationsMethod()
        {
            Console.WriteLine("-----------------------------------------------Brand GetAll Method------------------------------------------------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.BrandId + " - " + item.BrandName);
            }

            Console.WriteLine("-----------------------------------------------Brand  GetById Method------------------------------------------------");

            foreach (var item in brandManager.GetById(3).Data)
            {
                Console.WriteLine(item.BrandId + " - " + item.BrandName);
            }

            Console.WriteLine("-----------------------------------------------Brand  Add Method------------------------------------------------");

            Brand brand = new Brand() { BrandName = "BMW" };
            Brand deletebrand = new Brand() { BrandId = 2 };
            Brand updatebrand = new Brand() { BrandId = 1002, BrandName = "Ferrari" };

            brandManager.Add(brand);

            Console.WriteLine("-----------------------------------------------Brand  Deleted Method------------------------------------------------");

            brandManager.Delete(deletebrand);

            Console.WriteLine("-----------------------------------------------Brand  Updated Method------------------------------------------------");

            brandManager.Update(updatebrand);
        }

        private static void CarDtoDetailsMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.CarDetails().Data)
            {
                Console.WriteLine("Araba İsmi : {0} --- Marka: {1} --- REnk : {2} --- Fiyat: {3}",item.CarName,item.BrandName, item.ColorName, item.DailyPrice);
            }
        }

        private static void CarCrudOperationsMethod()
        {
            Console.WriteLine("-----------------------------------------------Car GetAll Method------------------------------------------------");
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(item.BrandId + " - " + item.ColorId + " - " + item.DailyPrice + " - " + item.Description);
            }

            Console.WriteLine("-----------------------------------------------Car GetById Method------------------------------------------------");

            foreach (var item in carManager.GetById(3).Data)
            {
                Console.WriteLine(item.BrandId + " - " + item.ColorId + " - " + item.DailyPrice + " - " + item.Description);
            }

            Console.WriteLine("-----------------------------------------------Car Add Method------------------------------------------------");

            Car car = new Car() { Id = 1003, BrandId = 1, ColorId = 2, DailyPrice = 3000, Description = "Falancaaaa", ModelYear = "2045" };

            //carManager.Add(car);

            Console.WriteLine("-----------------------------------------------Car Deleted Method------------------------------------------------");

            //carManager.Delete(car);

            Console.WriteLine("-----------------------------------------------Car Updated Method------------------------------------------------");

            carManager.Update(car);

            
        }
    }
}
