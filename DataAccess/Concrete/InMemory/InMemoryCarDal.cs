using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, DailyPrice = 150, ModelYear = 2021, Description = "Mavi BMW"},
                new Car{Id = 2, BrandId = 2, DailyPrice = 150, ModelYear = 2021, Description = "Beyaz Audi"},
                new Car{Id = 3, BrandId = 3, DailyPrice = 150, ModelYear = 2021, Description = "Gri Volvo"},
                new Car{Id = 4, BrandId = 5, DailyPrice = 150, ModelYear = 2021, Description = "Beyaz Mercedes"},
                new Car{Id = 5, BrandId = 5, DailyPrice = 150, ModelYear = 2021, Description = "Kırmızı Mercedes"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
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

        public Car GetById(Car car)
        {
            return _cars.SingleOrDefault(c => c.Id == car.Id);
        }

        public List<CarDetailDto> GetAllCarsDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
