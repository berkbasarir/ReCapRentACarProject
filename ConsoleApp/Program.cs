using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //GetAllCarDescription(carManager);
            //GetAllByModelYear(carManager);
            //GetAllByDailyPrice(carManager);
            //GetCarsByBrandId(carManager);
            //GetCarsByColorId(carManager);
            //carManager.Add(new Car {Id = 9, BrandId = 5, ColorId = 3, DailyPrice = 250, Description = "Gri Mercedes", ModelYear = 2021});
            //carManager.Update(new Car {Id = 10, BrandId = 5, ColorId = 3, DailyPrice = 120, Description = "Gri Mercedes 2018", ModelYear = 2018});
            //carManager.Add(new Car {Id = 11, BrandId = 5, ColorId = 3, Name = "Araba 11", DailyPrice = 300, Description = "Gold Mercedes", ModelYear = 2022});
            GetCarsByBrandId(carManager);
        }



        private static void GetAllCarDescription(CarManager carManager)
        {
            Console.WriteLine("-----------All----------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void GetAllByModelYear(CarManager carManager)
        {
            Console.WriteLine("-----------2018-2022----------");
            foreach (var car in carManager.GetAllByModelYear(2018, 2022))
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void GetAllByDailyPrice(CarManager carManager)
        {
            Console.WriteLine("-----------50-150----------");
            foreach (var car in carManager.GetByDailyPrice(50, 150))
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void GetCarsByBrandId(CarManager carManager)
        {
            Console.WriteLine("-----------Mercedes----------");
            foreach (var car in carManager.GetCarsByBrandId(5))
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void GetCarsByColorId(CarManager carManager)
        {
            Console.WriteLine("-----------Beyaz----------");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
