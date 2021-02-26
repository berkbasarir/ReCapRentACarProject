using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, DailyPrice = 150, ModelYear = 2021, Description = "Mavi BMW"},
                new Car{CarId = 2, BrandId = 2, DailyPrice = 150, ModelYear = 2021, Description = "Beyaz Audi"},
                new Car{CarId = 3, BrandId = 4, DailyPrice = 150, ModelYear = 2021, Description = "Gri Volvo"},
                new Car{CarId = 4, BrandId = 5, DailyPrice = 150, ModelYear = 2021, Description = "Beyaz Mercedes"},
                new Car{CarId = 5, BrandId = 5, DailyPrice = 150, ModelYear = 2021, Description = "Kırmızı Mercedes"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public Car GetById(Car car)
        {
            return _cars.SingleOrDefault(c => c.CarId == car.CarId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
