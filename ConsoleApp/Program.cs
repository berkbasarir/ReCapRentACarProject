using System;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            */

            

            //GetAllCarNameTest(carManager);
            //GetAllColorNameTest(colorManager);
            //GetColorNameByIdTest(colorManager);
            //GetAllBrandNameTest(brandManager);
            //GetCarDetailsTest(carManager);
            //UserManagerAddTest(userManager);
            //CustomerManagerAddTest(customerManager);
            //GetCustomerDetailsTest(customerManager);
            //CustomerManagerUpdateTest(customerManager);
            

        }



        private static void CustomerManagerUpdateTest(CustomerManager customerManager)
        {
            customerManager.Update(new Customer {Id = 1, UserId = 1, CompanyName = "Berk.Co"});
        }

        private static void UserManagerAddTest(UserManager userManager)
        {
            //userManager.Add(new User {Id = 4, FirstName = "Kemal", LastName = "Kağan", Email = "kemal@kagan.com"});
        }

        private static void CustomerManagerAddTest(CustomerManager customerManager)
        {
            customerManager.Add(new Customer {Id = 1, CompanyName = "Diyetlif"});
        }

        private static void GetAllBrandNameTest(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void GetColorNameByIdTest(ColorManager colorManager)
        {
            var color = colorManager.GetById(2);
            Console.WriteLine(color.Data.Name);
            Console.WriteLine(color.Message);
        }

        private static void GetAllColorNameTest(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine(colorManager.GetAll().Message);
        }
        
        private static void GetAllCarNameTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Name);
            }
            Console.WriteLine(carManager.GetAll().Message);
        }

        private static void GetCarDetailsTest(CarManager carManager)
        {
            var result = carManager.GetAllCarsDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCustomerDetailsTest(CustomerManager customerManager)
        {
            var result = customerManager.GetCustomersDetails();

            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4}", customer.FirstName, customer.LastName, customer.CompanyName, customer.Email);
                }

                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
