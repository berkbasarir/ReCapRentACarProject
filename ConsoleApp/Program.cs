using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            //GetAllCarDescriptionByBrand(carManager);
            //GetAllCarDescription(carManager);
        }

        private static void GetAllCarDescriptionByBrand(CarManager carManager)
        {
            foreach (var car in carManager.GetAllByBrand(5))
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetAllCarDescription(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
