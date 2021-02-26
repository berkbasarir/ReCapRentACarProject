using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        Car GetById(Car car);
        List<Car> GetAllByBrand(int brandId);
        void Add(Car car);
        void Update(Car Car);
        void Delete(Car car);

    }
}
